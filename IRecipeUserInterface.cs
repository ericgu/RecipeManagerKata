using System;
using System.Collections.Generic;

namespace RecipeManager
{
    public interface IRecipeUserInterface
    {
        event EventHandler NewRequested;
        event EventHandler SaveRequested;
        event EventHandler DeleteRequested;
        IEnumerable<Recipe> SelectedRecipes { get; }
        string Name { get; set; }
        string Contents { get; set; }
        void PopulateList(List<Recipe> mRecipes);
        void ClearNameAndContents();
        void SelectedIndexChanged(object sender, EventArgs e);
    }
}