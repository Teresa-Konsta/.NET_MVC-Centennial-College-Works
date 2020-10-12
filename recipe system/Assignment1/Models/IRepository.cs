using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public interface IRepository
    {
       IQueryable<Recipe> Recipes { get; }
        void SaveRecipe(Recipe recipe);
        Recipe DeleteRecipe(int recipeID);
    }
}
