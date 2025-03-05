using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using MudBlazor;
using MudBlazor.Utilities;
using MudBlazorThemes.DAL.Services;
using Nextended.Core.Extensions;

namespace MudBlazorThemes.UI.Components
{
    public partial class ThemeCreatorColorItem : ComponentBase
    {
        private bool _isOpen;
        private bool _saveClose;
        private ColorPickerView _view = ColorPickerView.Spectrum;

        private DialogOptions _dialogOptions { get; set; } = new()
        {
            CloseOnEscapeKey = true,
            BackdropClick = true,
            Position = DialogPosition.Center,
            CloseButton = false,
        };

        [CascadingParameter(Name = "IsDarkTheme")]
        public bool IsDarkTheme { get; set; }

        private string DarkThemeBorder = "#fff";

        [Parameter]
        public string? Name { get; set; }

        [Parameter]
        public string? DefaultColor { get; set; }
        [Parameter]
        public EventCallback<MudColor> ColorChanged { get; set; }
        [Inject]
        public IJSRuntime JsRuntime { get; set; } = default!;
        [Inject]
        public StyleService StyleService { get; set; } = default!;

        public MudColor ThemeColor { get; set; } = new MudColor();
        private MudColor? lastColor;
        private MudColor firstOpenedColor = new();

        private SnackbarChip primaryColorSnackbarChip = default!;
        private SnackbarChip secondaryColorSnackbarChip = default!;
        private SnackbarChip tertiaryColorSnackbarChip = default!;
        private SnackbarChip copyColorSnackbarChip = default!;
        private SnackbarChip pasteColorSnackbarChip = default!;
        private string initialPrimary = string.Empty;
        private string initialSecondary = string.Empty;
        private string initialTertiary = string.Empty;

        private async Task CopyColor()
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", ThemeColor.ToString(MudColorOutputFormats.HexA));
                ShowNotification("Color copied to clipboard", Severity.Info, copyColorSnackbarChip);
            }
            catch
            {
                ShowNotification("Failed to copy color to clipboard", Severity.Error, copyColorSnackbarChip);
            }
        }

        private async Task CopyFrom(string colorType)
        {
            string colorValue = colorType switch
            {
                "primary" => initialPrimary,
                "secondary" => initialSecondary,
                "tertiary" => initialTertiary,
                _ => string.Empty
            };
            SnackbarChip chip = colorType switch
            {
                "primary" => primaryColorSnackbarChip,
                "secondary" => secondaryColorSnackbarChip,
                "tertiary" => tertiaryColorSnackbarChip,
                _ => default!
            };
            bool result = false;
            MudColor mudColor = new();
            try
            {
                mudColor = new MudColor(colorValue);
                result = true;
            }
            catch
            {
                ShowNotification("Failed paste from " + StringExtensions.ToUpper(colorType, true), Severity.Warning, chip);
            }

            if (result)
            {
                ThemeColor = mudColor;
                lastColor = mudColor;
                await UpdateColorAsync();
                ShowNotification("Color pasted from " + StringExtensions.ToUpper(colorType, true), Severity.Info, chip);
                StateHasChanged();
            }
        }

        private async Task UpdateColorAsync()
        {
            await InvokeAsync(async () =>
            {
                ArgumentNullException.ThrowIfNull(lastColor); // should never be null.
                await ColorChanged.InvokeAsync(lastColor);
            });
        }

        private async Task PasteColor()
        {
            var pastedColor = await JsRuntime.InvokeAsync<string>("navigator.clipboard.readText");

            if (!string.IsNullOrEmpty(pastedColor))
            {
                try
                {
                    MudColor mudColor = new(pastedColor);
                    ThemeColor = mudColor;
                    lastColor = mudColor;
                    await UpdateColorAsync();
                    ShowNotification("Color pasted from clipboard", Severity.Info, pasteColorSnackbarChip);
                }
                catch
                {
                    ShowNotification("Failed to paste color from clipboard", Severity.Error, pasteColorSnackbarChip);
                }
            }

        }

        private static void ShowNotification(string message, Severity severity, SnackbarChip chip)
        {
            chip.ShowSnackbarChip(message, severity);
        }

        protected override void OnParametersSet()
        {
            DarkThemeBorder = IsDarkTheme ? "#fff" : "#000";
            if (DefaultColor == null)
                return;
            try
            {
                MudColor mudColor = new(DefaultColor);
                ThemeColor = mudColor;
            }
            catch { }
            Name ??= string.Empty;
        }

        private async Task SaveAndClose()
        {
            _saveClose = true;
            await ToggleOpen();
        }

        private void ViewChanged(ColorPickerView value)
        {
            _view = value;
            InvokeAsync(StateHasChanged);
        }

        private async Task ToggleOpen()
        {
            _isOpen = !_isOpen;
            if (_isOpen && DefaultColor != null)
            {
                firstOpenedColor = new MudColor(DefaultColor);
                var mudInitialPrimary = new MudColor(await StyleService.GetComputedStylePropertyAsync("--mud-palette-primary"));
                initialPrimary = mudInitialPrimary.ToString(MudColorOutputFormats.HexA);
                var mudInitialSecondary = new MudColor(await StyleService.GetComputedStylePropertyAsync("--mud-palette-secondary"));
                initialSecondary = mudInitialSecondary.ToString(MudColorOutputFormats.HexA);
                var mudInitialTertiary = new MudColor(await StyleService.GetComputedStylePropertyAsync("--mud-palette-tertiary"));
                initialTertiary = mudInitialTertiary.ToString(MudColorOutputFormats.HexA);
            }
        }

        private async Task CancelOpen()
        {
            _isOpen = false;
            // if it wasn't told to close by the save button revert changes
            if (!_saveClose)
                await ColorChanged.InvokeAsync(firstOpenedColor);
        }

        public void UpdateColor(MudColor value)
        {
            ThemeColor = value;
            lastColor = value;
        }

        private async Task OnMouseDown(MouseEventArgs e)
        {
            // add a mouseup event to update the color when the user releases the mouse button
            await JsRuntime.InvokeVoidAsync("attachMouseUp", DotNetObjectReference.Create(this));
        }

        [JSInvokable]
        public async void OnMouseUp()
        {
            await UpdateColorAsync();
        }
    }
}
