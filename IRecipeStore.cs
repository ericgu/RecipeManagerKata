using System.Collections.Generic;

namespace RecipeManager
{
    internal interface IRecipeStore
    {
        List<Recipe> LoadRecipes();
        void DeleteRecipe(string name);
        void SaveRecipe(string name, string contents);
    }
}