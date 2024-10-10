using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace ThemeCreatorMudBlazor.UI.Components
{
    public partial class ThemeCreatorSpinner<T> : ComponentBase
    {

        [Parameter] public List<T> SpinnerList { get; set; } = [];
        [Parameter] public int SpinnerIndex { get; set; }
        [Parameter] public EventCallback<int> SpinnerIndexChanged { get; set; }

        public string SelectedIndex { get; set; } = string.Empty;

        private async Task HandleKeyDown(KeyboardEventArgs e)
        {
            if (e.Key == "ArrowUp" && SpinnerIndex > 0)
            {
                await ChangeSpinnerIndex(-1);
            }
            else if (e.Key == "ArrowDown" && SpinnerIndex < SpinnerList.Count - 1)
            {
                await ChangeSpinnerIndex(1);
            }
        }

        private async Task SetSpinnerIndex(int newVal)
        {
            SpinnerIndex = newVal;
            await SpinnerIndexChanged.InvokeAsync(SpinnerIndex);
        }

        private async Task ChangeSpinnerIndex(int delta)
        {
            int newIndex = Math.Clamp(SpinnerIndex + delta, 0, SpinnerList.Count - 1);
            if (newIndex != SpinnerIndex)
            {
                SpinnerIndex = newIndex;
                await SpinnerIndexChanged.InvokeAsync(SpinnerIndex);
            }
        }
    }
}
