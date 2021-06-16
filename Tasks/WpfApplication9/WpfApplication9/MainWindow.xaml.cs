using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TextBox1.IsReadOnly = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button bt = sender as Button;

            if (TextBox1.Text.Length < 10)
            {
                TextBox1.Text = TextBox1.Text + bt.Content;
            }
        }

        private void Delete_LastNumber(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text != "")
            {
                TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1);
            }
        }

        private void Delete_All(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = "";
            TextBlock1.Text = "";
        }


        private void Delete_Last(object sender, RoutedEventArgs e)
        {
            TextBox1.Clear();
        }

        private void Sum_Button(object sender, RoutedEventArgs e)
        {
            if(TextBlock1.Text == "")
            {
                TextBlock1.Text = TextBox1.Text + " + ";
                TextBox1.Text = "";
            }
            else if (TextBox1.Text != "")
            {
                Display_Answer(sender, e);

                TextBlock1.Text = TextBox1.Text + " + ";
                TextBox1.Text = "";
            }
        }

        private void Display_Answer(object sender, RoutedEventArgs e)
        {
            if(TextBox1.Text != "" && TextBlock1.Text != "")
            {
                string problem = TextBlock1.Text + TextBox1.Text;

                DataTable dt = new DataTable();

                int answer = 0;

                try
                {
                    answer = Convert.ToInt32(dt.Compute(problem, ""));
                }
                catch(Exception)
                {
                    MessageBox.Show("This number is so much!");
                    return;
                }

                TextBlock1.Text = "";
                TextBox1.Text = answer.ToString();
            }
        }

        private void Subtraction_Click(object sender,RoutedEventArgs e)
        {
            if (TextBlock1.Text == "")
            {
                TextBlock1.Text = TextBox1.Text + " - ";
                TextBox1.Text = "";
            }
            else if (TextBox1.Text != "")
            {
                Display_Answer(sender, e);

                TextBlock1.Text = TextBox1.Text + " - ";
                TextBox1.Text = "";
            }
        }

        private void Multiplaction_Click(object sender, RoutedEventArgs e)
        {
            if (TextBlock1.Text == "")
            {
                TextBlock1.Text = TextBox1.Text + " * ";
                TextBox1.Text = "";
            }
            else if(TextBox1.Text != "")
            {
                Display_Answer(sender, e);

                TextBlock1.Text = TextBox1.Text + " * ";
                TextBox1.Text = "";
            }
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            if (TextBlock1.Text == "")
            {
                TextBlock1.Text = TextBox1.Text + " / ";
                TextBox1.Text = "";
            }
            else if (TextBox1.Text != "")
            {
                Display_Answer(sender, e);

                TextBlock1.Text = TextBox1.Text + " / ";
                TextBox1.Text = "";
            }
        }

        private void Percentage_Click(object sender, RoutedEventArgs e)
        {
            if (TextBlock1.Text == "")
            {
                TextBlock1.Text = TextBox1.Text + " % ";
                TextBox1.Text = "";
            }
            else if (TextBox1.Text != "")
            {
                Display_Answer(sender, e);

                TextBlock1.Text = TextBox1.Text + " % ";
                TextBox1.Text = "";
            }
        }

        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            if(TextBlock1.Text == "")
            {
                TextBox1.Text = Math.Sqrt(Convert.ToInt32(TextBox1.Text)).ToString();
            }
        }
    }
}
