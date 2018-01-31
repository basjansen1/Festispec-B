using BruTile.Predefined;
using Festispec.Helper;
using Mapsui.Layers;
using Mapsui.Projection;
using System;
using System.Collections.Generic;
using System.Linq;
using BruTile.Predefined;
using Festispec.Domain;
using Festispec.Helper;
using Festispec.ViewModels.Inspection;
using Mapsui.Layers;
using Mapsui.Projection;

namespace Festispec.Views
{
    public partial class InspectionList
    {
        private InspectionListVM _inspectionListViewModel;

        public void InitializeMap()
        {
            _inspectionListViewModel = DataContext as InspectionListVM;
            if (_inspectionListViewModel == null)
                throw new ArgumentNullException(nameof(InspectionListVM));
            //_inspection = _inspectionListViewModel.Inspection;

            MapHelper.InitializeMapOptions();

            _inspectionListViewModel.InspectionVMList.CollectionChanged += (sender, args) => RefreshMap();
            RefreshMap();

            CenterMap();
        }

        private void RefreshMap()
        {
            // Clear all layers
            MapControl.Map.Layers.Clear();

            // Add base layer
            MapControl.Map.Layers.Add(new TileLayer(KnownTileSources.Create()));

            // Add markers for inspectors
            PopulateInspectionsOnMap(
                _inspectionListViewModel.InspectionVMList.Select(inspectionViewModel => inspectionViewModel.Entity));

            // Refresh the map
            MapControl.Refresh();
        }

        private void CenterMap()
        {
            // Get center from long lat
            var inspectionCentroid = SphericalMercator.FromLonLat(5.28709, 51.68864);
            // Navigate
            MapControl.Map.NavigateTo(inspectionCentroid);
            // Zoom
            MapControl.Map.NavigateTo(MapControl.Map.Resolutions[6]);
        }

        private void PopulateInspectionsOnMap(IEnumerable<Domain.Inspection> inspections)
        {
            if (inspections == null)
                return;

            foreach (var inspection in inspections)
                // Add marker for inspector
                MapControl.Map.Layers.Add(
                    MapHelper.CreateInspectorMarkerWithLabel(inspection.Long, inspection.Lat, inspection.Name));
        }
    }
}
