using Mapsui.Geometries;
using Mapsui.Layers;
using Mapsui.Projection;
using Mapsui.Providers;
using Mapsui.Styles;

namespace Festispec.Helper
{
    public class MapHelper
    {
        public static void InitializeMapOptions()
        {
            SymbolStyle.DefaultHeight = 16;
            SymbolStyle.DefaultWidth = 16;
        }

        public static ILayer CreateInspectorMarkerWithLabel(double lon, double lat, string text)
        {
            return CreateMarkerWithLabel(lon, lat, text, Color.Blue);
        }

        public static ILayer CreateInspectionMarkerWithLabel(double lon, double lat, string text)
        {
            return CreateMarkerWithLabel(lon, lat, text, Color.Yellow);
        }

        public static ILayer CreateMarkerWithLabel(double lon, double lat, string text, Color color)
        {
            // Prepare marker
            var geometry = SphericalMercator.FromLonLat(lon, lat);
            var memoryProvider = new MemoryProvider(geometry);
            var style = new VectorStyle {Fill = new Brush(color)};

            // Create label
            memoryProvider.Features.Add(CreateLabel(geometry, text));

            var layer = new Layer
            {
                DataSource = memoryProvider,
                Style = style
            };
            return layer;
        }

        public static IFeature CreateLabel(IGeometry geometry, string text)
        {
            var labelFeature = new Feature {Geometry = geometry};
            var labelStyle = new LabelStyle
            {
                Text = text,
                HorizontalAlignment = LabelStyle.HorizontalAlignmentEnum.Left,
                Offset = new Offset {X = 8}
            };
            labelFeature.Styles.Add(labelStyle);
            return labelFeature;
        }
    }
}