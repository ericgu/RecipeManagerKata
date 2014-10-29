using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecipeManager
{
    [TestClass]
    public class RecipeStoreSimulator_Tests
    {
        [TestMethod()]
        public void When_I_create_a_RecipeStoreSimulator__it_is_not_null()
        {
            RecipeStoreSimulator simulator = new RecipeStoreSimulator();

            Assert.IsNotNull(simulator);
        }

        [TestMethod()]
        public void When_I_create_a_RecipeStoreSimulator_and_call_LoadRecipes__it_returns_an_empty_list()
        {
            RecipeStoreSimulator simulator = new RecipeStoreSimulator();

            var recipes = simulator.LoadRecipes();

            Assert.AreEqual(0, recipes.Count);
        }

        [TestMethod()]
        public void When_I_call_SaveRecipe_and_call_LoadRecipes__it_returns_that_recipe()
        {
            RecipeStoreSimulator simulator = new RecipeStoreSimulator();

            Recipe recipe = new Recipe {Name = "Eggs", Text = "Cook eggs", Size = 9};
            simulator.SaveRecipe(recipe);

            var recipes = simulator.LoadRecipes();

            Assert.AreEqual(1, recipes.Count);
            CompareRecipeToRecipeInList(recipe, recipes, 0);
        }

        private static void CompareRecipeToRecipeInList(Recipe recipe, List<Recipe> recipes, int recipeIndex)
        {
            Assert.AreEqual(recipe.Name, recipes[recipeIndex].Name);
            Assert.AreEqual(recipe.Text, recipes[recipeIndex].Text);
            Assert.AreEqual(recipe.Size, recipes[recipeIndex].Size);
        }

        [TestMethod()]
        public void When_I_call_SaveRecipe_twice_and_call_LoadRecipes__it_returns_both_recipes()
        {
            RecipeStoreSimulator simulator = new RecipeStoreSimulator();

            Recipe recipe1 = new Recipe { Name = "Ham", Text = "Slice Ham", Size = 9 };
            simulator.SaveRecipe(recipe1);
            Recipe recipe2 = new Recipe { Name = "Eggs", Text = "Cook eggs", Size = 9 };
            simulator.SaveRecipe(recipe2);

            var recipes = simulator.LoadRecipes();

            Assert.AreEqual(2, recipes.Count);

            Assert.AreEqual(recipe1.Name, recipes[1].Name);
            Assert.AreEqual(recipe1.Text, recipes[1].Text);
            Assert.AreEqual(recipe1.Size, recipes[1].Size);

            Assert.AreEqual(recipe1.Name, recipes[1].Name);
            Assert.AreEqual(recipe1.Text, recipes[1].Text);
            Assert.AreEqual(recipe1.Size, recipes[1].Size);
        }
    
    }
}
