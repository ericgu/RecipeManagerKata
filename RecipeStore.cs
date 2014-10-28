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
        static IEnumerable<FileInfo> GetFilesInDirectory(string storageLocation)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(storageLocation);

            FileInfo[] fileInfos = directoryInfo.GetFiles("*");
            return fileInfos;
        }

        static Recipe CreateRecipeFromFile(FileInfo fileInfo)
        {
            return new Recipe { Name = fileInfo.Name, Size = fileInfo.Length, Text = File.ReadAllText(fileInfo.FullName) };
        }

        public static List<Recipe> LoadRecipes(string storageLocation)
        {
            var fileInfos = GetFilesInDirectory(storageLocation);
            return  fileInfos
                .Select(fileInfo => CreateRecipeFromFile(fileInfo)).ToList();
        }
    }
}
