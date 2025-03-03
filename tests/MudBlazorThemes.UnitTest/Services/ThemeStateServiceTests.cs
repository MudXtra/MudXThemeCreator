using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;
using MudBlazorThemes.DAL.Models;
using MudBlazorThemes.DAL.Services;

namespace MudBlazorThemes.UnitTest.Services;

public class ThemeStateServiceTests
{
    protected Bunit.TestContext Context { get; private set; } = null!;
    private ILocalStorageService _localStorage = default!;
    private ThemeStateService _themeStateService = default!;

    [SetUp]
    public void Setup()
    {
        Context = new();
        Context.Services.AddBlazoredLocalStorage();
        _localStorage = Context.Services.GetRequiredService<ILocalStorageService>();
        _themeStateService = new ThemeStateService(_localStorage);
    }

    [Test]
    public async Task Initialize_SetsIsInitializedAndLoadsState()
    {
        // Arrange
        await _localStorage.SetItemAsync("selectedThemeId", 1);

        // Act
        await _themeStateService.Initialize();

        // Assert
        Assert.That(_themeStateService.IsInitialized, Is.True);
        Assert.That(_themeStateService.ThemeId, Is.EqualTo(1));
    }

    [Test]
    public async Task LoadState_WhenNoThemeId_SetsDefaultValues()
    {
        // Act
        await _themeStateService.LoadState();

        // Assert
        Assert.That(_themeStateService.ThemeId, Is.EqualTo(-1));
        Assert.That(_themeStateService.SelectedThemes, Is.Empty);
        Assert.That(_themeStateService.SelectedShadows, Is.Empty);
        Assert.That(_themeStateService.SelectedLayouts, Is.Empty);
        Assert.That(_themeStateService.SelectedTypographies, Is.Empty);
        Assert.That(_themeStateService.SelectedZIndexes, Is.Empty);
    }

    [Test]
    public async Task UpdateThemeId_SavesToLocalStorage_WhenSaveStateIsTrue()
    {
        // Arrange
        const int newThemeId = 2;

        // Act
        await _themeStateService.UpdateThemeId(newThemeId, saveState: true);

        // Assert
        Assert.That(_themeStateService.ThemeId, Is.EqualTo(newThemeId));
        var storedId = await _localStorage.GetItemAsync<int>("selectedThemeId");
        Assert.That(storedId, Is.EqualTo(newThemeId));
    }

    [Test]
    public async Task UpdateThemeId_DoesNotSaveToLocalStorage_WhenSaveStateIsFalse()
    {
        // Arrange
        const int newThemeId = 2;
        await _localStorage.SetItemAsync("selectedThemeId", 1);

        // Act
        await _themeStateService.UpdateThemeId(newThemeId, saveState: false);

        // Assert
        Assert.That(_themeStateService.ThemeId, Is.EqualTo(newThemeId));
        var storedId = await _localStorage.GetItemAsync<int>("selectedThemeId");
        Assert.That(storedId, Is.EqualTo(1), "Local storage should not be updated");
    }

    [Test]
    public async Task UpdateThemeData_ThemeSelections_UpdatesAndSavesCorrectly()
    {
        // Arrange
        var themeSelections = new List<ThemeSelection>
        {
            new() { ThemeName = "Test", CssVariable = "--test", LightValue = "#fff", DarkValue = "#000" }
        };

        // Act
        await _themeStateService.UpdateThemeData(themeSelections);

        // Assert
        Assert.That(_themeStateService.SelectedThemes, Is.EqualTo(themeSelections));
        var storedThemes = await _localStorage.GetItemAsync<List<ThemeSelection>>("selectedThemes");
        Assert.That(storedThemes, Is.Not.Null);
        Assert.That(storedThemes![0].ThemeName, Is.EqualTo("Test"));
    }

