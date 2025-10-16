using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudXtra.ThemeCreator.Infrastructure.Models
{
    public class ThemePalette
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; } = default!;
    }
}
