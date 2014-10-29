using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    class RecipeStoreSimulator : IRecipeStore
    {
        public List<Recipe> LoadRecipes()
        {
            return new List<Recipe>();
        }

        public void DeleteRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void SaveRecipe(Recipe recipe)
        {

        }
    }
}
