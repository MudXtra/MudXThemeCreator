using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThemeCreatorMudBlazor.DAL.Models
{
    public class MappedTheme
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(25)]
        public string Name { get; set; } = default!;

    }
}
