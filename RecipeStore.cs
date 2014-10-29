using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public class RecipeStore : IRecipeStore
    {
        private readonly string m_storageLocation;

        public RecipeStore(string storageLocation)
        {
            m_storageLocation = storageLocation;
        }

        public List<Recipe> Load()
        {
            return  GetFilesInDirectory()
                .Select(fileInfo => CreateRecipeFromFile(fileInfo)).ToList();
        }

        public void Delete(Recipe recipe)
        {
            File.Delete(GetRecipeFilename(recipe.Name));
        }

        public void Save(Recipe recipe)
        {
            File.WriteAllText(GetRecipeFilename(recipe.Name), recipe.Contents);
        }

        private IEnumerable<FileInfo> GetFilesInDirectory()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(m_storageLocation);

            FileInfo[] fileInfos = directoryInfo.GetFiles("*");
            return fileInfos;
        }

        private Recipe CreateRecipeFromFile(FileInfo fileInfo)
        {
            return new Recipe { Name = fileInfo.Name, Size = fileInfo.Length, Contents = File.ReadAllText(fileInfo.FullName) };
        }

        private string GetRecipeFilename(string name)
        {
            return Path.Combine(m_storageLocation, name);
        }
    }
}
