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
using System.Timers;
using System.Windows.Threading;
using System.Threading;

namespace Keyboard_Tester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool capsLocked = false;
        private bool gameStarted = false;
        private int passedTime;
        private int correctWords;
        private int mistakeWords;
        private int currentWords;
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();


            capsLocked = Keyboard.IsKeyToggled(Key.CapsLock);
            if (capsLocked) MakeEverythingBig();

            this.Closing += OnClosing;

            passedTime = 0;
            correctWords = 0;
            mistakeWords = 0;
            currentWords = 0;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift && capsLocked == false)
            {
                MakeEverythingBig();
            }

            if (e.Key == Key.CapsLock && e.IsRepeat == false)
            {
                capsLocked = !capsLocked;

                if (capsLocked == true)
                {
                    MakeEverythingBig();
                }
                else
                {
                    MakeEverythingLittle();
                }
            }

            if (e.Key == Key.Enter && gameStarted)
            {
                CheckWord();
            }

            //foreach (StackPanel child in StackPanelButtons.Children)
            //{
            //    foreach (Button childButton in child.Children)
            //    {
            //        string pressedKey = childButton.Content.ToString();
            //        string key = e.Key.ToString();

            //        if (pressedKey.ToLower() == key.ToLower())
            //        {
            //            // highlight button
            //        }
            //    }
            //}
        }

        private void MakeEverythingBig()
        {
            char asci;

            foreach (StackPanel child in StackPanelButtons.Children)
            {
                foreach (Button childButton in child.Children)
                {
                    if (childButton.Content.ToString().Length == 1)
                    {
                        asci = childButton.Content.ToString()[0];
                        if (asci >= 'a' && asci <= 'z') { childButton.Content = Char.ToUpper(asci); }
                        else if (asci == '`') { childButton.Content = "~"; }
                        else if (asci == '1') { childButton.Content = "!"; }
                        else if (asci == '2') { childButton.Content = "@"; }
                        else if (asci == '3') { childButton.Content = "#"; }
                        else if (asci == '4') { childButton.Content = "$"; }
                        else if (asci == '5') { childButton.Content = "%"; }
                        else if (asci == '6') { childButton.Content = "^"; }
                        else if (asci == '7') { childButton.Content = "&"; }
                        else if (asci == '8') { childButton.Content = "*"; }
                        else if (asci == '9') { childButton.Content = "("; }
                        else if (asci == '0') { childButton.Content = ")"; }
                        else if (asci == '-') { childButton.Content = "_"; }
                        else if (asci == '=') { childButton.Content = "+"; }
                        else if (asci == '[') { childButton.Content = "{"; }
                        else if (asci == ']') { childButton.Content = "}"; }
                        else if (asci == ';') { childButton.Content = ":"; }
                        else if (asci == '\'') { childButton.Content = "\""; }
                        else if (asci == '\\') { childButton.Content = "|"; }
                        else if (asci == ',') { childButton.Content = "<"; }
                        else if (asci == '.') { childButton.Content = ">"; }
                        else if (asci == '/') { childButton.Content = "?"; }
                    }
                }
            }
        }

        private void MakeEverythingLittle()
        {
            char asci;
            foreach (StackPanel child in StackPanelButtons.Children)
            {
                foreach (Button childButton in child.Children)
                {
                    if (childButton.Content.ToString().Length == 1)
                    {
                        asci = childButton.Content.ToString()[0];

                        if (asci >= 'A' && asci <= 'Z') { childButton.Content = Char.ToLower(asci); }
                        else if (asci == '~') { childButton.Content = "`"; }
                        else if (asci == '!') { childButton.Content = "1"; }
                        else if (asci == '@') { childButton.Content = "2"; }
                        else if (asci == '#') { childButton.Content = "3"; }
                        else if (asci == '$') { childButton.Content = "4"; }
                        else if (asci == '%') { childButton.Content = "5"; }
                        else if (asci == '^') { childButton.Content = "6"; }
                        else if (asci == '&') { childButton.Content = "7"; }
                        else if (asci == '*') { childButton.Content = "8"; }
                        else if (asci == '(') { childButton.Content = "9"; }
                        else if (asci == ')') { childButton.Content = "0"; }
                        else if (asci == '_') { childButton.Content = "-"; }
                        else if (asci == '+') { childButton.Content = "="; }
                        else if (asci == '{') { childButton.Content = "["; }
                        else if (asci == '}') { childButton.Content = "]"; }
                        else if (asci == ':') { childButton.Content = ";"; }
                        else if (asci == '"') { childButton.Content = "'"; }
                        else if (asci == '|') { childButton.Content = "\\"; }
                        else if (asci == '<') { childButton.Content = ","; }
                        else if (asci == '>') { childButton.Content = "."; }
                        else if (asci == '?') { childButton.Content = "/"; }
                    }
                }
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift && capsLocked == false)
            {
                MakeEverythingLittle();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(IncreaseTime);
            timer.Interval = new TimeSpan(0, 0, 1);
            gameStarted = true;
            ShowWords();
            timer.Start();
        }

        private void IncreaseTime(object sender, EventArgs e)
        {
            Time.Text = passedTime.ToString();
            passedTime++;

            if (passedTime == 60)
            {
                Stop();
            }
        }


        private void OnClosing(object sender, EventArgs e)
        {
            if (timer != null)
                timer.Stop();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            Stop();
        }

        private void Stop()
        {
            if (timer != null)
            {
                timer.Stop();
            }

            btnStop.IsEnabled = false;
            btnStart.IsEnabled = true;

            MessageBox.Show("Time : " + passedTime + " Correct : " + correctWords + " Mistake : " + mistakeWords);

            passedTime = 0;
            Time.Text = "0";
            currentWords = 0;
            mistakeWords = 0;
            correctWords = 0;
            gameStarted = false;

            TextBlock1.Text = "";
        }

        private void CheckWord()
        {
            string TextBoxText = TextBox1.Text;
            string TextBlockText = TextBlock1.Text;

            string[] wordsToFill = TextBlockText.Split(' ');
            string[] wordsFilled = TextBoxText.Split(' ');


            for (int i = 0; i < wordsToFill.Length;i++)
            {
                try
                {
                    if (wordsToFill[i] == wordsFilled[i])
                    {
                        correctWords++;
                    }
                    else
                    {
                        mistakeWords++;
                    }
                }
                catch(Exception)
                {
                    break;
                }
            }

            ShowWords();
        }

        private void ShowWords()
        {
            TextBlock1.Text = "example words Click Enter After Completing Please Thanks Thanks again";
            currentWords++;
        }
    }
}
