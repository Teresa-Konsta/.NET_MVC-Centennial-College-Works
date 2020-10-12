using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Models;
using Assignment1.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        public int PageSize = 10;

        public HomeController(IRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult RecipeList(int page = 1) =>
            View(new RecipeListViewModel
            {
                Recipes = repository.Recipes
                .OrderBy(r => r.RecipeID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    ItemsTotal = repository.Recipes.Count()
                }
            });

        [HttpGet]
        public ViewResult ViewRecipe(int id)
        {
            if(id == 0)
            {
                return View("RecipeList");
            }
            else
            {                
                return View(repository.Recipes.Where(r => r.RecipeID == id).ToList<Recipe>()); //.FirstOrDefault() was instead of ToList
            }
        }

        [HttpPost]
        public ViewResult ReviewRecipe(Recipe review)
        {
            if (ModelState.IsValid)
            {
                Repository.AddRecipeReviw(review);
                return View();
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ViewResult ReviewRecipe()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ViewResult AddRecipe(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRecipe(recipe);
                return View("RecipeSummary", recipe);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ViewResult AddRecipe()
        {
            return View();
        }
    }
}
