using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThemeCreatorMudBlazor.DAL.Interfaces;

namespace ThemeCreatorMudBlazor.DAL.Models
{
	public class CustomZIndex : ICustomThemeItem
    {
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int CustomThemeId { get; set; }
		[Required, StringLength(25)] public string Name { get; set; } = default!;
		[Required, StringLength(25)] public string Default { get; set; } = default!;
		[Required, StringLength(25)] public string CssVariable { get; set; } = default!;
	}
}
