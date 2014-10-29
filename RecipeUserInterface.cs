﻿using System;
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

        public event EventHandler NewRequested;
        public event EventHandler SaveRequested; 

        public RecipeUserInterface(ListView listView, TextBox textBoxName, TextBox textBoxContents, Button newButton, Button saveButton)
        {
            m_saveButton = saveButton;
            m_newButton = newButton;
            m_listView = listView;
            m_textBoxName = textBoxName;
            m_textBoxContents = textBoxContents;

            m_newButton.Click += NewButtonClick;
            m_saveButton.Click += SaveButtonClick;
        }

        void SaveButtonClick(object sender, EventArgs e)
        {
            if (SaveRequested != null)
            {
                SaveRequested(this, null);
            }
        }

        void NewButtonClick(object sender, EventArgs e)
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
    }
}
