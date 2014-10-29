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
        private List<Recipe> m_recipes = new List<Recipe>();
 
        public List<Recipe> LoadRecipes()
        {
            return m_recipes.ToList();
        }

        public void DeleteRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void SaveRecipe(Recipe recipe)
        {
            m_recipes.Add(recipe);
        }
    }
}
