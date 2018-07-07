using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iFolderList
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static string folderPath;

        [STAThread]
        static void Main(String[] arguments)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (arguments.Length > 0)
            {
                //MessageBox.Show(arguments[0]);
                folderPath = arguments[0];
                Application.Run(new MainForm());
            }
            else 
            {
                MessageBox.Show("Klasör Seçilmedi");
            }
            
        }
    }
}
