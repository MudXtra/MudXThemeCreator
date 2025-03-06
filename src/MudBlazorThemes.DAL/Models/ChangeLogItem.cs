namespace MudBlazorThemes.DAL.Models
{
    public record ChangeLogItem(DateTime ChangeWhen, string ChangeWhat, string ChangeWhy, string ChangeWho)
    {
    }
}
