using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Controls;
using WpfApp6.MVVM.Model;

namespace WpfApp6.MVVM.ViewModel
{
    public class TimeProviderVm
    {
        public ObservableCollection<string> Cities { get; set; }
        public const string CitiesUrl = "http://worldtimeapi.org/api/timezone/";
        
        private ObservableCollection<string> GetCities()
        {
            var obsCol = new ObservableCollection<string>();

            using (HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(CitiesUrl);
                string json = response.Result.Content.ReadAsStringAsync().Result;

                string[] cities = JsonSerializer.Deserialize<string[]>(json);

                if (cities != null)
                    foreach (var i in cities)
                    {
                        obsCol.Add(i);
                    }
            }

            return obsCol;
        }
        
        public TimeProviderVm()
        {
            Cities = GetCities();
        }
    }
}
