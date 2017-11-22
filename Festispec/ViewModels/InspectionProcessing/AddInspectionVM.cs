using Festispec.Domain;
using Festispec.ViewModels.InspectionProcessing;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Festispec.ViewModels.RequestProcessing
{
    public class AddInspectionVM : ViewModelBase
    {
        public InspectionListVM InspectionList { get; set; }
        public InspectionVM NewInspection { get; set; }
        public CustomerVM NewCustomer { get; set; }

        public ICommand AddInspectionCommand { get; set; }

        public AddInspectionVM(InspectionListVM InspectionList)
        {

        }

        public bool CanAddInspection()
        {
            if (NewInspection.Name != null && NewInspection.StartDate != null
                && NewInspection.EndDate != null
                && NewCustomer.City != null && NewCustomer.Country != null && NewCustomer.Email != null 
                && NewCustomer.FirstName != null && NewCustomer.LastName != null
                && NewCustomer.PostalCode != null && NewCustomer.Street!= null
                && NewCustomer.Telephone != null)
                return true;

            return false;
        }

        public void AddInspection()
        {
            if (CanAddInspection())
            {
                try
                {
                    using (var inspectionRepository = InspectionList.InspectionRepositoryFactory.CreateRepository())
                    {
                        inspectionRepository.Add(NewInspection.toModel());
                    }

                    InspectionList.InspectionVMList.Add(NewInspection);
                }
                catch(Exception e)
                {
                    MessageBox.Show("Er is iets fout gegaan met het toevoegen van een inspectie!");
                }

                return;
            }

            MessageBox.Show("Er is iets fout gegaan met het toevoegen van een inspectie!");
        }
    }
}
