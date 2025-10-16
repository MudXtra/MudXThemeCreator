using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MudBlazor.Utilities;

namespace MudXtra.ThemeCreator.Infrastructure.Models
{
    public class ThemeSelection
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CustomThemeId { get; set; }
        public int OrderPriority { get; set; }
        public int? ThemeOptionId { get; set; }
        [Required, StringLength(50)] public string ThemeName { get; set; } = default!;
        [Required, StringLength(50)] public string ThemeType { get; set; } = default!;
        [StringLength(50)] public string? LightValue { get; set; }
        [StringLength(50)] public string? DarkValue { get; set; }
        [Required, StringLength(50)] public string? CssVariable { get; set; } = default!;
        public string LightValueHex
        {
            get
            {
                return MudColor.TryParse(LightValue ?? string.Empty, out MudColor? s)
                    ? s.ToString(MudColorOutputFormats.HexA)
                    : "#00000000"; // Default to transparent if parsing fails
            }
        }

        public string DarkValueHex
        {
            get
            {
                return MudColor.TryParse(DarkValue ?? LightValue ?? string.Empty, out MudColor? s)
                    ? s!.ToString(MudColorOutputFormats.HexA)
                    : "#00000000"; // Default to transparent if parsing fails
            }
        }

    }
}
