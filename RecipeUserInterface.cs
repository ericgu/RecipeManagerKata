using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeManager
{
    class RecipeUserInterface
    {
        private ListView m_listView;

        public RecipeUserInterface(ListView listView)
        {
            m_listView = listView;
        }

        public void PopulateList(List<Recipe> mRecipes)
        {
            m_listView.Items.Clear();

            foreach (Recipe recipe in mRecipes)
            {
                m_listView.Items.Add(new RecipeListViewItem(recipe));
            }
        }

        public ListView.SelectedListViewItemCollection SelectedItems()
        {
            return m_listView.SelectedItems;
        }
    }
}
