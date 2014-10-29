using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeManager
{
    public partial class Form1 : Form
    {
        private RecipeManager m_recipeManager;
        private List<Recipe> m_recipes = new List<Recipe>();
        private readonly RecipeStore m_recipeStore = new RecipeStore(@"e:\portkata");
        private RecipeUserInterface m_recipeUserInterface;

        public Form1()
        {
            InitializeComponent();

            m_recipeUserInterface = new RecipeUserInterface(listView1, textBoxName, textBoxObjectData, buttonNew, buttonSave, buttonDelete);
            m_recipeManager = new RecipeManager();
            
            SetupEvents();

            LoadRecipes();
        }

        private void SetupEvents()
        {
            m_recipeUserInterface.NewRequested += NewRequested;
            m_recipeUserInterface.SaveRequested += SaveRequested;
            m_recipeUserInterface.DeleteRequested += DeleteRequested;
        }

        void DeleteRequested(object sender, EventArgs e)
        {
            foreach (Recipe recipe in m_recipeUserInterface.SelectedRecipes)
            {
                m_recipeStore.Delete(recipe);
            }

            LoadRecipes();

            m_recipeUserInterface.ClearNameAndContents();
        }

        void SaveRequested(object sender, EventArgs e)
        {
            Recipe recipe = new Recipe { Name = m_recipeUserInterface.Name, Text = m_recipeUserInterface.Contents };
            m_recipeStore.Save(recipe);
            LoadRecipes();
        }

        void NewRequested(object sender, EventArgs e)
        {
            m_recipeUserInterface.ClearNameAndContents();
        }

        private void LoadRecipes()
        {
            m_recipes = m_recipeStore.Load();
            m_recipeUserInterface.PopulateList(m_recipes);
        }
    }
}
