using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MudBlazorThemes.DAL.Interfaces;

namespace MudBlazorThemes.DAL.Models
{
    public class CustomLayoutProperty : ICustomThemeItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CustomThemeId { get; set; }
        [Required, StringLength(50)] public string Name { get; set; } = default!;
        public int Default { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        [Required, StringLength(50)] public string CssVariable { get; set; } = default!;
        public string DefaultPx
        {
            get
            {
                return $"{Default}px";
            }
        }

    }
}
