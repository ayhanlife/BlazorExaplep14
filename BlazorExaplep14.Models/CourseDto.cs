using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExaplep14.Models
{
    public class CourseDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Boş olamaz")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Boş olamaz")]
        public decimal CoursePrice { get; set; } = 0;
        [Required(ErrorMessage = "Boş olamaz")]
        public bool IsActive { get; set; } = false;
        [Required(ErrorMessage = "Boş olamaz")]
        public string Title { get; set; } = string.Empty;
        public string SubTitle { get; set; } = string.Empty;
        public double RegularRate { get; set; } = 0;
        public string Details { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CretedDate { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
