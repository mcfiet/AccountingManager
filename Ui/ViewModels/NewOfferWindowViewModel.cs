using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp078.Logic.Ui.Base;
using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp078.Services.MessageBus;
using De.HsFlensburg.ClientApp078.Services.MessageBusWithParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{


    public class NewOfferWindowViewModel
    {

        public int OfferNr { get; set; }
        public String Reference { get; set; }
        public String Date { get; set; }
        public String Text { get; set; }


        public ClientViewModel SelectedClient { get; set; }
        public ArticleCollectionViewModel SelectedArticles{ get; set; }

        public ICommand AddOffer { get; }
        public ICommand OpenAddOfferItemWindowCommand { get; }

        public OfferCollectionViewModel offerCollection;
        public ClientCollectionViewModel ClientList { get; set; }
        public AdministrationViewModel AdministrationViewModel { get; set; }
        public OfferItemCollectionViewModel OfferItemList { get; set; }

        public NewOfferWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {
            AddOffer = new RelayCommand(AddOfferMethod);
            OpenAddOfferItemWindowCommand = new RelayCommand(OpenAddOfferItemWindowWithParameter);
            AdministrationViewModel = givenAdministrationViewModel;

            offerCollection = givenAdministrationViewModel.Offers;

            OfferItemList = new OfferItemCollectionViewModel();

            ClientList = givenAdministrationViewModel.Clients;            
        }

        private void AddOfferMethod()
        {
            OfferViewModel cvm = new OfferViewModel
            {
                OfferNr = AdministrationViewModel.Model.getOfferIdFromCreation(),
                Reference = Reference,
                Date = Date,
                Text = Text,
                Client = SelectedClient,
                OfferItems = OfferItemList
            };


            offerCollection.Add(cvm);
        }


        private void OpenAddOfferItemWindow()
        {
            ServiceBus.Instance.Send(new OpenAddOfferItemWindowMessage());
        }

        private void OpenAddOfferItemWindowWithParameter()
        {

            OpenAddOfferItemWindowMessage messageObject = new OpenAddOfferItemWindowMessage();
            //ssageObject.Message = selectedOffer
            Messenger.Instance.Send<OpenAddOfferItemWindowMessage>(messageObject);

        }

    }
}
