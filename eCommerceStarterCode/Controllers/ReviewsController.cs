using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eCommerceStarterCode.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private ApplicationDbContext _context;
        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetReviews()
        {
            //Gets all reviews from the database
            var reviews = _context.Reviews.Include(r => r.Product);
            return Ok(reviews);
        }
        [HttpGet("{productId}")]
        public IActionResult GetReviewsbyId(int productId)
        {
            //Get reviews by Id from the database
            var reviews = _context.Reviews.Include(r => r.Product).Where(r => r.Product.Id == productId);
            //int numberOfRatings = reviews.ToList().Count();
            //if (numberOfRatings == 0)
            //{
            //    List<string> noReviews = new List<string>();
            //    noReviews.Add("This product has no reviews.");

            //    return Ok(noReviews);
            //}
            //else
            //{
                return Ok(reviews);
            //}
        }
        [HttpGet("average/{productId}")]
        public IActionResult GetAverageReviewsbyId(int productId)
        {
            //Get average
            var reviews = _context.Reviews.Include(r => r.Product).Where(r => r.Product.Id == productId);
            decimal total = 0;
            foreach (var review in reviews)
            {
                decimal rating = review.Rating;
                total += rating;
            }
            int numberOfRatings = reviews.ToList().Count();
            decimal ratings = numberOfRatings;
            if (numberOfRatings == 0)
            {
                string noReviews = "This product has no reviews.";
                return Ok(noReviews);
            }
            else
            {
                decimal average = total / numberOfRatings;
                decimal roundedAverage = Math.Round(average, 2);
                string final = roundedAverage + "/5";
                return Ok(final);
            }
        }
        [HttpPost, Authorize]
        public IActionResult PostReview([FromBody] Review value)
        {
            _context.Reviews.Add(value);
            _context.SaveChanges();
            //return StatusCode(201, value);
            return Ok(value);
        }
    }
}
