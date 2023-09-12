using BulkyWeb.Controllers;
using BulkyWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [DisplayName("Catagory Name")]
        [StringLength(25)]
        public required string Name { get; set; }

        [DisplayName("Display order")]
        [Range(1, 1000,ErrorMessage ="Valid Range 1 to 1000")]
        public int CategoryOrder { get; set; }
    }
}
