using System.ComponentModel.DataAnnotations;

namespace MudBlazorThemes.DAL.Models
{
    public class UserMax
    {
        [Key]
        public string UserName { get; set; } = default!;
        public int MaxThemes { get; set; }
    }
}
