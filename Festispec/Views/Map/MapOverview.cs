using System;
using System.Collections.Generic;
using BruTile.Predefined;
using Festispec.Domain;
using Festispec.Helper;
using Festispec.ViewModels.Map;
using Mapsui.Layers;
using Mapsui.Projection;

namespace Festispec.Views.Map
{
    public partial class MapOverview
    {
        private MapOverviewViewModel _mapOverviewViewModel;

        public void InitializeMap()
        {
            _mapOverviewViewModel = DataContext as MapOverviewViewModel;
            if (_mapOverviewViewModel == null)
                throw new ArgumentNullException(nameof(MapOverviewViewModel));

            MapHelper.InitializeMapOptions();

            _mapOverviewViewModel.Inspectors.CollectionChanged += (sender, args) => RefreshMap();
            _mapOverviewViewModel.Inspections.CollectionChanged += (sender, args) => RefreshMap();
            _mapOverviewViewModel.Customers.CollectionChanged += (sender, args) => RefreshMap();
            RefreshMap();

            CenterMap();
        }

        private void RefreshMap()
        {
            // Clear all layers
            MapControl.Map.Layers.Clear();

            // Add base layer
            MapControl.Map.Layers.Add(new TileLayer(KnownTileSources.Create()));

            // Add markers for inspections
            PopulateInspectorsOnMap(_mapOverviewViewModel.Inspectors);
            // Add markers for inspections
            PopulateInspectionsOnMap(_mapOverviewViewModel.Inspections);
            // Add markers for customers
            PopulateCustomersOnMap(_mapOverviewViewModel.Customers);

            // Refresh the map
            MapControl.Refresh();
        }

        private void CenterMap()
        {
            // Get center from long lat
            var centroid = SphericalMercator.FromLonLat(5.28709, 51.68864);
            // Navigate
            MapControl.Map.NavigateTo(centroid);
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

        private void PopulateInspectionsOnMap(IEnumerable<Domain.Inspection> inspections)
        {
            if (inspections == null)
                return;

            foreach (var inspection in inspections)
                // Add marker for inspector
                MapControl.Map.Layers.Add(
                    MapHelper.CreateInspectionMarkerWithLabel(inspection.Long, inspection.Lat, inspection.Name));
        }

        private void PopulateCustomersOnMap(IEnumerable<Customer> customers)
        {
            if (customers == null)
                return;

            foreach (var customer in customers)
                // Add marker for inspector
                MapControl.Map.Layers.Add(
                    MapHelper.CreateCustomerMarkerWithLabel(customer.Long, customer.Lat, customer.FullName));
        }
    }
}