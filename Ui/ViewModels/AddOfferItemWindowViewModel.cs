using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp078.Services.MessageBusWithParameter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{
    public class AddOfferItemWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int OfferItemNr { get; set; }
        public ArticleViewModel SelectedArticle { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }

        public OfferViewModel SelectedOffer { get; set; }

        public AddOfferItemWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {
            AddOfferItem = new RelayCommand(AddOfferItemMethod);
            OfferList = givenAdministrationViewModel.Offers;
            ArticleList = givenAdministrationViewModel.Articles;

        }

        public RelayCommand AddOfferItem { get; }
        public OfferCollectionViewModel OfferList { get; set; }
        public ArticleCollectionViewModel ArticleList { get; set; }
        public OfferViewModel incomingOffer;
        public OfferViewModel IncomingOffer
        {
            get { return incomingOffer; }
            set
            {
                incomingOffer = value;
                OnPropertyChanged("IncomingOffer");
            }
        }


        private void AddOfferItemMethod()
        {

            OfferItemViewModel of = new OfferItemViewModel
            {
                OfferItemNr = IncomingOffer.Model.getOfferItemIdFromCreation(),
                Article = SelectedArticle.Model,
                Quantity = Quantity,
                TotalPrice = TotalPrice
            };


            IncomingOffer.OfferItems.Add(of);
            OnPropertyChanged("IncomingOffer");
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
