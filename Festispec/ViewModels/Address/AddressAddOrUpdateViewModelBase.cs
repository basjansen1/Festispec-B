using System;
using System.Windows;
using System.Windows.Input;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Domain.Repository.Interface;
using Festispec.NavigationService;
using Festispec.ViewModels.Factory.Interface;
using Festispec.ViewModels.Interface;
using GalaSoft.MvvmLight.CommandWpf;

namespace Festispec.ViewModels.Address
{
    public abstract class
        AddressAddOrUpdateViewModelBase<TViewModelFactory, TEntityViewModel, TRepository, TEntity> :
            AddOrUpdateViewModelBase<TViewModelFactory, TEntityViewModel, TRepository, TEntity>
        where TViewModelFactory : IViewModelFactory<TEntityViewModel, TEntity>
        where TEntityViewModel : class, IAddressViewModel<TEntity>
        where TRepository : IRepository<TEntity>
        where TEntity : class, IAddress
    {
        private readonly IGeoRepositoryFactory _geoRepositoryFactory;

        protected AddressAddOrUpdateViewModelBase(INavigationService navigationService,
            IRepositoryFactory<TRepository, TEntity> repositoryFactory, TViewModelFactory viewModelFactory,
            IGeoRepositoryFactory geoRepositoryFactory) : base(
            navigationService, repositoryFactory, viewModelFactory)
        {
            _geoRepositoryFactory = geoRepositoryFactory;

            SearchAddressCommand = new RelayCommand(() => SearchAddress());
        }

        public ICommand SearchAddressCommand { get; set; }

        protected bool SearchAddress()
        {
            using (var geoRepository = _geoRepositoryFactory.CreateRepository())
            {
                try
                {
                    var address = geoRepository.Find(EntityViewModel.PostalCode,
                        EntityViewModel.HouseNumber);

                    EntityViewModel.Street = address.Street;
                    EntityViewModel.City = address.City;
                    EntityViewModel.Municipality = address.Municipality;
                    EntityViewModel.Country = address.Country;
                    EntityViewModel.Lat = address.Lat;
                    EntityViewModel.Long = address.Long;
                    EntityViewModel.Location = address.Location;

                    return true;
                }
                catch (ArgumentNullException exception)
                {
                    switch (exception.ParamName)
                    {
                        case "PostalCode":
                        case "HouseNumber":
                            MessageBox.Show("Geef een postcode en huisnummer op");
                            break;
                        case "json":
                            MessageBox.Show(
                                $"Geen adres gevonden op {EntityViewModel.PostalCode} {EntityViewModel.HouseNumber}");
                            break;
                        default:
                            // TODO: Generic error message instead of exception message: MessageBox.Show("Er is iets fout gegaan");
                            MessageBox.Show("Er is iets fout gegaan, zorg dat al de velden correct zijn ingevuld.");
                            break;
                    }
                }
                catch (InvalidOperationException exception)
                {
                    // TODO: Generic error message instead of exception message: MessageBox.Show("Er is iets fout gegaan");
                    MessageBox.Show(exception.Message);
                }
            }

            return false;
        }

        public override void Save()
        {
            if (!SearchAddress())
                return;

            base.Save();
        }
    }
}