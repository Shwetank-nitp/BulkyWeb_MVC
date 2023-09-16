using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Models.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage="Category name is required")]
        [DisplayName("Category Name")]
        public required string Name { get; set; }
        [DisplayName("Category order")]
        [Required(ErrorMessage = "Category order is required")]
        [Range(1,1000)]
        public int CategoryOrder { get; set; }
    }
}
