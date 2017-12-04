using System;
using System.Collections.Generic;
using BruTile.Predefined;
using Festispec.Domain;
using Festispec.Helper;
using Festispec.ViewModels.Planning;
using Mapsui.Layers;
using Mapsui.Projection;

namespace Festispec.Views.Planning
{
    public partial class PlanningAdd
    {
        private Inspection _inspection;
        private PlanningAddViewModel _planningAddOrUpdateViewModel;

        public void InitializeMap()
        {
            _planningAddOrUpdateViewModel = DataContext as PlanningAddViewModel;
            if (_planningAddOrUpdateViewModel == null)
                throw new ArgumentNullException(nameof(PlanningListViewModel));
            _inspection = _planningAddOrUpdateViewModel.EntityViewModel.Inspection;

            MapHelper.InitializeMapOptions();

            _planningAddOrUpdateViewModel.Inspectors.CollectionChanged += (sender, args) => RefreshMap();
            RefreshMap();

            CenterMap();
        }

        private void RefreshMap()
        {
            // Clear all layers
            MapControl.Map.Layers.Clear();

            // Add base layer
            MapControl.Map.Layers.Add(new TileLayer(KnownTileSources.Create()));

            // Add marker for inspection
            MapControl.Map.Layers.Add(
                MapHelper.CreateInspectionMarkerWithLabel(_inspection.Long, _inspection.Lat, _inspection.Name));

            // Add markers for inspectors
            PopulateInspectorsOnMap(_planningAddOrUpdateViewModel.Inspectors);

            // Refresh the map
            MapControl.Refresh();
        }

        private void CenterMap()
        {
            // Get center from long lat
            var inspectionCentroid = SphericalMercator.FromLonLat(_inspection.Long, _inspection.Lat);
            // Navigate
            MapControl.Map.NavigateTo(inspectionCentroid);
            // Zoom
            MapControl.Map.NavigateTo(MapControl.Map.Resolutions[6]);
        }

        private void PopulateInspectorsOnMap(IEnumerable<Domain.Inspector> inspectors)
        {
            if (inspectors == null)
                return;

            foreach (var inspector in inspectors)
                // Add marker for inspector
                MapControl.Map.Layers.Add(
                    MapHelper.CreateInspectorMarkerWithLabel(inspector.Long, inspector.Lat, inspector.FullName));
        }
    }
}
