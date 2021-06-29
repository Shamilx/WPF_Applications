using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfApp6.MVVM.Model;
using WpfApp6.MVVM.ViewModel;
using Timer = System.Timers.Timer;

namespace WpfApplication16.MVVM.View
{

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private string _selectedUrl;
        private DispatcherTimer _timer;

        public Window1()
        {
            InitializeComponent();
        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CitySelected(sender);
        }
        
        public void CitySelected(object selectedCity)
        {
            string city = ((ListView)selectedCity).SelectedItem.ToString();
            _selectedUrl = "http://worldtimeapi.org/api/timezone/" + city;
            BindCity();
        }
        
        private CityTime GetSelectedCityTimeWithUrl(string url)
        {
            CityTime city;
            
            using (HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(url);
                string json = response.Result.Content.ReadAsStringAsync().Result;

                city = JsonSerializer.Deserialize<CityTime>(json);
            }

            return city;
        }

        private void BindCity()
        {
            _timer?.Stop();
            _timer = new DispatcherTimer();
            _timer.Tick += TimerOnCall;
            _timer.Interval = new TimeSpan(0,0,1);
            _timer.Start();
        }

        private void TimerOnCall(object sender, EventArgs e)
        {
            TextBlock1.Text = GetSelectedCityTimeWithUrl(_selectedUrl).ToString();
        }
    }
}
