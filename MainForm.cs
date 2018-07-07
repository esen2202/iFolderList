using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EopyLibrary;
using System.IO;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace iFolderList
{
    public partial class MainForm : Form
    {


        String ApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("file:\\", "");

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
            int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        //________________________________
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );


        private const int CS_DROPSHADOW = 0x20000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void set_background(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            //the rectangle, the same size as our Form
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);

            //define gradient's properties
            Brush b = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(45, 45, 48), Color.FromArgb(69, 69, 71), 65f);

            //apply gradient         
            graphics.FillRectangle(b, gradient_rectangle);
        }


        // esc button form close
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Escape) this.Close();
            bool res = base.ProcessCmdKey(ref msg, keyData);
            return res;
        }
        string localpath;

        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void directoryLoad()
        {
            if (!Directory.Exists(ApplicationData + "\\iFolderList\\file"))
            {
                Directory.CreateDirectory(ApplicationData + "\\iFolderList\\file");
            }

            cb_txtList.Text = "";
            cb_txtList.Items.Clear();
            string[] directoryList;  // array for directories
            directoryList = Directory.GetFiles(ApplicationData + "\\iFolderList\\file\\");

            for (int i = 0; i < directoryList.Length; i++)
            {
                cb_txtList.Items.Add(directoryList[i].Replace(ApplicationData + "\\iFolderList\\file\\", ""));
            }
            if (directoryList.Length > 0)
            {
                cb_txtList.Text = directoryList[0].Replace(ApplicationData + "\\iFolderList\\file\\", "");
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {


            localpath = EopyStreamFiling.AssemblyDirectory;
            lbl_folderAddress.Text = Program.folderPath;
            directoryLoad();
            lastTxtFileRead();
            btn_create.Focus();
            
        }

        public static bool FolderCopy(string sourcePatch, string targetPatch)
        {
            if (String.IsNullOrEmpty(sourcePatch) || string.IsNullOrEmpty(targetPatch))
            {
                return false;
            }
            try
            {
                string[] folderInFile = Directory.GetFiles(sourcePatch);
                string[] fileName;
                for (int i = 0; i < folderInFile.Length; i++)
                {
                    fileName = folderInFile[i].Split('\\');
                    File.Copy(folderInFile[i], String.Format("{0}\\{1}", targetPatch, fileName[fileName.Length - 1]));
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "text files|*.txt";

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (!Directory.Exists(ApplicationData + "\\iFolderList\\file"))
                {
                    Directory.CreateDirectory(ApplicationData + "\\iFolderList\\file");
                }
                File.Copy(openFileDialog1.FileName, ApplicationData + "\\iFolderList\\file\\" + openFileDialog1.SafeFileName, true);
                directoryLoad();
                cb_txtList.Text = openFileDialog1.SafeFileName;
            }

        }

        private void btn_del_Click(object sender, EventArgs e)
        {

            if (File.Exists(ApplicationData + "\\iFolderList\\file\\" + cb_txtList.Text))
            {
                File.Delete(ApplicationData + "\\iFolderList\\file\\" + cb_txtList.Text);
                directoryLoad();
            }
            else
            {
                MessageBox.Show("Dosya Bulunamadı");
            }
        }

        private void cb_txtList_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (File.Exists(ApplicationData + "\\iFolderList\\file\\" + cb_txtList.Text))
            {
                StreamReader oku;

                oku = File.OpenText(ApplicationData + "\\iFolderList\\file\\" + cb_txtList.Text);
                while (!oku.EndOfStream)
                {
                    listBox1.Items.Add(oku.ReadLine());
                }
                oku.Close();

            }
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            int i;
            string[] folderFiles;

            for (i = 0; i <= listBox1.Items.Count - 1; i++)
            {
                try 
                {
                    string listItem = listBox1.Items[i].ToString();
                    if (listItem.ToString().IndexOf("'") == -1)
                    {
                        if (listItem.ToString().IndexOf(';') != -1)
                        {
                            folderFiles = listItem.Split(';'); // satırda ; karakteri varsa parçala
                            string folderPath = folderFiles[0].Trim().Trim('\t'); // ilk ifade dizin yapısı
                            string filePath = folderFiles[1].Trim().Trim('\t'); // ikinci ifade dosya veya dosya grubu adresi
                            // ikinci ifadenin ilk "file=", "folder=", "nfile=" ifadeleri ile başlamasına göre işlemi değiştir.
                            // "file=" ise adresi verilen dosyayı direk kopyalar
                            // "folder=" ise adresi verilen dizindeki dosyaların hepsini kopyalar
                            // "nfile=" ise adresi verilen dosyayı dizin yapısının oluşturulacağı klasör ismini başına ekleyerek kopyalar

                            if (!Directory.Exists(Program.folderPath + "\\" + folderPath)) // ilk olarak dizini oluştur
                            {
                                Directory.CreateDirectory(Program.folderPath + "\\" + folderPath);
                            }

                            if (filePath.Length > 7 && filePath.IndexOf('=') != -1) // başındaki ifadeden dolayı  en az 7 karaktere sahip ise işlemi yap
                            {
                                string preExpression = filePath.Substring(0, filePath.IndexOf('=') + 1);
                                switch (preExpression)
                                {
                                    case "file=":
                                        if (File.Exists(filePath.Replace("file=", "")))
                                        {
                                            File.Copy(filePath.Replace("file=", ""), Program.folderPath + "\\" + folderPath + "\\" + Path.GetFileName(filePath.Replace("file=", "")), true);
                                        }
                                        break;
                                    case "folder=":
                                        if (Directory.Exists(filePath.Replace("folder=", "")))
                                        {
                                            FolderCopy(filePath.Replace("folder=", ""), Program.folderPath + "\\" + folderPath);
                                        }
                                        break;
                                    case "nfile=":
                                        if (File.Exists(filePath.Replace("nfile=", "")))
                                        {
                                            string selectFolder = Program.folderPath.Substring(Program.folderPath.LastIndexOf("\\"));

                                            File.Copy(filePath.Replace("nfile=", ""), Program.folderPath + "\\" + folderPath + "\\" + selectFolder + Path.GetFileName(filePath.Replace("nfile=", "")), true);
                                        }
                                        break;
                                }
                            }
                        }
                        else if (!Directory.Exists(Program.folderPath + "\\" + listBox1.Items[i]))
                        {
                            Directory.CreateDirectory(Program.folderPath + "\\" + listBox1.Items[i]);
                        }
                    }

                    // Son Kullanılan Text Dosyasını Dosyaya Kaydet - Bidahaki açılışta o text dosyası ile gelsin
                    lastTxtFileWrite();
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Hata: " + ex.ToString());
                }

            }

            this.Close();
        }

        private void lastTxtFileWrite()
        {
            try
            {
                if (File.Exists(ApplicationData + "\\iFolderList\\lastTxtFile.txt"))
                {
                    File.Delete(ApplicationData + "\\iFolderList\\lastTxtFile.txt");
                }

                using (StreamWriter w = File.AppendText(ApplicationData + "\\iFolderList\\lastTxtFile.txt"))
                {
                    w.WriteLine(cb_txtList.Text);
                }

           }
            catch (Exception exp)
            {

            }
        }

        private void lastTxtFileRead()
        {
            try
            {
                if (File.Exists(ApplicationData + "\\iFolderList\\lastTxtFile.txt"))
                {
                    using (StreamReader r = new StreamReader(ApplicationData + "\\iFolderList\\lastTxtFile.txt"))
                    {
                        cb_txtList.Text = r.ReadLine();
                    }

                }


            }
            catch (Exception exp)
            {

            }
        }


        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (File.Exists(ApplicationData + "\\iFolderList\\file\\" + cb_txtList.Text))
            {
                System.Diagnostics.Process.Start(ApplicationData + "\\iFolderList\\file\\" + cb_txtList.Text);
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);

            }
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
               btn_create.PerformClick();
        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }

        private void btn_dirsearch_Click(object sender, EventArgs e)
        {
            DirSearch Dir = new DirSearch();
            Dir.Show();
        }


    }
}
