using MudBlazor;

namespace MudXtra.ThemeCreator.UI.Extensions;

public static class VersionExtensions
{
    /// <summary>
    /// Return the current MudBlazor version
    /// </summary>
    public static string MudBlazorVersion => typeof(MudButton).Assembly.GetName().Version?.ToString() ?? string.Empty;

    /// <summary>
    /// Return the current MudX version
    /// </summary>
    public static string MudXVersion => typeof(MudX.CodeFile).Assembly.GetName().Version?.ToString() ?? string.Empty;
}
