using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        [Required(ErrorMessage = "Enter recipe name")]
        public string RecipeName { get; set; }
        [Required(ErrorMessage = "Enter description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter ingredients")]
        public string Ingredients { get; set; }
        [Required(ErrorMessage = "Enter chef's name")]
        public string Chef { get; set; }
        [Required(ErrorMessage = "Enter preparation time")]
        public string PreparationTime { get; set; }
        public string Review { get; set; }
    }
}
