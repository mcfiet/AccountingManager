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
    public class NewOfferWindowViewModel
    {
        public int OfferNr { get; set; }
        public String Reference { get; set; }
        public String Date { get; set; }
        public String Text { get; set; }

        public ClientViewModel SelectedClient { get; set; }
        public ArticleCollectionViewModel SelectedArticles{ get; set; }

        public ICommand AddOffer { get; }
        public OfferCollectionViewModel offerCollection;
        public ClientCollectionViewModel ClientList { get; set; }
        public ArticleCollectionViewModel ArticleList { get; set; }

        public NewOfferWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {
            AddOffer = new RelayCommand(AddOfferMethod);
            offerCollection = givenAdministrationViewModel.Offers;

            ClientList = givenAdministrationViewModel.Clients;
            ArticleList = givenAdministrationViewModel.Articles;
        }

        private void AddOfferMethod()
        {
            OfferViewModel cvm = new OfferViewModel
            {
                OfferNr = OfferNr,
                Reference = Reference,
                Date = Date,
                Text = Text,
                Client = SelectedClient,
                Articles = SelectedArticles
            };


            offerCollection.Add(cvm);
        }
    }
}
