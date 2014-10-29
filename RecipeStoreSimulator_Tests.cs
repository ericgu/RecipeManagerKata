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
        private IRecipeStore m_simulator = new RecipeStoreSimulator();
        //private IRecipeStore m_simulator = new RecipeStore(@"e:\TempRecipeStore");

        [TestMethod()]
        public void When_I_create_a_RecipeStoreSimulator__it_is_not_null()
        {
            Assert.IsNotNull(m_simulator);
        }

        [TestMethod()]
        public void When_I_create_a_RecipeStoreSimulator_and_call_LoadRecipes__it_returns_an_empty_list()
        {
            var recipes = m_simulator.Load();

            ListContainsRecipesInOrder(recipes);

            DeleteAllRecipes();
        }

        [TestMethod()]
        public void When_I_call_SaveRecipe_and_call_LoadRecipes__it_returns_that_recipe()
        {
            Recipe recipe = new Recipe {Name = "Eggs", Text = "Cook eggs", Size = 9};
            m_simulator.Save(recipe);

            var recipes = m_simulator.Load();

            ListContainsRecipesInOrder(recipes, recipe);

            DeleteAllRecipes();
        }

        [TestMethod()]
        public void When_I_call_SaveRecipe_twice_and_call_LoadRecipes__it_returns_both_recipes()
        {
            IRecipeStore m_simulator = new RecipeStoreSimulator();

            Recipe recipe1 = new Recipe { Name = "Ham", Text = "Slice Ham", Size = 9 };
            m_simulator.Save(recipe1);
            Recipe recipe2 = new Recipe { Name = "Eggs", Text = "Cook eggs", Size = 9 };
            m_simulator.Save(recipe2);

            var recipes = m_simulator.Load();

            ListContainsRecipesInOrder(recipes, recipe1, recipe2);

            DeleteAllRecipes();
        }

        [TestMethod()]
        public void When_I_call_SaveRecipe_twice_Delete_one_recipe_and_call_LoadRecipes__it_returns_one_recipe()
        {
            Recipe recipe1 = new Recipe { Name = "Ham", Text = "Slice Ham", Size = 9 };
            m_simulator.Save(recipe1);
            Recipe recipe2 = new Recipe { Name = "Eggs", Text = "Cook eggs", Size = 9 };
            m_simulator.Save(recipe2);

            m_simulator.Delete(recipe1);

            var recipes = m_simulator.Load();

            ListContainsRecipesInOrder(recipes, recipe2);

            DeleteAllRecipes();
        }

        private void DeleteAllRecipes()
        {
            var recipes = m_simulator.Load();

            foreach (Recipe recipe in recipes)
            {
                m_simulator.Delete(recipe);
            }
        }

        public static void ListContainsRecipesInOrder(List<Recipe> recipes, params Recipe[] expectedRecipes)
        {
            Assert.AreEqual(expectedRecipes.Length, recipes.Count);

            for (int i = 0; i < expectedRecipes.Length; i++)
            {
                Assert.AreEqual(expectedRecipes[i].Name, recipes[i].Name);
                Assert.AreEqual(expectedRecipes[i].Text, recipes[i].Text);
                Assert.AreEqual(expectedRecipes[i].Size, recipes[i].Size);
            }
        }
    }
}
