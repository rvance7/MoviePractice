using System;
using System.ComponentModel.DataAnnotations;

//model for the movies to be entered
namespace Assignment3.Models
{
    public class MoviesResponse
    {
        [Key]
        public long MovieID { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool? Edited { get; set; }

        public string LentTo { get; set; }

        [StringLength(25, ErrorMessage ="Limit is 25 characters")]
        public string Notes { get; set; }

    }

}
