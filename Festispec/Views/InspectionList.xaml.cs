using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Festispec.Views
{
    /// <summary>
    /// Interaction logic for InspectionList.xaml
    /// </summary>
    public partial class InspectionList
    {
        public InspectionList()
        {
            InitializeComponent();

            // Initialize the map in partial class
            InitializeMap();
        }
    }
}
