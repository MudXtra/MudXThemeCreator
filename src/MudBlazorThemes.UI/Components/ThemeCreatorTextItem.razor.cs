using Microsoft.AspNetCore.Components;

namespace MudBlazorThemes.UI.Components
{
    public partial class ThemeCreatorTextItem : ComponentBase
    {
        private bool _isOpen;
        private bool _hasBeenOpened;
        private string origText = string.Empty;

        [Parameter]
        public string? Name { get; set; }
        [Parameter]
        public string Text { get; set; } = default!;
        [Parameter]
        public EventCallback<string> TextChanged { get; set; }

        protected override void OnParametersSet()
        {
            origText = Text;
        }

        protected override bool ShouldRender()
        {
            return !_isOpen || _hasBeenOpened;
        }

        private bool IsDisabled => origText == Text;

        public void ToggleOpen()
        {
            _isOpen = !_isOpen;
            if (_isOpen && !_hasBeenOpened)
            {
                _hasBeenOpened = true;
            }
            StateHasChanged();
        }

        public async Task UpdateText()
        {
            await TextChanged.InvokeAsync(origText);
            ToggleOpen();
        }
    }
}
