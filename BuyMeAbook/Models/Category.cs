using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BuyMeAbook.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } //make Id att as a primary column   at the table
        [Required]
        public String Name { get; set; } //make the name required
        [DisplayName("Display Order")] //to custom display we add Space between y and O
        [Range(1,100,ErrorMessage ="Display Order must be between 1 and 100 only !!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now; //default value

    }
}
