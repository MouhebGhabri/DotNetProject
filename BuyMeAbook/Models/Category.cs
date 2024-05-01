using System.ComponentModel.DataAnnotations;

namespace BuyMeAbook.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } //make Id att as a primary column   at the table
        [Required]
        public String Name { get; set; } //make the name required
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now; //default value

    }
}
