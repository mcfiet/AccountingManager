using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{


    public class NewOfferWindowViewModel : INotifyPropertyChanged
    {

        public int OfferNr { get; set; }
        public String Reference { get; set; }
        public DateTime Date { get; set; }

        private String text;
        public String Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }


        private ClientViewModel selectedClient;
        public ClientViewModel SelectedClient
        {
            get
            {
                return selectedClient;
            }
            set
            {
                selectedClient = value;
                Text = "Sehr geehrte/r " + selectedClient.Name + ",\n\ngerne bieten wir Ihnen folgende Produkte an.";
            }
        }
        public ArticleCollectionViewModel SelectedArticles { get; set; }

        public AdministrationViewModel AdministrationViewModel { get; set; }
        public ICommand AddOffer { get; }
        public ICommand OpenAddOfferItemWindowCommand { get; }

        public NewOfferWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {
            AddOffer = new RelayCommand(AddOfferMethod);
            AdministrationViewModel = givenAdministrationViewModel;
        }

        private void AddOfferMethod()
        {
            OfferViewModel cvm = new OfferViewModel
            {
                OfferId = AdministrationViewModel.Model.getOfferIdFromCreation(),
                Reference = Reference,
                Date = Date,
                Text = Text,
                Client = SelectedClient,
            };

            cvm.SetOfferNr(cvm.OfferId);

            AdministrationViewModel.Offers.Add(cvm);
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
