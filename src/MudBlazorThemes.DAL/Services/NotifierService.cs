using MudBlazorThemes.DAL.Interfaces;

namespace MudBlazorThemes.DAL.Services
{
    public class NotifierService : INotifierService
    {
        private string _searchTerm = string.Empty; // Private backing field

        public string SearchTerm
        {
            get => _searchTerm;
            private set => _searchTerm = value; // Optional: private setter if needed internally
        }

        public event Action? OnChange;

        public void SetSearchTerm(string term)
        {
            SearchTerm = term;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
