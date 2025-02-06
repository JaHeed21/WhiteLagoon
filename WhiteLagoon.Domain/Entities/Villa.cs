using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteLagoon.Domain.Entities
{
    public class Villa
    {
        public int Id { get; set; }
        [MaxLength(65)]
        [Required(ErrorMessage = "Name can not be Empty")]
        public   string Name { get; set; }
        public string? Description { get; set; }
        [Display(Name ="Price Per Night")]
        [Range(10, 1000)]
        [Required(ErrorMessage = "Price can not be Empty")]
        public double? Price { get; set; }
        [Required]
        public int? Sqft { get; set; }
        [Range(1,10)]
        [Required(ErrorMessage = "Occupancy can not be Empty")]
        public int? Occupancy { get; set; }
        [Display(Name ="Image Url")]
        public string? ImageUrl { get; set; }
        public DateTime? Created_Date { get; set; }
        public DateTime? Updated_Date { get; set; }

    }
}
