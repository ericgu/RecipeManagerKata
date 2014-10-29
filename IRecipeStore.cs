using System.Collections.Generic;

namespace RecipeManager
{
    internal interface IRecipeStore
    {
        List<Recipe> LoadRecipes();
        void DeleteRecipe(Recipe recipe);
        void SaveRecipe(Recipe recipe);
    }
}