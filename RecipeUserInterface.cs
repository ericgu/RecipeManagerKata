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
        private TextBox m_textBoxContents;

        public RecipeUserInterface(ListView listView, TextBox textBoxName, TextBox textBoxContents)
        {
            m_listView = listView;
            m_textBoxName = textBoxName;
            m_textBoxContents = textBoxContents;
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

        public string Name
        {
            get { return m_textBoxName.Text; }
            set { m_textBoxName.Text = value; }
        }

        public void SetContents(string empty)
        {
            Contents = empty;
        }

        public string Contents
        {
            get { return m_textBoxContents.Text; }
            set { m_textBoxContents.Text = value; }
        }

        public string GetContents()
        {
            return Contents;
        }
    }
}
