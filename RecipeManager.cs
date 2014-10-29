using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    class RecipeManager
    {
        private List<Recipe> m_recipes; 
        private IRecipeStore m_recipeStore;
        private IRecipeUserInterface m_recipeUserInterface;

        public RecipeManager(IRecipeStore recipeStore, IRecipeUserInterface recipeUserInterface)
        {
            m_recipeUserInterface = recipeUserInterface;
            m_recipeStore = recipeStore;

            m_recipeUserInterface.NewRequested += NewRequested;
            m_recipeUserInterface.SaveRequested += SaveRequested;
            m_recipeUserInterface.DeleteRequested += DeleteRequested;
            m_recipeUserInterface.SelectedRecipesChanged += SelectedRecipesChanged;

            LoadRecipes();
        }

        void SelectedRecipesChanged(object sender, EventArgs e)
        {
            var firstRecipe = m_recipeUserInterface.SelectedRecipes.FirstOrDefault();

            if (firstRecipe != null)
            {
                m_recipeUserInterface.Name = firstRecipe.Name;
                m_recipeUserInterface.Contents = firstRecipe.Text;
            }
        }

        public void DeleteRequested(object sender, EventArgs e)
        {
            foreach (Recipe recipe in m_recipeUserInterface.SelectedRecipes)
            {
                m_recipeStore.Delete(recipe);
            }

            LoadRecipes();

            m_recipeUserInterface.ClearNameAndContents();
        }

        public void SaveRequested(object sender, EventArgs e)
        {
            Recipe recipe = new Recipe { Name = m_recipeUserInterface.Name, Text = m_recipeUserInterface.Contents };
            m_recipeStore.Save(recipe);
            LoadRecipes();
        }

        public void NewRequested(object sender, EventArgs e)
        {
            m_recipeUserInterface.ClearNameAndContents();
        }

        public void LoadRecipes()
        {
            m_recipes = m_recipeStore.Load();
            m_recipeUserInterface.PopulateList(m_recipes);
        }


    }
}
