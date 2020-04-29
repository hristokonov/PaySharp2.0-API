using System;
using System.ComponentModel.DataAnnotations;

namespace PaySharp.API.Dal.Models
{
    public class Banner
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string ImgPath { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
