using System.ComponentModel.DataAnnotations;

namespace MudXtra.ThemeCreator.Infrastructure.Models
{
    public class UserMax
    {
        [Key]
        public string UserName { get; set; } = default!;
        public int MaxThemes { get; set; }
    }
}
