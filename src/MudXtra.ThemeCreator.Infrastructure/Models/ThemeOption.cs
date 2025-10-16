using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudXtra.ThemeCreator.Infrastructure.Models
{
    public class ThemeOption
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; } = default!;
        public bool IsActive { get; set; } = true;
    }
}