    [Test]
    public void UpdateThemeData_EmptyList_ThrowsArgumentException()
    {
        // Arrange
        var emptyList = new List<ThemeSelection>();

        // Act & Assert
        var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _themeStateService.UpdateThemeData(emptyList));
        Assert.That(ex!.Message, Is.EqualTo("Data List<T> cannot be empty."));
    }

    [Test]
    public async Task ResetTheme_ClearsAllDataAndNotifiesChange()
    {
        // Arrange
        bool changeNotified = false;
        _themeStateService.OnChange += () => changeNotified = true;

        await _localStorage.SetItemAsync("selectedThemeId", 5);
        await _localStorage.SetItemAsync("selectedThemes", new List<ThemeSelection> { new() });

        // Act
        await _themeStateService.ResetTheme();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(_themeStateService.ThemeName, Is.Empty);
            Assert.That(_themeStateService.ThemeOtherText, Is.Empty);
            Assert.That(_themeStateService.ThemeId, Is.EqualTo(1));
            Assert.That(changeNotified, Is.True);
        });

        Assert.That(await _localStorage.GetItemAsync<int>("selectedThemeId"), Is.EqualTo(0));
        Assert.That(await _localStorage.GetItemAsync<List<ThemeSelection>>("selectedThemes"), Is.Null);
    }

    [Test]
    public async Task GenerateStaticCSS_ReturnsCorrectCSSString()
    {
        // Arrange
        await _themeStateService.UpdateThemeData(new List<CustomShadow> 
        { 
            new() { CssVariable = "--mud-shadow", Default = "0 0 5px rgba(0,0,0,0.2)" } 
        });
        
        await _themeStateService.UpdateThemeData(new List<CustomLayoutProperty> 
        { 
            new() { CssVariable = "--mud-spacing", Default = 16 } 
        });

        // Act
        var css = _themeStateService.GenerateStaticCSS();

        // Assert
        Assert.That(css, Does.Contain(":root {"));
        Assert.That(css, Does.Contain("    --mud-shadow: 0 0 5px rgba(0,0,0,0.2);"));
        Assert.That(css, Does.Contain("    --mud-spacing: 16px;"));
        Assert.That(css, Does.Contain("}"));
    }

    [Test]
    public async Task GenerateDarkLightCSS_ReturnsDarkModeCSS_WhenDarkIsTrue()
    {
        // Arrange
        await _themeStateService.UpdateThemeData(new List<ThemeSelection> 
        { 
            new() { CssVariable = "--mud-palette-primary", LightValue = "#1976d2", DarkValue = "#90caf9" } 
        });

        // Act
        var css = _themeStateService.GenerateDarkLightCSS(true);

        // Assert
        Assert.That(css, Does.Contain(":root {"));
        Assert.That(css, Does.Contain("    --mud-palette-primary: #90caf9;"));
        Assert.That(css, Does.Contain("}"));
    }

    [Test]
    public async Task GenerateCSharpCodeV7_ReturnsCorrectCode()
    {
        // Arrange
        _themeStateService.ThemeName = "Custom Theme";
        await _themeStateService.UpdateThemeData(new List<ThemeSelection> 
        { 
            new() { ThemeName = "Primary", ThemeType = "string", LightValue = "#1976d2", DarkValue = "#90caf9" } 
        });

        // Act
        var code = _themeStateService.GenerateCSharpCodeV7();

        // Assert
        Assert.That(code, Does.Contain("public static readonly MudTheme ThemeTheme = new()"));
        Assert.That(code, Does.Contain("PaletteLight = new PaletteLight()"));
        Assert.That(code, Does.Contain("Primary = \"#1976d2\""));
    }

    [Test]
    public async Task GenerateCSharpCodeV8_ReturnsCorrectCode()
    {
        // Arrange
        _themeStateService.ThemeName = "Custom Theme";
        await _themeStateService.UpdateThemeData(new List<CustomTypography> 
        { 
            new() { TypoType = "H1", Name = "FontSize", Default = "6rem", DataType = "String" }
        });

        // Act
        var code = _themeStateService.GenerateCSharpCodeV8();

        // Assert
        Assert.That(code, Does.Contain("public static readonly MudTheme ThemeTheme = new()"));
        Assert.That(code, Does.Contain("Typography = new Typography()"));
        Assert.That(code, Does.Contain("H1Typography = new H1Typography"));
        Assert.That(code, Does.Contain("FontSize = \"6rem\""));
    }
}
