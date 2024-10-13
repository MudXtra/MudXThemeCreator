using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThemeCreatorMudBlazor.DAL.Extensions;

namespace ThemeCreatorMudBlazor.DAL.Models
{
    public class ThemeSelection
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CustomThemeId { get; set; }
        public int OrderPriority { get; set; }
        public int? ThemeOptionId { get; set; }
        [Required, StringLength(25)] public string ThemeName { get; set; } = default!;
        [Required, StringLength(25)] public string ThemeType { get; set; } = default!;
        [StringLength(25)] public string? LightValue { get; set; }
        [StringLength(25)] public string? DarkValue { get; set; }
        [Required, StringLength(25)] public string? CssVariable { get; set; } = default!;
        public string LightValueHex => ColorConverter.ToHexOrRgba(LightValue ?? string.Empty);
        public string DarkValueHex => ColorConverter.ToHexOrRgba(DarkValue ?? LightValue ?? string.Empty);
    }
}
