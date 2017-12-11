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
    /// <inheritdoc>
    ///     <cref></cref>
    /// </inheritdoc>
    /// <summary>
    ///     Interaction logic for PlanningAdd.xaml
    /// </summary>
    public partial class PlanningAdd
    {
        public PlanningAdd()
        {
            InitializeComponent();

            // Initialize the map in partial class
            InitializeMap();
        }
    }
}