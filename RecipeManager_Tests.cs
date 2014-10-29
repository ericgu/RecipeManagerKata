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
        [TestMethod()]
        public void When_I_create_a_RecipeManager__it_is_not_null()
        {
            RecipeStoreSimulator store = new RecipeStoreSimulator();
            RecipeUserInterfaceSimulator userInterface = new RecipeUserInterfaceSimulator();

            RecipeManager recipeManager = new RecipeManager(store, userInterface);

            Assert.IsNotNull(recipeManager);
        }

        [TestMethod()]
        public void When_I_enter_text_and_contents_and_click_save__the_recipe_should_be_in_the_store()
        {
            RecipeStoreSimulator store = new RecipeStoreSimulator();
            RecipeUserInterfaceSimulator userInterface = new RecipeUserInterfaceSimulator();

            RecipeManager recipeManager = new RecipeManager(store, userInterface);

            userInterface.Name = "Toast";
            userInterface.Contents = "Put in toaster";
            userInterface.SimulatePressSave();

            var recipes = store.Load();

            RecipeStoreSimulator_Tests.ListContainsRecipesInOrder(recipes,
                new Recipe {Name = "Toast", Text = "Put in toaster"});
        }


        [TestMethod()]
        public void When_I_start_with_two_recipes_in_the_store__they_should_be_populated_in_the_UI()
        {
            RecipeStoreSimulator store = new RecipeStoreSimulator();
            var recipe1 = new Recipe { Name = "Toast", Text = "Put in toaster" };
            store.Save(recipe1);
            var recipe2 = new Recipe { Name = "HashBrowns", Text = "Fry" };
            store.Save(recipe2);

            RecipeUserInterfaceSimulator userInterface = new RecipeUserInterfaceSimulator();

            RecipeManager recipeManager = new RecipeManager(store, userInterface);

            var recipes = userInterface.SimulateReadRecipeList();

            RecipeStoreSimulator_Tests.ListContainsRecipesInOrder(recipes, recipe1, recipe2);
        }
    }
}
