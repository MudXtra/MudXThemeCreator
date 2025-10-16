using System.ComponentModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using MudXtra.ThemeCreator.Infrastructure.Interfaces;
using MudXtra.ThemeCreator.Infrastructure.Services;

namespace MudXtra.ThemeCreator.UI.Components.Layout;

public partial class MainLayout : LayoutComponentBase
{

    private ErrorBoundary? _errorBoundary;

    [Inject]
    private AuthenticationStateProvider AuthProvider { get; set; } = default!;

    [Inject]
    private UserPreferencesService _userPreference { get; set; } = default!;

    [Inject]
    private ThemeStateService _themeState { get; set; } = default!;

    [Inject]
    private IThemeCreatorService _themeCreator { get; set; } = default!;

    [Inject]
    private NavigationManager _navigationManager { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        // Load the theme list
        await _themeState.UpdateCustomThemes(null);
        // set change events in motion
        _userPreference.PropertyChanged += UpdateState;
        _themeState.PropertyChanged += UpdateState;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _userPreference.UserName = default!;
            _userPreference.SuperUser = default!;
            _userPreference.NoAds = default!;
            await _userPreference.LoadPreferences();
            if (_themeState.CustomThemes.FirstOrDefault(x => x.Id == _userPreference.SelectedThemeIndex) == null)
            {
                // saved theme selection doesn't exist, move to default
                _userPreference.SelectedThemeIndex = 1;
            }
            await _themeState.LoadTheme(_userPreference.SelectedThemeIndex);
            // user logged in?
            var authState = await AuthProvider.GetAuthenticationStateAsync();
            var user = authState?.User;
            if (user is { Identity.IsAuthenticated: true })
            {
                var _userId = user.Claims.FirstOrDefault(c => c.Type == "name")?.Value ?? string.Empty;
                if (string.IsNullOrEmpty(_userId))
                {
                    _userId = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value ?? string.Empty;
                }
                _userPreference.UserName = _userId;
                _userPreference.SuperUser = user.IsInRole("SuperUser");
                _userPreference.NoAds = user.IsInRole("NoAds");
            }
            StateHasChanged();
        }
    }

    private string GetPageTitle => _navigationManager?.Uri.ToLower() switch
    {
        "https://themes.mudx.org/about" => "About MudXtra Theme Manager / Known Issues",
        "https://themes.mudx.org/export" => "Export MudBlazor Theme",
        "https://themes.mudx.org/style" => "MudBlazor CSS Variable Style Lookup",
        "https://themes.mudx.org/upload" => "MudXtra Theme Manager Upload Section",
        _ => "Welcome to MudXtra Theme Manager for MudBlazor"
    };

    private void UpdateState(object? sender, PropertyChangedEventArgs e)
    {
        StateHasChanged();
    }

    public void Dispose()
    {
        _userPreference.PropertyChanged -= UpdateState;
        _themeState.PropertyChanged -= UpdateState;
    }
}
