using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecipeManager
{
    [TestClass]
    public class RecipeManager_Tests
    {
        private RecipeStoreSimulator m_recipeStore = new RecipeStoreSimulator();
        private RecipeUserInterfaceSimulator m_recipeUserInterface = new RecipeUserInterfaceSimulator();
        private RecipeManager m_recipeManager;

        private void CreateRecipeManager()
        {
            m_recipeManager = new RecipeManager(m_recipeStore, m_recipeUserInterface);
        }

        [TestMethod()]
        public void When_I_create_a_RecipeManager__it_is_not_null()
        {
            CreateRecipeManager();

            Assert.IsNotNull(m_recipeManager);
        }

        [TestMethod()]
        public void When_I_enter_text_and_contents_and_click_save__the_recipe_should_be_in_the_store()
        {
            CreateRecipeManager();

            m_recipeUserInterface.Name = "Toast";
            m_recipeUserInterface.Contents = "Put in toaster";
            m_recipeUserInterface.SimulatePressSave();

            var recipes = m_recipeStore.Load();

            RecipeStoreSimulator_Tests.ListContainsRecipesInOrder(recipes,
                new Recipe {Name = "Toast", Text = "Put in toaster"});
        }

        [TestMethod()]
        public void When_I_start_with_two_recipes_in_the_store__they_should_be_populated_in_the_UI()
        {
            AddTwoRecipesToStore();

            CreateRecipeManager();

            var recipes = m_recipeUserInterface.SimulateReadRecipeList();

            var recipesInStore = m_recipeStore.Load();
            RecipeStoreSimulator_Tests.ListContainsRecipesInOrder(recipes, recipesInStore[0], recipesInStore[1]);
        }

        private void AddTwoRecipesToStore()
        {
            m_recipeStore.Save(new Recipe {Name = "Toast", Text = "Put in toaster"});
            m_recipeStore.Save(new Recipe {Name = "HashBrowns", Text = "Fry"});
        }

        [TestMethod()]
        public void When_I_start_with_two_recipes_in_the_store_and_select_the_second_one__the_selecte_recipe_and_name_and_text_should_be_properly_set()
        {
            AddTwoRecipesToStore();

            var secondRecipeInStore = m_recipeStore.Load()[1];

            RecipeManager recipeManager = new RecipeManager(m_recipeStore, m_recipeUserInterface);

            m_recipeUserInterface.SimulateSelectRecipe(1);

            Assert.AreEqual(secondRecipeInStore.Name, m_recipeUserInterface.Name);
            Assert.AreEqual(secondRecipeInStore.Text, m_recipeUserInterface.Contents);

            Assert.AreEqual(secondRecipeInStore, m_recipeUserInterface.SelectedRecipes.FirstOrDefault());
        }
    
    }
}
