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

        public event EventHandler NewRequested;

        public event EventHandler SaveRequested;

        public event EventHandler DeleteRequested;

        public event EventHandler SelectedRecipesChanged; 

        public IEnumerable<Recipe> SelectedRecipes
        {
            get { throw new NotImplementedException(); }
        }

        public string Name { get; set; }

        public string Contents { get; set; }

        public void PopulateList(List<Recipe> recipes)
        {
            m_recipes = recipes;
        }

        public void ClearNameAndContents()
        {
        }

        public void SelectedIndexChanged(object sender, EventArgs e)
        {
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
        }
    }
}
