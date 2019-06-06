using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using System.Windows.Media;
using System.Linq;

namespace Gabrielli.Gianmarco._5I.WpfWeather
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        async private void Visualizzazione(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();
                List<Meteo> meteo = new List<Meteo>() { JsonConvert.DeserializeObject<Meteo>(await client.GetStringAsync("https://samples.openweathermap.org/data/2.5/weather?q=London,uk&appid=b6907d289e10d714a6e88b30761fae22")) };
                lv_Dati.ItemsSource = meteo;
            }
            catch (Exception errore)
            {
                MessageBox.Show(errore.Message);
            }
        }
        public class Coord
        {
            public double lon { get; set; }
            public double lat { get; set; }

            public override string ToString()
            {
                return $"Lon:{lon} - Lat:{lat}";
            }
        }

        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class Main
        {
            public double temp { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public override string ToString()
            {
                return $"Temp:{temp}, Pressione:{pressure}";
            }
        }

        public class Wind
        {
            public double speed { get; set; }
            public int deg { get; set; }
        }

        public class Clouds
        {
            public int all { get; set; }
        }

        public class Sys
        {
            public int type { get; set; }
            public int id { get; set; }
            public double message { get; set; }
            public string country { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
        }
        public class Meteo
        {
            public Coord coord { get; set; }
            public IEnumerable<Weather> weather { get; set; }
            public string Base { get; set; }
            public Main main { get; set; }
            public int visibility { get; set; }
            public Wind wind { get; set; }
            public Clouds clouds { get; set; }
            public int dt { get; set; }
            public Sys sys { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int cod { get; set; }
        }
    }
}
