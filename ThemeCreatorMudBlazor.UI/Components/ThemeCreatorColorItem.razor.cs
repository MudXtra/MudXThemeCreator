using System.Timers;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using MudBlazor.Extensions;
using MudBlazor.Extensions.Core;
using MudBlazor.Extensions.Options;
using MudBlazor.Utilities;
using Nextended.Core.Extensions;
using ThemeCreatorMudBlazor.DAL.Services;

namespace ThemeCreatorMudBlazor.UI.Components
{
    public partial class ThemeCreatorColorItem : ComponentBase, IDisposable
    {
        private bool _isOpen;
        private ColorPickerView _view = ColorPickerView.Spectrum;
        private readonly DialogOptionsEx _dialogOptions = new()
        { CloseOnEscapeKey=true, BackdropClick=true, Position=DialogPosition.Center, 
              CloseButton=false, Animations = [AnimationType.Pulse], DragMode= MudDialogDragMode.WithoutBounds };

        [Parameter]
        public string? Name { get; set; }
        [Parameter]
        public string? ToolTipText { get; set; }

        [Parameter]
        public string? DefaultColor { get; set; }
        [Parameter]
        public EventCallback<MudColor> ColorChanged { get; set; }
        [Inject]
        public IJSRuntime JsRuntime { get; set; } = default!;
        [Inject]
        public StyleService StyleService { get; set; } = default!;

        public MudColor ThemeColor { get; set; } = new MudColor();
        private readonly System.Timers.Timer debounceTimer = new(150);
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
        protected override void OnInitialized()
        {
            debounceTimer.Elapsed += OnDebounceElapsed;
            debounceTimer.AutoReset = false;
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                initialPrimary = await StyleService.GetComputedStylePropertyAsync("--mud-palette-primary");
                initialSecondary = await StyleService.GetComputedStylePropertyAsync("--mud-palette-secondary");
                initialTertiary = await StyleService.GetComputedStylePropertyAsync("--mud-palette-tertiary");
            }
        }

        private async Task CopyColor()
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", ThemeColor.ToString());
                ShowNotification("Color copied to clipboard", Severity.Info, copyColorSnackbarChip);
            }
            catch
            {
                ShowNotification("Failed to copy color to clipboard", Severity.Error, copyColorSnackbarChip);
            }
        }

        private void CopyFrom(string colorType)
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
            } catch 
            { 
                ShowNotification("Failed paste from " + StringExtensions.ToUpper(colorType, true), Severity.Warning, chip); 
            }

            if (result)
            {
                ThemeColor = mudColor;
                lastColor = mudColor;
                debounceTimer?.Stop();
                debounceTimer?.Start();
                ShowNotification("Color pasted from " + StringExtensions.ToUpper(colorType, true), Severity.Info, chip);
                StateHasChanged();
            }            
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
                    debounceTimer?.Stop();
                    debounceTimer?.Start();
                    ShowNotification("Color pasted from clipboard", Severity.Info, pasteColorSnackbarChip);
                }
                catch
                {
                    ShowNotification("Failed to paste color from clipboard", Severity.Error, pasteColorSnackbarChip);
                }
            }

        }

        private void ShowNotification(string message, Severity severity, SnackbarChip chip)
        {
            chip.ShowSnackbarChip(message, severity);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                debounceTimer.Elapsed -= OnDebounceElapsed;
                debounceTimer.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected override void OnParametersSet()
        {
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

        private async void OnDebounceElapsed(object? sender, ElapsedEventArgs e)
        {
            await InvokeAsync(async () =>
            {
                ArgumentNullException.ThrowIfNull(lastColor); // should never be null.
                await ColorChanged.InvokeAsync(lastColor);
            });
        }

        public void ToggleOpen()
        {
            _isOpen = !_isOpen;
            if (_isOpen && DefaultColor != null)
            {
                firstOpenedColor = new MudColor(DefaultColor);
            }
        }

        private async Task CancelOpen()
        {
            _isOpen = false;
            StateHasChanged();
            await Task.Delay(1);
            await ColorChanged.InvokeAsync(firstOpenedColor);
        }

        public void UpdateColor(MudColor value)
        {
            ThemeColor = value;
            lastColor = value;
            debounceTimer?.Stop();
            debounceTimer?.Start();
        }
    }
}