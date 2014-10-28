using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    class RecipeStore
    {
        private readonly string m_storageLocation;

        public RecipeStore(string storageLocation)
        {
            m_storageLocation = storageLocation;
            
        }

        IEnumerable<FileInfo> GetFilesInDirectory()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(m_storageLocation);

            FileInfo[] fileInfos = directoryInfo.GetFiles("*");
            return fileInfos;
        }

        Recipe CreateRecipeFromFile(FileInfo fileInfo)
        {
            return new Recipe { Name = fileInfo.Name, Size = fileInfo.Length, Text = File.ReadAllText(fileInfo.FullName) };
        }

        public List<Recipe> LoadRecipes()
        {
            return  GetFilesInDirectory()
                .Select(fileInfo => CreateRecipeFromFile(fileInfo)).ToList();
        }

        public static void DeleteRecipe(string name)
        {
            File.Delete(@"e:\portkata\" + name);
        }
    }
}
