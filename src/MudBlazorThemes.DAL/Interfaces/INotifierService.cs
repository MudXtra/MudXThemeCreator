namespace MudBlazorThemes.DAL.Interfaces
{
    public interface INotifierService
    {
        string SearchTerm { get; }

        event Action? OnChange;

        void SetSearchTerm(string term);

    }
}
