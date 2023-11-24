using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp078.Services.MessageBus;
using De.HsFlensburg.ClientApp078.Services.SerializationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{
    public class ClientsWindowViewModel
    {

        public ICommand OpenNewClientWindowCommand { get; }
        public ClientCollectionViewModel ClientList { get; set; }

        public ClientsWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {

            OpenNewClientWindowCommand = new RelayCommand(OpenNewClientWindowMethod);

            ClientList = givenAdministrationViewModel.Clients;

        }


        private void OpenNewClientWindowMethod()
        {
            ServiceBus.Instance.Send(new OpenNewClientWindowMessage());
        }


    }
}
