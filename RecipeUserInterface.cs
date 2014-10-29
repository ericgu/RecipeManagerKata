using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace RecipeManager
{
    class RecipeUserInterface
    {
        private ListView m_listView;
        private TextBox m_textBoxName;

        public RecipeUserInterface(ListView listView, TextBox textBoxName)
        {
            m_listView = listView;
            m_textBoxName = textBoxName;
        }

        public void PopulateList(List<Recipe> mRecipes)
        {
            m_listView.Items.Clear();

            foreach (Recipe recipe in mRecipes)
            {
                m_listView.Items.Add(new RecipeListViewItem(recipe));
            }
        }

        public IEnumerable<Recipe> SelectedRecipes
        {
            get { return m_listView.SelectedItems.Cast<RecipeListViewItem>().Select(item => item.Recipe); }
        }

        public string SetName(string empty)
        {
            return m_textBoxName.Text = empty;
        }

        public string GetName()
        {
            return m_textBoxName.Text;
        }
    }
}
