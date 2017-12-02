using System;
using System.Collections.Generic;
using System.Linq;
using BruTile.Predefined;
using Festispec.Helper;
using Festispec.ViewModels.Planning;
using Mapsui.Layers;
using Mapsui.Projection;
using Mapsui.Providers;
using Mapsui.Styles;

namespace Festispec.Views.Planning
{
    /// <inheritdoc>
    ///     <cref></cref>
    /// </inheritdoc>
    /// <summary>
    ///     Interaction logic for PlanningList.xaml
    /// </summary>
    public partial class PlanningList
    {
        private readonly PlanningListViewModel _planningListViewModel;

        public PlanningList()
        {
            InitializeComponent();

            _planningListViewModel = DataContext as PlanningListViewModel;
            if (_planningListViewModel == null) throw new ArgumentNullException(nameof(PlanningListViewModel));
            
            InitializeMap();

            _planningListViewModel.Plannings.CollectionChanged += (sender, args) => PopulateInspectorsOnMap();
            PopulateInspectorsOnMap();
        }

        private void InitializeMap()
        {
            // Generate the map
            MapControl.Map.Layers.Add(new TileLayer(KnownTileSources.Create()));

            SymbolStyle.DefaultHeight = 16;
            SymbolStyle.DefaultWidth = 16;

            var inspectionCentroid = SphericalMercator.FromLonLat(_planningListViewModel.Inspection.Long, _planningListViewModel.Inspection.Lat);
            // Navigate
            MapControl.Map.NavigateTo(inspectionCentroid);
            // Zoom
            MapControl.Map.NavigateTo(MapControl.Map.Resolutions[6]);

            // Add marker for inspection
            MapControl.Map.Layers.Add(MapHelper.CreateInspectionMarkerWithLabel(_planningListViewModel.Inspection.Long, _planningListViewModel.Inspection.Lat, _planningListViewModel.Inspection.Name));
        }

        private void PopulateInspectorsOnMap()
        {
            PopulateInspectorsOnMap(_planningListViewModel.Plannings.Select(planningViewModel => planningViewModel.Inspector));

        }
        private void PopulateInspectorsOnMap(IEnumerable<Domain.Inspector> inspectors)
        {
            foreach (var inspector in inspectors)
            {
                // Add marker for inspector
                MapControl.Map.Layers.Add(MapHelper.CreateInspectorMarkerWithLabel(inspector.Long, inspector.Lat, inspector.FullName));
            }
        }

        
    }
}