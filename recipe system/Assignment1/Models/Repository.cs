using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Repository
    {
        //private static List<Recipe> recipes = new List<Recipe>();

        //public static List<Recipe> Recipes
        //{
        //    get
        //    {
        //        return recipes;
        //    }
        //}

        //public IQueryable<Recipe> Recipes => new List<Recipe>
        //{
        //new Recipe {
        //     RecipeName = "Classic chewy brownie",
        //     Description = "Preheat oven to 180C/160C fan forced. Grease a 20cm (base measurement) square cake pan and line with baking paper. Place butter and chocolate in a heatproof bowl over a saucepan of simmering water (don't let the bowl touch the water). Stir with a metal spoon until melted. Remove from heat. Quickly stir in egg, sugar, flour, cocoa powder, vanilla and salt until just combined. Pour into prepared pan. Bake for 30 minutes or until a skewer inserted in the centre comes out with moist crumbs clinging. Set aside to cool completely.",
        //     Ingredients = "125g unsalted butter, 125g dark chocolate, 3 eggs, 335g white sugar, 115g flour, 30g cocoa powder, 1 teaspoon vanilla extract, pinch of salt",
        //     Chef = "Alison Adams",
        //     PreparationTime = "1 h"}
        //}.AsQueryable<Recipe>();

        //public static void AddRecipe(Recipe recipe)
        //{
        //    recipes.Add(recipe);
        //}

        public static List<Recipe> recipeReviews = new List<Recipe>();

        public static void AddRecipeReviw(Recipe review)
        {
            recipeReviews.Add(review);
        }
    }
}
