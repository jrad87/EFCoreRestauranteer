using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using EFCoreRestauranteer.Models;

namespace EFCoreRestauranteer.Controllers
{
    
    public class HomeController : Controller
    {
        private BasicDbContext Context;
        
        public HomeController(BasicDbContext Context)
        {
            this.Context = Context;
        }

        [HttpGet]
        [Route("")]
        [ImportModelState]
        public IActionResult Index()
        {
            ReviewViewModel viewModel = new ReviewViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [Route("")]
        [ExportModelState]
        public IActionResult SubmitReview(ReviewViewModel ViewModel)
        {
            Console.WriteLine(ModelState.IsValid);
            if(TryValidateModel(ViewModel))
            {
                this.Context.Add(new Review(ViewModel));
                this.Context.SaveChanges();
                return RedirectToAction("Index");
            }
            Console.WriteLine("Is bad model state");
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("reviews")]
        public IActionResult AllReviews()
        {
            return View("Reviews", this.Context.Reviews);
        }

        [HttpPost]
        [Route("helpful/{Id}")]
        public IActionResult VoteHelpful(int Id)
        {
            Review VotedReview = this.Context.Reviews.SingleOrDefault(review => review.Id == Id);
            VotedReview.HelpfulVotes += 1;
            this.Context.SaveChanges();
            return RedirectToAction("AllReviews");
        }

        [HttpPost]
        [Route("unhelpful/{Id}")]
        public IActionResult VoteUnhelpful(int Id)
        {
            Review VotedReview = this.Context.Reviews.SingleOrDefault(review => review.Id == Id);
            VotedReview.UnhelpfulVotes += 1;
            this.Context.SaveChanges();
            return RedirectToAction("AllReviews");
        }
    }
}
