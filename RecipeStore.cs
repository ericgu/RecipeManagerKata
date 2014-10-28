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
        public static FileInfo[] GetFilesInDirectory(string storageLocation)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(storageLocation);

            FileInfo[] fileInfos = directoryInfo.GetFiles("*");
            return fileInfos;
        }

        public static Recipe CreateRecipeFromFile(FileInfo fileInfo)
        {
            return new Recipe { Name = fileInfo.Name, Size = fileInfo.Length, Text = File.ReadAllText(fileInfo.FullName) };
        }
    }
}
