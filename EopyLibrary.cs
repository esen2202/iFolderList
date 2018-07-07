using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
namespace EopyLibrary
{
    class EopyStreamFiling
    {
        private static String execPath;

        public static String ExecPath
        {
            get
            {
                return execPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) ;  ;
            }
            set { execPath = value; }
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        private FileStream aFile;
        private StreamWriter sw;
        private StreamReader sr;
        private List<string[,]> _myData; // Dosya içeriğinin listelenmiş şekli
        public List<string[,]> MyData
        {
            get { return _myData; }
            set { _myData = value; }
        }

        private string _fileANT;
        public string FileANT
        {
            get { return _fileANT; }
            set { _fileANT = value.Replace("\\", "/"); }
        }

        public EopyStreamFiling(string fileANT)
        {
            this.FileANT = fileANT;
        } // initialize 

        public void openFileRead()
        {

            this.aFile = new FileStream(this.FileANT, FileMode.Open);
            this.sr = new StreamReader(this.aFile);
        }

        public void openFileAppend()
        {
            this.aFile = new FileStream(this.FileANT, FileMode.Append);
            this.sw = new StreamWriter(this.aFile);
        }

        public void closeFile()
        {
            if (this.sw != null) this.sw.Close();
            if (this.sr != null) this.sr.Close();
        }

        private List<string[,]> GetData(out List<string> columns)
        {
            string strLine; // Dosya Sonuna Kadar Tek Tek Satırları Tutar
            string[] strArray; // Satırları Okur
            char[] charArray = new char[] { ',' }; // Satırları Kolonlara Bölen Karakter
            //List<Dictionary<string, string>> data = new List<Dictionary<string, string>>(); // List arrayın her eklenen elemanı Key(kolon ismi) ve Value(değeri) olarak 2elemanlı string tutar bir tablo yapısı oluşturur 
            columns = new List<string>(); // 

            List<string[,]> TrendArray = new List<string[,]>(); // içinde 2 boyutlu her elemanının 2 boyutlu dizisi olan list array oluşturur


            int k = 0;
            // Obtain the columns from the first line.
            // Split row of data into string array

            //strLine = this.sr.ReadLine();
            //strLine = "DateTime,Value"; // kolonları el ile ekledim normalde ilk kayıttan alıyordu
            //strArray = strLine.Split(charArray);
            //for (int x = 0; x <= strArray.GetUpperBound(0); x++)
            //{
            //    columns.Add(strArray[x]);
            //}

            strLine = this.sr.ReadLine();
            while (strLine != null)
            {
                // Split row of data into string array
                strArray = strLine.Split(charArray);
                //Dictionary<string, string> dataRow = new Dictionary<string, string>();
                string[,] satir = new string[1, strArray.Length];
                for (int x = 0; x <= strArray.GetUpperBound(0); x++)
                {
                    //dataRow.Add(columns[x], strArray[x]);
                    satir[0, x] = strArray[x]; // 

                }
                TrendArray.Add(satir);
                //data.Add(dataRow);

                strLine = this.sr.ReadLine();
                k++;
            }
            return TrendArray;
        }

        public void dataWriter(String Date, String MilliSecond, String Value1, String Value2, String Value3, String Value4)
        {
            // Write data to file.
            this.sw.WriteLine(Date + "," + MilliSecond + "," + Value1 + "," + Value2 + "," + Value3 + "," + Value4);
        }

        public void dataWriter(String Date, String MilliSecond, String Value)
        {
            // Write data to file.
            this.sw.WriteLine(Date + "," + MilliSecond + "," + Value);
        }

        public void dataWriter(String Key, String Value)
        {
            // Write data to file.
            this.sw.WriteLine(Key + "," + Value);
        }

        public void dataWriter(String Value1)
        {
            // Write data to file.
            this.sw.WriteLine(Value1);
        }

        public void dataReader()
        {
            // Dosyadan Okuyup Consol a Yazdırma
            List<string> columns;
            this.MyData = GetData(out columns);

            //// Kolon isimlerini okur
            //foreach (string column in columns)
            //{
            //    Console.Write("{0,-25}", column);
            //}

            //// Satır ve Kolonları Okur
            //foreach (Dictionary<string, string> row in myData)
            //{
            //    foreach (string column in columns)
            //    {
            //        Console.Write("{0,-25}", row[column]);
            //    }

            //}
        }
    }

}
