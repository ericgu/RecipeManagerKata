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
            throw new NotImplementedException();
        }

        public void DeleteRecipe(string name)
        {
            throw new NotImplementedException();
        }

        public void SaveRecipe(string name, string contents)
        {
            throw new NotImplementedException();
        }
    }
}
