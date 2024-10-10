using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ThemeCreatorMudBlazor.DAL.Models;

namespace ThemeCreatorMudBlazor.DAL.Data
{
    /// <summary>
    /// Identify the descriptions of the Theme Selections if any are hard to understand adding an entry here will show it as a tooltip.
    /// </summary>
    public class SeedDescriptionData
    {
        public static Dictionary<int, string> SeedDescriptions()
        {
            var descriptions = new Dictionary<int, string>
            {
                // the key is the id of the theme selection
                // the value is the description of the theme selection
                {1, "Used in .mud-switch-track as the background of an uncolored MudSwitch"},
                {2, "Used as the default forecolor of the avatar component and stepper label icon"},
            };
            return descriptions;
        }
    }
}
