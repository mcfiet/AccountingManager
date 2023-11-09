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
        public OfferCollectionViewModel offerCollectionViewModel;

        public NewOfferWindowViewModel(OfferCollectionViewModel viewModelCollection)
        {
            AddOffer = new RelayCommand(AddOfferMethod);
            offerCollectionViewModel = viewModelCollection;
        }

        private void AddOfferMethod()
        {
            OfferViewModel cvm = new OfferViewModel();
            cvm.OfferNr = OfferNr;
            cvm.Reference = Reference;
            cvm.Date = Date;
            cvm.Text = Text;
            offerCollectionViewModel.Add(cvm);
        }
    }
}
