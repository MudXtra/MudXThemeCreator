namespace MudBlazorThemes.DAL.Models
{
    public class ThemeDTO
    {
        public CustomTheme? CustomTheme { get; set; }
        public List<ThemeSelection> ThemeSelections { get; set; } = [];
        public List<CustomLayoutProperty> CustomLayoutProperties { get; set; } = [];
        public List<CustomShadow> CustomShadows { get; set; } = [];
        public List<CustomTypography> CustomTypographies { get; set; } = [];
        public List<CustomZIndex> CustomZIndices { get; set; } = [];
    }
}
