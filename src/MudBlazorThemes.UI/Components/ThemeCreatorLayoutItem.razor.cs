using System.Timers;
using Microsoft.AspNetCore.Components;
using MudBlazorThemes.DAL.Models;

namespace MudBlazorThemes.UI.Components
{
    public partial class ThemeCreatorLayoutItem : ComponentBase, IDisposable
    {
        [Parameter]
        public CustomLayoutProperty LayoutProp { get; set; } = default!;
        [Parameter]
        public EventCallback<int> LayoutPropChanged { get; set; } = default!;

        private readonly System.Timers.Timer debounceTimer = new(300);
        private int lastSlider;

        protected override void OnInitialized()
        {
            debounceTimer.Elapsed += OnDebounceElapsed;
            debounceTimer.AutoReset = false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                debounceTimer.Elapsed -= OnDebounceElapsed;
                debounceTimer.Dispose();
            }
        }

        private async void OnDebounceElapsed(object? sender, ElapsedEventArgs e)
        {
            await InvokeAsync(async () =>
            {
                ArgumentNullException.ThrowIfNull(lastSlider); // should never be null.
                await LayoutPropChanged.InvokeAsync(lastSlider);
            });
        }

        private int GetStep()
        {
            if (LayoutProp.Max > 500)
                return 25;
            if (LayoutProp.Max >= 300)
                return 20;
            if (LayoutProp.Max >= 101)
                return 10;
            if (LayoutProp.Max >= 31)
                return 5;
            return 1;
        }

        private void OnLayoutPropertyChanged(int newVal)
        {
            LayoutProp.Default = newVal;
            lastSlider = newVal;
            debounceTimer?.Stop();
            debounceTimer?.Start();
        }
    }
}
