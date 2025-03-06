using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudBlazorThemes.DAL.Models
{
    public class MappedCssVariables
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MappedThemeId { get; set; }
        public string NativeCssVariable { get; set; } = default!;
        public string MappedCssVariable { get; set; } = default!;
    }
}
