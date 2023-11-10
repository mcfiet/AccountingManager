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

        public ICommand AddOffer;
        public OfferCollection offerCollection;

        public NewOfferWindowViewModel(OfferCollection givenOfferCollection)
        {
            AddOffer = new RelayCommand(AddOfferMethod);
            offerCollection = givenOfferCollection;
        }

        private void AddOfferMethod()
        {
            Offer cvm = new Offer
            {
                OfferNr = OfferNr,
                Reference = Reference,
                Date = Date,
                Text = Text
            };
            offerCollection.Add(cvm);
        }
    }
}
