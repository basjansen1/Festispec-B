using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using BruTile.Predefined;
using Mapsui.Geometries.WellKnownText;
using Mapsui.Layers;
using Newtonsoft.Json;

namespace ProofOfConcept.Geodan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MyMapControl.Map.Layers.Add(new TileLayer(KnownTileSources.Create()));

            searchButton.Click += OnSearch;
        }

        private async void OnSearch(object sender, RoutedEventArgs e)
        {
            var searchText = searchTextBox.Text;

            var data = FindAddress(searchText);

            // WKT Parser
            var geometry = GeometryFromWKT.Parse(data);

            var a = geometry;
        }

        public string FindAddress(string query)
        {
            var url = $"https://services.geodan.nl/geosearch/free?q=" + query +
                      "&q.op=OR&wt=json&start=0&rows=10&servicekey=19aca9fb-6705-11e7-a442-005056805b87";

            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(url).Result;

                dynamic json = JsonConvert.DeserializeObject(response);

                return json.response.docs[0].geom;
            }
        }
}
}
