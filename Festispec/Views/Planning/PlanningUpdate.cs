using System;
using BruTile.Predefined;
using Festispec.Domain;
using Festispec.Helper;
using Festispec.ViewModels.Planning;
using Mapsui.Layers;
using Mapsui.Projection;

namespace Festispec.Views.Planning
{
    public partial class PlanningUpdate
    {
        private Inspection _inspection;
        private PlanningAddOrUpdateViewModel _planningAddOrUpdateViewModel;

        public void InitializeMap()
        {
            _planningAddOrUpdateViewModel = DataContext as PlanningAddOrUpdateViewModel;
            if (_planningAddOrUpdateViewModel == null)
                throw new ArgumentNullException(nameof(PlanningListViewModel));
            _inspection = _planningAddOrUpdateViewModel.EntityViewModel.Inspection;

            MapHelper.InitializeMapOptions();

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

            // Add markers for inspector
            PopulateInspectorOnMap(_planningAddOrUpdateViewModel.EntityViewModel.Inspector);

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

        private void PopulateInspectorOnMap(Domain.Inspector inspector)
        {
            if (inspector == null)
                return;

            // Add marker for inspector
            MapControl.Map.Layers.Add(
                MapHelper.CreateInspectorMarkerWithLabel(inspector.Long, inspector.Lat, inspector.FullName));
        }
    }
}