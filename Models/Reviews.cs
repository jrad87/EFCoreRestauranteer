using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EFCoreRestauranteer.Models
{
    public class Review
    {
        public int Id {get; set;}
        public int Rating {get; set;}
        public string RestaurantName {get; set;}
        public string ReviewerName {get; set;}
        public string Text {get; set;}
        public int HelpfulVotes {get; set;}
        public int UnhelpfulVotes {get; set;}
        public DateTime DateVisited {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
        public Review()
        {}

        public Review(ReviewViewModel vm)
        {
            this.Rating = vm.Rating;
            this.RestaurantName = vm.RestaurantName;
            this.ReviewerName = vm.ReviewerName;
            this.Text = vm.Text;
            this.DateVisited = DateTime.Parse(vm.DateVisited);
            this.HelpfulVotes = 0;
            this.UnhelpfulVotes = 0;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
    }
    public class ReviewViewModel
    {
        [Required(ErrorMessage = "A rating is required")]
        [Range(1, 5)]
        public int Rating {get; set;}
        [Display(Name = "Restaurant Name")]
        [Required(ErrorMessage = "Restaurant name is required")]
        [MaxLength(45)]
        public string RestaurantName {get; set;}
        [Display(Name = "Reviewer Name")]
        [Required(ErrorMessage = "Your name is required")]
        [MaxLength(45)]
        public string ReviewerName {get; set;}
        [Required(ErrorMessage = "Review text is required")]
        public string Text {get; set;}
        [Display(Name = "Date Visited")]
        [Required(ErrorMessage = "Date of visit is required")]
        [RegularExpression(@"^\d{2}\/\d{2}\/\d{4}$", ErrorMessage = "Must enter a valid date")]
        public string DateVisited {get; set;}
    }
}