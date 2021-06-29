using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WpfApplication19.MVVM.Model;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;

namespace WpfApplication19.MVVM.ViewModel
{
    public class SwapiVM
    {
        public ObservableCollection<Planet> MyPlanets { get; set; }

        public SwapiVM()
        {
            MyPlanets = GetPlanets();
        }

        private ObservableCollection<Planet> GetPlanets()
        {
            ObservableCollection<Planet> planets = new ObservableCollection<Planet>();

            for (int i = 1; i < 60; i++)
            {
                string url = "https://swapi.dev/api/planets/" + i;

                using (HttpClient httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync(url);
                    string json = response.Result.Content.ReadAsStringAsync().Result;

                    Planet planet = JsonConvert.DeserializeObject<Planet>(json);
                    planets.Add(planet);
                }

            }

            return planets;
        }
    }
}
