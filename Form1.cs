using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeManager
{
    public partial class Form1 : Form
    {
        private RecipeManager m_recipeManager;

        public Form1()
        {
            InitializeComponent();

            m_recipeManager = new RecipeManager(
                                    new RecipeStore(@"e:\portkata"), 
                                    new RecipeUserInterface(listView1, textBoxName, textBoxObjectData, buttonNew, buttonSave, buttonDelete));
        }
    }
}
