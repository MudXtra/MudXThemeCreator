using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MudXtra.ThemeCreator.Infrastructure.Interfaces;

namespace MudXtra.ThemeCreator.Infrastructure.Models
{
    public class CustomShadow : ICustomThemeItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Index { get; set; }
        public int CustomThemeId { get; set; }
        [Required, StringLength(50)] public string Name { get; set; } = default!;
        [Required, StringLength(125)] public string Default { get; set; } = default!;
        [Required, StringLength(50)] public string CssVariable { get; set; } = default!;

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (!string.IsNullOrEmpty(Name))
            {
                stringBuilder.Append(Name);
            }
            stringBuilder.Append($" - {Index}");
            return stringBuilder.ToString();
        }
    }
}
