using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace RecipeManager
{
    public class RecipeUserInterfaceSimulator : IRecipeUserInterface
    {
        private List<Recipe> m_recipes;
        private List<Recipe> m_selectedRecipes = new List<Recipe>();

        public event EventHandler NewRequested;

        public event EventHandler SaveRequested;

        public event EventHandler DeleteRequested;

        public event EventHandler SelectedRecipesChanged; 

        public IEnumerable<Recipe> SelectedRecipes
        {
            get { return m_selectedRecipes; }
        }

        public string Name { get; set; }

        public string Contents { get; set; }

        public void PopulateList(List<Recipe> recipes)
        {
            m_recipes = recipes;
        }

        public void ClearNameAndContents()
        {
            Name = String.Empty;
            Contents = String.Empty;
        }

        internal void SimulatePressSave()
        {
            if (SaveRequested != null)
            {
                SaveRequested(this, null);
            }
        }

        internal List<Recipe> SimulateReadRecipeList()
        {
            return m_recipes;
        }

        internal void SimulateSelectRecipe(int selectedRecipeIndex)
        {
            m_selectedRecipes = new List<Recipe>();
            if (selectedRecipeIndex != -1)
            {
                m_selectedRecipes.Add(m_recipes[selectedRecipeIndex]);
            }

            if (SelectedRecipesChanged != null)
            {
                SelectedRecipesChanged(this, null);
            }
        }

        internal void SimulatePressNew()
        {
            if (NewRequested != null)
            {
                NewRequested(this, null);
            }
        }

        internal void SimulatePressDelete()
        {
            if (DeleteRequested != null)
            {
                DeleteRequested(this, null);
            }
        }
    }
}
