using System.Collections.Generic;

namespace RecipeManager
{
    internal interface IRecipeStore
    {
        List<Recipe> Load();
        void Delete(Recipe recipe);
        void Save(Recipe recipe);
    }
}