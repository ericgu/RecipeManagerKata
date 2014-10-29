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
        private void AddTwoRecipesToStore()
        {
            m_recipeStore.Save(new Recipe {Name = "Toast", Contents = "Put in toaster"});
            m_recipeStore.Save(new Recipe {Name = "HashBrowns", Contents = "Fry"});
        }

        [TestMethod()]
        public void When_I_create_a_RecipeManager__it_is_not_null()
        {
            CreateRecipeManager();

            Assert.IsNotNull(m_recipeManager);
        }

        [TestMethod()]
        public void When_I_enter_text_and_contents_and_click_save__the_recipe_should_be_in_the_store_and_the_displayed_list()
        {
            CreateRecipeManager();

            m_recipeUserInterface.Name = "Toast";
            m_recipeUserInterface.Contents = "Put in toaster";
            m_recipeUserInterface.SimulatePressSave();

            var recipes = m_recipeStore.Load();

            var expectedRecipe = new Recipe {Name = "Toast", Contents = "Put in toaster"};
            RecipeStoreSimulator_Tests.ListContainsRecipesInOrder(recipes, expectedRecipe);

            RecipeStoreSimulator_Tests.ListContainsRecipesInOrder(m_recipeUserInterface.SimulateReadRecipeList(),
                expectedRecipe);
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

        [TestMethod()]
        public void When_I_start_with_two_recipes_in_the_store_and_select_the_second_one__the_selecte_recipe_and_name_and_text_should_be_properly_set()
        {
            AddTwoRecipesToStore();

            var secondRecipeInStore = m_recipeStore.Load()[1];

            RecipeManager recipeManager = new RecipeManager(m_recipeStore, m_recipeUserInterface);

            m_recipeUserInterface.SimulateSelectRecipe(1);

            Assert.AreEqual(secondRecipeInStore.Name, m_recipeUserInterface.Name);
            Assert.AreEqual(secondRecipeInStore.Contents, m_recipeUserInterface.Contents);

            Assert.AreEqual(secondRecipeInStore, m_recipeUserInterface.SelectedRecipes.FirstOrDefault());
        }

        [TestMethod()]
        public void When_I_start_with_two_recipes_in_the_store_and_select_the_first_one_and_then_deselect_it__the_selected_recipe_and_name_and_text_should_be_clear()
        {
            AddTwoRecipesToStore();

            RecipeManager recipeManager = new RecipeManager(m_recipeStore, m_recipeUserInterface);

            m_recipeUserInterface.SimulateSelectRecipe(1);
            m_recipeUserInterface.SimulateSelectRecipe(-1);

            Assert.AreEqual(String.Empty, m_recipeUserInterface.Name);
            Assert.AreEqual(String.Empty, m_recipeUserInterface.Contents);

            Assert.AreEqual(0, m_recipeUserInterface.SelectedRecipes.Count());
        }

        [TestMethod()]
        public void When_I_start_with_two_recipes_in_the_store_and_select_the_first_one_and_then_click_new__the_name_and_text_should_be_clear()
        {
            AddTwoRecipesToStore();

            RecipeManager recipeManager = new RecipeManager(m_recipeStore, m_recipeUserInterface);

            m_recipeUserInterface.SimulateSelectRecipe(1);
            m_recipeUserInterface.SimulatePressNew();

            Assert.AreEqual(String.Empty, m_recipeUserInterface.Name);
            Assert.AreEqual(String.Empty, m_recipeUserInterface.Contents);
        }


        [TestMethod()]
        public void When_I_start_with_two_recipes_in_the_store_and_select_the_first_one_and_then_click_delete__the_name_and_text_should_be_clear_and_the_recipe_should_be_deleted()
        {
            AddTwoRecipesToStore();

            RecipeManager recipeManager = new RecipeManager(m_recipeStore, m_recipeUserInterface);

            var recipesInStoreAtStart = m_recipeStore.Load();

            m_recipeUserInterface.SimulateSelectRecipe(0);
            m_recipeUserInterface.SimulatePressDelete();

            Assert.AreEqual(String.Empty, m_recipeUserInterface.Name);
            Assert.AreEqual(String.Empty, m_recipeUserInterface.Contents);

            RecipeStoreSimulator_Tests.ListContainsRecipesInOrder(m_recipeStore.Load(), recipesInStoreAtStart[1]);
        }  
    }
}
