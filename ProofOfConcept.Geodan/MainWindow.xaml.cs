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
using Mapsui.Projection;
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

            // Generate the map
            MyMapControl.Map.Layers.Add(new TileLayer(KnownTileSources.Create()));
            
            searchButton.Click += OnSearch;
        }

        private void OnSearch(object sender, RoutedEventArgs e)
        {
            // Get UI input
            var searchText = searchTextBox.Text;
            var type = typeComboBox.SelectionBoxItem as string;

            // Find address by input
            var data = FindAddress(searchText, type);

            // No data found
            if (data == null) return;

            // Parse data to geometry with GeometryFromWKT
            var geometry = GeometryFromWKT.Parse(data);

            // Get centroid and convert from lonlat to spherical mercator
            var centroid = geometry.GetBoundingBox().GetCentroid();
            var centroidFromLonLat = SphericalMercator.FromLonLat(centroid.X, centroid.Y);

            // Navigate
            MyMapControl.Map.NavigateTo(centroidFromLonLat);
            // Zoom
            MyMapControl.Map.NavigateTo(MyMapControl.Map.Resolutions[16]);
        }

        public string FindAddress(string query, string type)
        {
            // Check for type
            if (!string.IsNullOrEmpty(type))
            {
                query += $" AND type:{type}";
            }
            return FindAddress(query);
        }

        public string FindAddress(string query)
        {
            // Build url with query
            var url =
                $"https://services.geodan.nl/geosearch/free?q={query}&q.op=OR&wt=json&start=0&rows=10&servicekey=19aca9fb-6705-11e7-a442-005056805b87";

            // Get http
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(url).Result;

                dynamic json = JsonConvert.DeserializeObject(response);
                
                if (json.response.docs == null || json.response.docs.Count == 0)
                {
                    return null;
                }

                // Return geometry data
                return json.response.docs[0].geom;
            }
        }
    }
}
