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

        public Form1()
        {
            InitializeComponent();

            LoadRecipes();
        }

        private void LoadRecipes()
        {
            m_recipes = m_recipeStore.LoadRecipes();

            PopulateList();
        }

        private void PopulateList()
        {
            listView1.Items.Clear();

            foreach (Recipe recipe in m_recipes)
            {
                listView1.Items.Add(new RecipeListViewItem(recipe));
            }
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            foreach (RecipeListViewItem recipeListViewItem in listView1.SelectedItems)
            {
                m_recipes.Remove(recipeListViewItem.Recipe);
                m_recipeStore.DeleteRecipe(recipeListViewItem.Recipe.Name);
            }
            PopulateList();

            NewClick(null, null);
        }

        private void NewClick(object sender, EventArgs e)
        {
            textBoxName.Text = "";
            textBoxObjectData.Text = "";
        }

        private void SaveClick(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string contents = textBoxObjectData.Text;
            SaveRecipe(name, contents);
            LoadRecipes();
        }

        private static void SaveRecipe(string name, string contents)
        {
            File.WriteAllText(Path.Combine("e:\\portkata", name), contents);
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (RecipeListViewItem recipeListViewItem in listView1.SelectedItems)
            {
                textBoxName.Text = recipeListViewItem.Recipe.Name;
                textBoxObjectData.Text = recipeListViewItem.Recipe.Text;
                break;
            }
        }
    }
}
