using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeCreatorMudBlazor.DAL.Models
{
    public record ChangeLogItem(DateTime ChangeWhen, string ChangeWhat, string ChangeWhy, string ChangeWho)
    {
    }
}
