﻿using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAllReviews()
        {
            //Gets all reviews from the database
            var reviews = _context.Reviews.ToList();
            return Ok(reviews);
        }
        [HttpPost]
        public IActionResult PostReview([FromBody] Review value)
        {
            _context.Reviews.Add(value);
            _context.SaveChanges();
            //return StatusCode(201, value);
            return Ok(value);
        }
    }
}
