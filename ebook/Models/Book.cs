using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ebook.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BookId { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public string BookCode { get; set; }

        [Required]
        public string BookDescription { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public BookCategory Category { get; set; }

        [Required]
        public BookType Type { get; set; }

        [Required]
        public BookOption Option { get; set; }

        [Required]
        public float Rate { get; set; }

        [Required]
        public float Discount { get; set; }
    }

    public enum BookCategory
    {
        [Display(Name = "Fiction")]
        Fiction,
        [Display(Name = "Sci-Fi")]
        SciFi,
        [Display(Name = "Horror")]
        Horror,
        [Display(Name = "Personality Development")]
        PersonalityDevelopment,
        [Display(Name = "Reference")]
        Reference,
        [Display(Name = "Novel")]
        Novel,
        [Display(Name = "Comic")]
        Comic,
        [Display(Name = "Kids Books")]
        Kids
    }

    public enum BookType
    {
        [Display(Name = "E-Book")]
        EBook,
        [Display(Name = "Hard Copy")]
        HardCopy
    }

    public enum BookOption
    {
        [Display(Name = "Rent")]
        Rent,
        [Display(Name = "Buy")]
        Buy
    }
}