using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{
    public class AddOfferItemViewModel
    {

        public int OfferItemNr { get; set; }
        public ArticleViewModel SelectedArticle { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }

        public OfferViewModel SelectedOffer { get; set; }

        public AddOfferItemViewModel(AdministrationViewModel givenAdministrationViewModel)
        {
            AddOfferItem = new RelayCommand(AddOfferItemMethod);
            OfferList = givenAdministrationViewModel.Offers;
            ArticleList = givenAdministrationViewModel.Articles;

        }

        public RelayCommand AddOfferItem { get;}
        public OfferCollectionViewModel OfferList { get; set; }
        public ArticleCollectionViewModel ArticleList { get; set; }

        private void AddOfferItemMethod()
        {

            OfferItemViewModel of = new OfferItemViewModel
            {
                OfferItemNr = SelectedOffer.Model.getOfferIdFromCreation(),
                Article = SelectedArticle.Model,
                Quantity = Quantity,
                TotalPrice = TotalPrice
            };


            SelectedOffer.OfferItems.Add(of);
        }
    }

}
