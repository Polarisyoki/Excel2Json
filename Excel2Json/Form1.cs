using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Excel2Json
{
    public partial class Form1 : Form
    {


        [DllImport("user32", EntryPoint = "HideCaret")]

        private static extern bool HideCaret(IntPtr hWnd);
        private MyExcelFunction.ExcelType curExcelType;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Url1.GotFocus += Url1_GotFocus;
            Url1.MouseDown += Url1_MouseDown;
            Option_encoding_comboBox.SelectedIndex = 0;
            Option_header_comboBox.SelectedIndex = 0;
            Option_dataformat_comboBox.SelectedIndex = 0;
        }

        private void Bt1_Click(object sender, EventArgs e)
        {
            string fileName;
            using (OpenFileDialog OpenFD = new OpenFileDialog())     //实例化一个 OpenFileDialog 的对象
            {
                OpenFD.Filter = @"Excel文件(*.xls,*.xlsx,*.csv)|*.xls;*.xlsx;*.csv";
                OpenFD.RestoreDirectory = true;
                //定义打开的默认文件夹位置
                //OpenFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                OpenFD.ShowDialog();
                fileName = OpenFD.FileName;

                if (fileName.IndexOf(":") < 0)
                    return;//点了取消

                string[] str = fileName.Split('.');
                switch (str[str.Length - 1].ToLower())
                {
                    case "xls":
                        curExcelType = MyExcelFunction.ExcelType.XLS;
                        Url1.Text = fileName;
                        break;
                    case "xlsx":
                        curExcelType = MyExcelFunction.ExcelType.XLSL;
                        Url1.Text = fileName;
                        break;
                    case "csv":
                        curExcelType = MyExcelFunction.ExcelType.CSV;
                        Url1.Text = fileName;
                        break;
                    default:                        
                        break;

                }

            }
        }
        private void Output_Click(object sender, EventArgs e)
        {
            string fileName;
            using (SaveFileDialog OpenFD = new SaveFileDialog())     //实例化一个 OpenFileDialog 的对象
            {
                OpenFD.Filter = @"Json文件(*.json)|*.json";
                OpenFD.RestoreDirectory = true;
                //定义打开的默认文件夹位置
                OpenFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                OpenFD.ShowDialog();
                fileName = OpenFD.FileName;

                if (fileName.IndexOf(":") < 0) return;//点了取消

                try
                {
                    MyExcelFunction.Transform(Url1.Text, fileName, curExcelType, Option_header_comboBox.SelectedIndex);
                }
                catch
                {
                    MessageBox.Show("哎呀！哪里出错了！");
                }
                
            }
        }

        void Url1_GotFocus(object sender, EventArgs e)
        {
            HideCaret((sender as TextBox).Handle);
        }

        void Url1_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret((sender as TextBox).Handle);
        }


    }
}
