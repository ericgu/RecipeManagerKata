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

        public Form1()
        {
            InitializeComponent();

            LoadRecipes();
        }

        private void LoadRecipes()
        {
            LoadRecipesPrivate(@"e:\portkata");

            PopulateList();
        }

        private void LoadRecipesPrivate(string storageLocation)
        {
            var fileInfos = GetFilesInDirectory(storageLocation);
            m_recipes = fileInfos
                .Select(fileInfo => CreateRecipeFromFile(fileInfo)).ToList();
        }

        private static Recipe CreateRecipeFromFile(FileInfo fileInfo)
        {
            return new Recipe { Name = fileInfo.Name, Size = fileInfo.Length, Text = File.ReadAllText(fileInfo.FullName) };
        }

        private static FileInfo[] GetFilesInDirectory(string storageLocation)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(storageLocation);

            FileInfo[] fileInfos = directoryInfo.GetFiles("*");
            return fileInfos;
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
                File.Delete(@"e:\portkata\" + recipeListViewItem.Recipe.Name);
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
            File.WriteAllText(Path.Combine("e:\\portkata", textBoxName.Text), textBoxObjectData.Text);
            LoadRecipes();
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
