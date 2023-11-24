using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{
    public class NewClientWindowViewModel
    {
        public int Identifier { get; set; }
        public string Name { get; set; }
        public ICommand AddClient { get; }
        private ClientCollectionViewModel clientCollection;

        public NewClientWindowViewModel(ClientCollectionViewModel givenClientCollection)
        {
            AddClient = new RelayCommand(AddClientMethod);
            clientCollection = givenClientCollection;
        }

        private void AddClientMethod()
        {
            ClientViewModel cvm = new ClientViewModel
            {
                Id = Identifier,
                Name = Name
            };
            clientCollection.Add(cvm);
            
        }
    }
}
