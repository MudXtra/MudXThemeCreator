using System.Timers;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ThemeCreatorMudBlazor.UI.Components
{
    public partial class ThemeCreatorNumberItem<T> : ComponentBase where T : struct
    {
        private bool _isOpen = false;
        private bool _hasBeenOpened = false;        
        private T origValue;

        [Parameter]
        public string? Name { get; set; }
        [Parameter]
        public T Value { get; set; } = default!;
        [Parameter]
        public EventCallback<T> ValueChanged { get; set; }
        [Parameter]
        public T Min { get; set; }
        [Parameter]
        public T Max { get; set; }
        [Parameter]
        public T Step { get; set; }

        protected override void OnParametersSet()
        {
            origValue = Value;
        }

        public void ToggleOpen()
        {
            _isOpen = !_isOpen;
            if (_isOpen && !_hasBeenOpened)
            {
                _hasBeenOpened = true;
            }
            StateHasChanged();
        }

        private bool IsDisabled() => Value.Equals(origValue);

        private async Task UpdateNumber()
        {
            await ValueChanged.InvokeAsync(origValue);
            ToggleOpen();
        }
    }
}
