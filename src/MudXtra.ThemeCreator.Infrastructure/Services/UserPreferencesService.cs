using System.ComponentModel;
using System.Runtime.CompilerServices;
using Blazored.LocalStorage;
using Microsoft.Extensions.Logging;
using MudBlazor;

namespace MudXtra.ThemeCreator.Infrastructure.Services;

public class UserPreferencesService : INotifyPropertyChanged
{
    private readonly ILogger<UserPreferencesService> _logger;
    private readonly ILocalStorageService _localStorageService;
    private const string _keyName = "UserPreferences";
    private bool _isLoaded = false;

    private bool _isDarkMode;
    private bool _isRtl;
    private int _selectedThemeIndex = 1;
    private bool _isDrawerOpen = true;
    private string _searchTerm = string.Empty;
    private bool _superUser = false;
    private bool _noAds = false;
    private string _userName = string.Empty;

    public UserPreferencesService(ILogger<UserPreferencesService> logger, ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
        _logger = logger;
    }

    public string UserName
    {
        get => _userName;
        set => SetProperty(ref _userName, value, false);
    }

    public bool SuperUser
    {
        get => _superUser;
        set => SetProperty(ref _superUser, value, false);
    }

    public bool NoAds
    {
        get => _noAds;
        set => SetProperty(ref _noAds, value, false);
    }

    public string SearchTerm
    {
        get => _searchTerm;
        set => SetProperty(ref _searchTerm, value, false);
    }

    public bool IsDrawerOpen
    {
        get => _isDrawerOpen;
        set => SetProperty(ref _isDrawerOpen, value, false);
    }

    #region Persisted Values and Logic for Persistence

    public int SelectedThemeIndex
    {
        get => _selectedThemeIndex;
        set => SetProperty(ref _selectedThemeIndex, value);
    }

    public bool IsRtl
    {
        get => _isRtl;
        set => SetProperty(ref _isRtl, value);
    }

    public bool IsDarkMode
    {
        get => _isDarkMode;
        set => SetProperty(ref _isDarkMode, value);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void SetProperty<T>(ref T field, T value, bool save = true, [CallerMemberName] string propertyName = null!)
    {
        if (!Equals(field, value))
        {
            field = value;
            OnPropertyChanged(propertyName);
            if (save)
                SavePreference(value, propertyName);
        }
    }

    private void SavePreference<T>(T value, string propertyName)
    {
        _localStorageService.SetItemAsync($"{_keyName}.{propertyName}", value).CatchAndLog();
    }

    public async Task LoadPreferences()
    {
        if (!_isLoaded)
        {
            _isDarkMode = await _localStorageService.GetItemAsync<bool?>($"{_keyName}.{nameof(IsDarkMode)}") ?? default!;
            _isRtl = await _localStorageService.GetItemAsync<bool?>($"{_keyName}.{nameof(IsRtl)}") ?? default!;
            _selectedThemeIndex = await _localStorageService.GetItemAsync<int?>($"{_keyName}.{nameof(SelectedThemeIndex)}") ?? default!;
            _isLoaded = true;
        }
    }

    #endregion

}