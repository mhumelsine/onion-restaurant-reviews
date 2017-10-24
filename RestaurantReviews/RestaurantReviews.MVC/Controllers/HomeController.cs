using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantReviews.Core.Stores;
using RestaurantReviews.Infrastructure.Stores;
using RestaurantReviews.Core.DTOs;
using RestaurantReviews.Infrastructure.Factories;
using RestaurantReviews.Core.Logic.Managers;

namespace RestaurantReviews.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            IRestaurantManagerFactory factory = new RestaurantManagerFactory();
            RestaurantManager manager = factory.CreateInstance();

            Restaurant restaurant = new Restaurant
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Kool Beans Cafe",
                City = "Tallahassee",
                Country = "USA"
            };

            manager.AddRestaurant(restaurant);

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
