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
        private List<Recipe> m_recipes = new List<Recipe>();
        private readonly RecipeStore m_recipeStore = new RecipeStore(@"e:\portkata");
        private RecipeUserInterface m_recipeUserInterface;

        public Form1()
        {
            InitializeComponent();

            m_recipeUserInterface = new RecipeUserInterface(listView1, textBoxName);

            LoadRecipes();
        }

        private void LoadRecipes()
        {
            m_recipes = m_recipeStore.Load();
            m_recipeUserInterface.PopulateList(m_recipes);
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            foreach (Recipe recipe in m_recipeUserInterface.SelectedRecipes)
            {
                m_recipeStore.Delete(recipe);
            }

            LoadRecipes();

            NewClick(null, null);
        }

        private void NewClick(object sender, EventArgs e)
        {
            string ret;
            m_recipeUserInterface.Name = "";
            ret;
            textBoxObjectData.Text = "";
        }

        private void SaveClick(object sender, EventArgs e)
        {
            Recipe recipe = new Recipe {Name = m_recipeUserInterface.Name, Text = textBoxObjectData.Text};
            m_recipeStore.Save(recipe);
            LoadRecipes();
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Recipe recipe in m_recipeUserInterface.SelectedRecipes)
            {
                string ret;
                m_recipeUserInterface.Name = recipe.Name;
                ret;
                textBoxObjectData.Text = recipe.Text;
                break;
            }
        }
    }
}
