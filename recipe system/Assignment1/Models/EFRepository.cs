using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class EFRepository : IRepository
    {
        private ApplicationDbContext context;
        public EFRepository(ApplicationDbContext contx)
        {
            context = contx;
        }

        public IQueryable<Recipe> Recipes => context.Recipes;

        //stop here
        public void SaveRecipe (Recipe recipe)
        {
            if(recipe.RecipeID == 0)
            {
                context.Recipes.Add(recipe);
            }
            else
            {
                Recipe recipeEntry = context.Recipes.FirstOrDefault(r => r.RecipeID == recipe.RecipeID);
                if (recipeEntry != null)
                {
                    recipeEntry.RecipeName = recipe.RecipeName;
                    recipeEntry.Description = recipe.Description;
                    recipeEntry.Ingredients = recipe.Ingredients;
                    recipeEntry.Chef = recipe.Chef;
                    recipeEntry.PreparationTime = recipe.PreparationTime;
                }
            }
            context.SaveChanges();
        }

        public Recipe DeleteRecipe(int recipeID)
        {
            Recipe recipeEntry = context.Recipes.FirstOrDefault(r => r.RecipeID == recipeID);
            
            if(recipeEntry != null)
            {
                context.Recipes.Remove(recipeEntry);
                context.SaveChanges();
            }
            return recipeEntry;
        }
    }
}