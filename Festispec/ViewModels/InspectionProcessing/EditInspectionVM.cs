﻿using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Festispec.ViewModels.Employees
{
    public class EditInspectionVM : ViewModelBase
    {
        // getters and setters
        public InspectionVM InspectionVM { get; set; }

        // commands
        public ICommand EditInspectionCommand { get; set; }

        // fields

        // constructors
        public EditInspectionVM(InspectionVM InspectionVM)
        {

        }

        // methods
        public bool CanEditInspection()
        {
            if (InspectionVM.Name != null && InspectionVM.StartDate != null
                 && InspectionVM.EndDate != null)
                return true;

            return false;
        }

        public void SaveChanges()
        {
            if (CanEditInspection())
            {

            }
        }
    }
}
