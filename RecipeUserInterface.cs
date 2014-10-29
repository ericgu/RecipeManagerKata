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
    class RecipeUserInterface
    {
        private ListView m_listView;
        private TextBox m_textBoxName;
        private TextBox m_textBoxContents;
        private Button m_newButton;
        private Button m_saveButton;
        private Button m_deleteButton;

        public event EventHandler NewRequested;
        public event EventHandler SaveRequested;
        public event EventHandler DeleteRequested; 

        public RecipeUserInterface(ListView listView, TextBox textBoxName, TextBox textBoxContents, Button newButton, Button saveButton, Button deleteButton)
        {
            m_deleteButton = deleteButton;
            m_saveButton = saveButton;
            m_newButton = newButton;
            m_listView = listView;
            m_textBoxName = textBoxName;
            m_textBoxContents = textBoxContents;

            m_newButton.Click += newButton_Click;
            m_saveButton.Click += SaveButtonClick;
            m_deleteButton.Click += DeleteButtonClick;
            m_listView.SelectedIndexChanged += SelectedIndexChanged;
        }

        void DeleteButtonClick(object sender, EventArgs e)
        {
            if (DeleteRequested != null)
            {
                DeleteRequested(this, null);
            }
        }

        void SaveButtonClick(object sender, EventArgs e)
        {
            if (SaveRequested != null)
            {
                SaveRequested(this, null);
            }
        }

        void newButton_Click(object sender, EventArgs e)
        {
            if (NewRequested != null)
            {
                NewRequested(this, null);
            }
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

        public string Contents
        {
            get { return m_textBoxContents.Text; }
            set { m_textBoxContents.Text = value; }
        }

        public void ClearNameAndContents()
        {
            Name = "";
            Contents = "";
        }

        public void SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Recipe recipe in SelectedRecipes)
            {
                Name = recipe.Name;
                Contents = recipe.Text;
                break;
            }
        }
    }
}
