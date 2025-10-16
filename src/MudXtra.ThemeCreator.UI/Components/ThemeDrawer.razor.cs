using System.ComponentModel;
using Microsoft.AspNetCore.Components;
using MudXtra.ThemeCreator.Infrastructure.Services;

namespace MudXtra.ThemeCreator.UI.Components;

public partial class ThemeDrawer : ComponentBase
{
    private int _selectKey = 0;

    [Inject]
    private UserPreferencesService _userPreference { get; set; } = default!;

    [Inject]
    private ThemeStateService _themeState { get; set; } = default!;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _userPreference.PropertyChanged += (s, e) => StateHasChanged();
        _themeState.PropertyChanged += UpdateState;
    }

    private async Task ResetTheme()
    {
        _selectKey++;
        await _themeState.ClearStorage();
        await _themeState.LoadTheme(_userPreference.SelectedThemeIndex);
    }

    private void UpdateState(object? sender, PropertyChangedEventArgs args)
    {
        if (args.PropertyName == "UpdateCustomThemes")
        {
            _selectKey++;
        }
        StateHasChanged();
    }

    public void Dispose()
    {
        _userPreference.PropertyChanged -= (s, e) => StateHasChanged();
        _themeState.PropertyChanged -= (s, e) => StateHasChanged();
    }
}
