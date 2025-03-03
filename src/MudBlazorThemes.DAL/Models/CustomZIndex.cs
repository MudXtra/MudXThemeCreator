using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MudBlazorThemes.DAL.Interfaces;

namespace MudBlazorThemes.DAL.Models
{
    public class CustomZIndex : ICustomThemeItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CustomThemeId { get; set; }
        [Required, StringLength(50)] public string Name { get; set; } = default!;
        [Required, StringLength(50)] public string Default { get; set; } = default!;
        [Required, StringLength(50)] public string CssVariable { get; set; } = default!;
    }
}
