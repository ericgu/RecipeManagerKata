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
            Assert.AreEqual(recipe.Name, recipes[0].Name);
            Assert.AreEqual(recipe.Text, recipes[0].Text);
            Assert.AreEqual(recipe.Size, recipes[0].Size);
        }
    }
}
