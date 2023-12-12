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

        public String[] GenreValues
        {
            get
            {
                List<String> value = new List<string>();
                foreach (var e in Enum.GetValues(typeof(Genre)))
                {
                    value.Add(e.ToString());
                }
                return value.ToArray<String>();
            }
            private set
            {

            }
        }

        public Genre Genre
        {
            get
            {
                return Genre;
            }
            set
            {
                Genre = value;
            }
        }

        public int OfferNr { get; set; }
        public String Reference { get; set; }
        public String Date { get; set; }
        public String Text { get; set; }

        public ClientViewModel SelectedClient { get; set; }
        public ArticleCollectionViewModel SelectedArticles{ get; set; }

        public ICommand AddOffer { get; }
        public OfferCollectionViewModel offerCollection;
        public ClientCollectionViewModel ClientList { get; set; }
        public OfferItemCollectionViewModel OfferItemList { get; set; }

        public NewOfferWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {
            AddOffer = new RelayCommand(AddOfferMethod);
            offerCollection = givenAdministrationViewModel.Offers;

            OfferItemList = new OfferItemCollectionViewModel();

            ClientList = givenAdministrationViewModel.Clients;            
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
                OfferItems = OfferItemList
            };


            offerCollection.Add(cvm);
        }
    }
}
