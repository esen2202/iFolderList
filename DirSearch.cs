using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace iFolderList
{
    public partial class DirSearch : Form
    {
        public DirSearch()
        {
            InitializeComponent();
        }

        private void DirSearch_Load(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            DirectorySearch(Program.folderPath);
        }
        private void DirectorySearch(string sDir)
        {
            try
            {
                foreach (string f in Directory.GetDirectories(sDir))
                {
                    richTextBox1.Text = richTextBox1.Text + (f.Replace(Program.folderPath + @"\", "")).Replace(@"\", @"/") + System.Environment.NewLine;
                }

                foreach (string d in Directory.GetDirectories(sDir))
                {
                    this.DirectorySearch(d);
                }
            }
            catch (System.Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }
    }
}
