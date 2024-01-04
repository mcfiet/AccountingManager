using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{
    public class NewClientWindowViewModel
    {
        public String IncomingMessage { get; set; }

        public string Name { get; set; }

        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public ICommand AddClient { get; }
        public RelayCommand CloseWindow { get; }

        private ClientCollectionViewModel clientCollection;

        AdministrationViewModel AdministrationViewModel;

        public NewClientWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {
            AddClient = new RelayCommand(AddClientMethod);
            CloseWindow = new RelayCommand(param => CloseWPFWindow(param));

            AdministrationViewModel = givenAdministrationViewModel;
            clientCollection = AdministrationViewModel.Clients;
        }

        private void AddClientMethod()
        {
            Console.Out.WriteLine(IncomingMessage);
            ClientViewModel cvm = new ClientViewModel
            {
                Id = AdministrationViewModel.Model.getClientIdFromCreation(),
                Name = Name,
                Street = Street,
                HouseNumber = HouseNumber,
                ZipCode = ZipCode,
                City = City
            };
            clientCollection.Add(cvm);

        }
        private void CloseWPFWindow(object param)
        {
            Window window = (Window)param;
            window.Close();
        }
    }
}
