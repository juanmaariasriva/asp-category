using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Nombre")]
        public String Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDatetime { get; set; } = DateTime.Now;
    }
}
