using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Assignment1.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IRepository repository;

        public AdminController(IRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Recipes); //option 1 if to use List (repository.Recipes.ToList<Recipe>());
        }

        public ViewResult Edit(int recipeId) => View(repository.Recipes.FirstOrDefault(r => r.RecipeID == recipeId));
    
        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            if(ModelState.IsValid)
            {
                repository.SaveRecipe(recipe);
                TempData["message"] = $"{recipe.RecipeName} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(recipe);
            }
        }

        public ViewResult Create() => View("Edit", new Recipe());
    
        [HttpPost]
        public IActionResult Delete(int recipeID)
        {
            Recipe deletedRecipe = repository.DeleteRecipe(recipeID);
            if(deletedRecipe != null)
            {
                TempData["message"] = $"{deletedRecipe.RecipeName} was removed";
            }
            return RedirectToAction("Index");
        }
    }
}
