using System;
using System.Collections.Generic;
using BruTile.Predefined;
using Festispec.Domain;
using Festispec.Helper;
using Festispec.ViewModels.Planning;
using Mapsui.Layers;
using Mapsui.Projection;
using Mapsui.Styles;

namespace Festispec.Views.Planning
{
    /// <inheritdoc>
    ///     <cref></cref>
    /// </inheritdoc>
    /// <summary>
    ///     Interaction logic for PlanningAdd.xaml
    /// </summary>
    public partial class PlanningAdd
    {
        private readonly Inspection _inspection;
        private readonly PlanningAddOrUpdateViewModel _planningAddOrUpdateViewModel;

        public PlanningAdd()
        {
            InitializeComponent();

            _planningAddOrUpdateViewModel = DataContext as PlanningAddOrUpdateViewModel;
            if (_planningAddOrUpdateViewModel == null) throw new ArgumentNullException(nameof(PlanningListViewModel));
            _inspection = _planningAddOrUpdateViewModel.EntityViewModel.Inspection;

            InitializeMap();

            _planningAddOrUpdateViewModel.Inspectors.CollectionChanged += (sender, args) => PopulateInspectorsOnMap();
            PopulateInspectorsOnMap();
        }

        private void InitializeMap()
        {
            // Generate the map
            MapControl.Map.Layers.Add(new TileLayer(KnownTileSources.Create()));

            SymbolStyle.DefaultHeight = 16;
            SymbolStyle.DefaultWidth = 16;

            var inspectionCentroid = SphericalMercator.FromLonLat(_inspection.Long, _inspection.Lat);
            // Navigate
            MapControl.Map.NavigateTo(inspectionCentroid);
            // Zoom
            MapControl.Map.NavigateTo(MapControl.Map.Resolutions[6]);

            // Add marker for inspection
            MapControl.Map.Layers.Add(MapHelper.CreateInspectionMarkerWithLabel(_inspection.Long, _inspection.Lat, _inspection.Name));
        }

        private void PopulateInspectorsOnMap()
        {
            PopulateInspectorsOnMap(_planningAddOrUpdateViewModel.Inspectors);
        }
        private void PopulateInspectorsOnMap(IEnumerable<Domain.Inspector> inspectors)
        {
            if (inspectors == null) return;
            foreach (var inspector in inspectors)
            {
                // Add marker for inspector
                MapControl.Map.Layers.Add(MapHelper.CreateInspectorMarkerWithLabel(inspector.Long, inspector.Lat, inspector.FullName));
            }
        }
    }
}