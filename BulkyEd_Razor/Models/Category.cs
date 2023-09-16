using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyEd_Razor.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="Name is Required Field")]
        [DisplayName("Category Name")]
        public required string CategoryName { get; set; }
        [Range(1,100)]
        [DisplayName("Display Order")]
        [Required(ErrorMessage ="This Field is Required")]
        public int CaregoryOrder { get; set; }
    }
}
