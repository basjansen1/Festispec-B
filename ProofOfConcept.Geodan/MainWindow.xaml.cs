using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using BruTile.Predefined;
using Mapsui.Geometries;
using Mapsui.Geometries.WellKnownText;
using Mapsui.Layers;
using Mapsui.Projection;
using Mapsui.Providers;
using Mapsui.Styles;
using Newtonsoft.Json;
using Point = Mapsui.Geometries.Point;

namespace ProofOfConcept.Geodan
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
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
            
//            var layer = new Layer
//            {
//                DataSource = new MemoryProvider(geometry),
//                Style = new VectorStyle
//                {
//                    Fill = new Brush(new Color(150, 150, 30, 128)),
//                    Outline = new Pen(Color.Orange, 2),
//                }
//            };
//            MyMapControl.Map.Layers.Add(layer);

            // Get centroid and convert from lonlat to spherical mercator
            var centroid = geometry.GetBoundingBox().GetCentroid();
            var centroidFromLonLat = SphericalMercator.FromLonLat(centroid.X, centroid.Y);
            
            // Add point
            MyMapControl.Map.Layers.Add(new Layer
            {
                DataSource = new MemoryProvider(centroidFromLonLat),
                Style = new VectorStyle { Fill = new Brush(Color.Blue) }
            });

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
                return GetFirstAddress(json.response.docs);
//                return json.response.docs[0].geom;
            }
        }

        public string GetFirstAddress(dynamic docs)
        {
            for (int i = 0, l = docs.Count; i < l; i++)
            {
                if (docs[i].type == "address") return docs[i].geom;
            }
            return null;
        }
    }
}