using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeManager
{
    class RecipeListViewItem: ListViewItem
    {
        private Recipe m_recipe;

        public RecipeListViewItem(Recipe recipe)
        {
            m_recipe = recipe;

            Text = recipe.Name;
            SubItems.Add(new ListViewSubItem(this, m_recipe.Size.ToString()));
        }

        public Recipe Recipe {
            get { return m_recipe; }
        }
    }
}
