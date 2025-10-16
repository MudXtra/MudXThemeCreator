using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudXtra.ThemeCreator.Infrastructure.Models
{
    public class CustomTheme
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; } = default!;

        public DateTime CreatedWhen { get; set; }
        public bool IsApproved { get; set; } = true;
        public bool IsActive { get; set; } = false;
        [Required, StringLength(199)]
        public string OtherText { get; set; } = string.Empty;

        public string? UploadedBy { get; set; }
    }
}
