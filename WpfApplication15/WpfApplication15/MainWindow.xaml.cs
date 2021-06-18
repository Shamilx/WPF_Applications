using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Serialization;
using System.Drawing;

namespace WpfApplication15
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string path = @"C:\uniquenametxtfiletosavecolorplsignoreme.txt";

        public MainWindow()
        {
            InitializeComponent();


            CreateFile();

            byte[] arr = GetValues();

            if (arr != null)
            {
                TextBlock1.Background = new SolidColorBrush(Color.FromRgb(arr[0], arr[1], arr[2]));
            }

            this.Closing += MainWindow_Closing;
        }

        public void CreateFile()
        {
            if(!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
        }

        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            using(StreamWriter writer = new StreamWriter(path))
            {
                var col = ((SolidColorBrush)superCombo.SelectedColor).Color;

                writer.WriteLine(col.R + "&" + col.G + "&" + col.B);
            }
        }

        byte[] GetValues()
        {
            string[] lines;

            using(StreamReader reader = new StreamReader(path))
            {
                string line = reader.ReadLine();
                if(line == "" || line == null)
                {
                    reader.Dispose();
                    return null;
                }

                lines = line.Split('&');
            }

            byte[] massive = new byte[3];

            massive[0] = Convert.ToByte(lines[0]);
            massive[1] = Convert.ToByte(lines[1]);
            massive[2] = Convert.ToByte(lines[2]);

            return massive;
        }
    }
}
