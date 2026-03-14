using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Project.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "enter number between only 1 to 100")]

        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
