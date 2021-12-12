using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using CRUDelicious.Models.Home;
using System.Linq;
using System;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller    
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public ViewResult Index()
        {
            IndexView ViewModel = new IndexView
            {
                AllChefs = _context.Chefs
                .Include(food => food.CreatedDishes)
                .ToList()
            };
            return View(ViewModel);
        }
        [HttpGet("/dishes")]
        public ViewResult AllDishes()
        {
            IndexView ViewModel = new IndexView
            {
                AllDishes = _context.Dishes
                .Include(cook => cook.Chef)
                .ToList()
            };
            return View(ViewModel);
        }

        [HttpGet("chef/new")]
        public IActionResult NewChef()
        {
            return View();
        }
        [HttpGet("dish/new")]
        public IActionResult NewDish()
        {
            Dish Form = new Dish()
            {
                AvailableChefs = _context.Chefs.ToList()
            };

            return View(Form);
        }

        [HttpPost("create/chef")]
        public IActionResult CreateChef(Chef fromForm)
        {
            if(ModelState.IsValid)
            {
                _context.Add(fromForm);
                _context.SaveChanges();
                
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewChef");
            }
        }
        [HttpPost("create/dish")]
        public IActionResult CreateDish(Dish fromForm)
        {
            if(ModelState.IsValid)
            {
                _context.Add(fromForm);
                _context.SaveChanges();
                
                return RedirectToAction("AllDishes");
            }
            else
            {
                return View("NewDish");
            }
        }
        
        // [HttpGet("/{dishId}")]
        // public IActionResult GetOne(int dishId)
        // {
        //     Dish toRender = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

        //     return View(toRender);
        // }
        // [HttpGet("/edit/{dishId}")]
        // public IActionResult EditDish(int dishId)
        // {
        //     Dish toEdit = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
        //     if(toEdit == null)
        //     {
        //         return RedirectToAction("Index");
        //     }
        //     else
        //     {
        //         return View("EditDish", toEdit);
        //     }
        // }
        // [HttpPost("/update/{dishId}")]
        // public IActionResult UpdateDish(Dish fromForm, int dishId)
        // {
        //     if(ModelState.IsValid)
        //     {
        //         Dish inDatabase = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

        //         inDatabase.Name = fromForm.Name;
        //         inDatabase.Chef = fromForm.Chef;
        //         inDatabase.Tastiness = fromForm.Tastiness;
        //         inDatabase.Calories = fromForm.Calories;
        //         inDatabase.Description = fromForm.Description;
        //         inDatabase.UpdatedAt = DateTime.Now;
                
        //         _context.SaveChanges();

        //         return RedirectToAction("GetOne", new {dishId = dishId});
        //     }
        //     else
        //     {
        //         return EditDish(dishId);
        //     }
        // }
        // [HttpGet("/delete/{dishId}")]
        // public RedirectToActionResult DeleteDish(int dishId)
        // {
        //     Dish toDelete = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

        //     _context.Dishes.Remove(toDelete);
        //     _context.SaveChanges();

        //     return RedirectToAction("Index");
        // }
    }
}