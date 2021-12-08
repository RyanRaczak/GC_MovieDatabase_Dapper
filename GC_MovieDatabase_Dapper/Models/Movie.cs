using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GC_MovieDatabase_Dapper.Models
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MinLength(1, ErrorMessage ="Title must have at least 1 character")]
        [MaxLength(30, ErrorMessage ="Title can be no longer then 30 characters.")]
        public string Title { get; set; }

        [Required]
        public Category Genre { get; set; }

        [Required]
        [Range(1880,2021, ErrorMessage ="Must be between year 1880 and 2021")]
        public int Year { get; set; }

        [Required]
        public int Runtime { get; set; }

    }
    public enum Category
    {
        Animation,
        Horror,
        Drama,
        Action,
        Comedy
    }
}
