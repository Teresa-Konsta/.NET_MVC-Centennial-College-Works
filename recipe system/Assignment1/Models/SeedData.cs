using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Assignment1.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(
                    new Recipe
                    {
                        RecipeName = "Angry bean salad",
                        Description = "Carefully plunge the tomatoes into a pan of fast-boiling salted water for exactly 30 seconds, scoop out with a sieve and run under cold water. Line up the beans, remove just the stalk ends and place in the boiling water for 4 minutes. Meanwhile, pick the mint leaves, putting the baby leaves aside for garnish. Peel the garlic, then finely slice with the chillies. Pinch and peel away the tomato skins, reserving the flesh (it’s a bit of a faff, but it’s worth it). Drain the beans, placing the pan back on a medium heat.Drizzle in 1 tablespoon of oil, then add the garlic, chilli and mint leaves.Fry for 2 minutes, add the tomatoes, vinegar and beans and simmer for 4 minutes, stirring regularly to break up the tomatoes.Taste and season to absolute perfection with sea salt and black pepper, then spoon on to a platter along with any tasty juices. Scatter over the mozzarella and reserved mint leaves, and serve with hot toast.",
                        Ingredients = "400 g cherry tomatoes, 400 g beans, 4 sprigs of mint, 4 cloves of garlic, 2 chillies, olive oil, 3 tablespoons red wine vinegar, 8 bocconcini mozzarella, 4 slices of rustic bread",
                        Chef = "Jamie Oliver",
                        PreparationTime = "20 min"
                    });
            }
            context.SaveChanges();
        }
    }
}