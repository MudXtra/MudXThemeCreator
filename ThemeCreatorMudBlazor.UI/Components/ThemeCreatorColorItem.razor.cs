using System.Timers;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using MudBlazor.Utilities;

namespace ThemeCreatorMudBlazor.UI.Components
{
    public partial class ThemeCreatorColorItem : ComponentBase, IDisposable
    {
        private bool _isOpen;
        private bool _hasBeenOpened;
        private ColorPickerView _view = ColorPickerView.Spectrum;

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

        public MudColor ThemeColor { get; set; } = new MudColor();
        private readonly System.Timers.Timer debounceTimer = new(150);
        private MudColor? lastColor;
        private MudColor firstOpenedColor = new MudColor();
        private MudPopover? popoverRef;
        private Color sampleColor = Color.Default;
        private string sampleText = string.Empty;
        private bool sampleDisabled = false;
        private bool sampleHidden = false;

        private string messageToShow = string.Empty;
        private Severity messageSeverity = Severity.Info;
        protected override void OnInitialized()
        {
            debounceTimer.Elapsed += OnDebounceElapsed;
            debounceTimer.AutoReset = false;
        }

        private async Task CopyColor()
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", ThemeColor.ToString());
                ShowNotification("Color copied to clipboard", Severity.Info);
            }
            catch
            {
                ShowNotification("Failed to copy color to clipboard", Severity.Error);
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
                    ShowNotification("Color pasted from clipboard", Severity.Info);
                }
                catch
                {
                    ShowNotification("Failed to paste color from clipboard", Severity.Error);
                }
            }

        }

        private void ShowNotification(string message, Severity severity)
        {
            messageToShow = message;
            messageSeverity = severity;
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

        protected override bool ShouldRender() => !_isOpen || _hasBeenOpened;

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
            if (Name == null)
                Name = string.Empty;
            switch (Name)
            {
                case var s when s.Contains("primary", StringComparison.OrdinalIgnoreCase):
                    sampleColor = Color.Primary;
                    sampleText = "Primary";
                    break;
                case var s when s.Contains("secondary", StringComparison.OrdinalIgnoreCase):
                    sampleColor = Color.Secondary;
                    sampleText = "Secondary";
                    break;
                case var s when s.Contains("tertiary", StringComparison.OrdinalIgnoreCase):
                    sampleColor = Color.Tertiary;
                    sampleText = "Tertiary";
                    break;
                case var s when s.Contains("info", StringComparison.OrdinalIgnoreCase):
                    sampleColor = Color.Info;
                    sampleText = "Info";
                    break;
                case var s when s.Contains("success", StringComparison.OrdinalIgnoreCase):
                    sampleColor = Color.Success;
                    sampleText = "Success";
                    break;
                case var s when s.Contains("warning", StringComparison.OrdinalIgnoreCase):
                    sampleColor = Color.Warning;
                    sampleText = "Warning";
                    break;
                case var s when s.Contains("error", StringComparison.OrdinalIgnoreCase):
                    sampleColor = Color.Error;
                    sampleText = "Error";
                    break;
                case var s when s.Contains("dark", StringComparison.OrdinalIgnoreCase):
                    sampleColor = Color.Dark;
                    sampleText = "Dark";
                    break;
                case var s when s.Contains("disabled", StringComparison.OrdinalIgnoreCase):
                    sampleDisabled = true;
                    sampleText = "Disabled";
                    break;
                case var s when s.Contains("surface", StringComparison.OrdinalIgnoreCase):
                    sampleColor = Color.Surface;
                    sampleText = "Surface";
                    break;
                case var s when s.Contains("hover", StringComparison.OrdinalIgnoreCase):
                    sampleColor = Color.Default;
                    sampleText = "Hover";
                    break;
                case var s when s.Contains("ripple", StringComparison.OrdinalIgnoreCase):
                    sampleColor = Color.Default;
                    sampleText = "Ripple";
                    break;
                default:
                    sampleHidden = true;
                    break;
            }
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
            if (_isOpen && !_hasBeenOpened)
            {
                _hasBeenOpened = true;
            }
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