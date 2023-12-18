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
    public class OfferWindowViewModel
    {

        public int OfferNr { get; set; }
        public String Reference { get; set; }
        public String Date { get; set; }
        public String Text { get; set; }

        public ClientViewModel SelectedClient { get; set; }
        public OfferViewModel SelectedOffer { get; set; }

        public ICommand UpdateOffer { get; }
        public OfferCollectionViewModel offerCollection;
        public ClientCollectionViewModel ClientList { get; set; }
        public OfferItemCollectionViewModel OfferItemList { get; set; }
        public OfferCollectionViewModel OfferList { get; set; }
        public OfferWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {
            UpdateOffer = new RelayCommand(UpdateOfferMethod);
            offerCollection = givenAdministrationViewModel.Offers;

            OfferList = givenAdministrationViewModel.Offers;
            SelectedOffer = new OfferViewModel();
/*            OfferItemViewModel of = new OfferItemViewModel();
            of.Model.OfferItemNr = 1;
            of.Model.Quantity = 1;
            of.Model.TotalPrice = 1;
            SelectedOffer.OfferItems.Add(of);
            SelectedOffer.Text = "test";
            SelectedOffer.Reference = "test";*/
            OfferItemList = SelectedOffer.OfferItems;

            ClientList = givenAdministrationViewModel.Clients;
        }

        private void UpdateOfferMethod()
        {
            OfferViewModel cvm = new OfferViewModel
            {
                OfferNr = OfferNr,
                Reference = Reference,
                Date = Date,
                Text = Text,
                Client = SelectedClient,
                OfferItems = OfferItemList
            };


            offerCollection.Add(cvm);
        }
    }
}
