using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeManager
{
    class RecipeUI
    {
        public void PopulateList(List<Recipe> mRecipes, ListView listView)
        {
            listView.Items.Clear();

            foreach (Recipe recipe in mRecipes)
            {
                listView.Items.Add(new RecipeListViewItem(recipe));
            }
        }
    }
}
