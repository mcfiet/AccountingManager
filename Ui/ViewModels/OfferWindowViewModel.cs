using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp078.Services.MessageBus;
using Services.PdfExport;
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

        public ICommand UpdateOfferCommand { get; }
        public ICommand OpenAddOfferItemWindowCommand { get; }
        public ICommand ExportPdfCommand { get; }
        public OfferCollectionViewModel offerCollection;
        public ClientCollectionViewModel ClientList { get; set; }
        public OfferItemCollectionViewModel OfferItemList { get; set; }
        public OfferCollectionViewModel OfferList { get; set; }
        public OfferWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {
            UpdateOfferCommand = new RelayCommand(UpdateOfferMethod);
            OpenAddOfferItemWindowCommand = new RelayCommand(OpenAddOfferItemWindow);
            ExportPdfCommand = new RelayCommand(ExportPdf);
            offerCollection = givenAdministrationViewModel.Offers;

            OfferList = givenAdministrationViewModel.Offers;
            SelectedOffer = new OfferViewModel();
            OfferItemList = SelectedOffer.OfferItems;

            ClientList = givenAdministrationViewModel.Clients;
        }

        private void UpdateOfferMethod()
        {

            SelectedOffer.OfferNr = OfferNr;
            SelectedOffer.Reference = Reference;
            SelectedOffer.Date = Date;
            SelectedOffer.Text = Text;
            SelectedOffer.OfferItems = OfferItemList;
      
        }

        private void ExportPdf()
        {

            PdfExportFileHandler pdf = new PdfExportFileHandler();
            pdf.PDFExport(SelectedOffer.Model);
        }

        private void OpenAddOfferItemWindow()
        {

            ServiceBus.Instance.Send(new OpenAddOfferItemWindowMessage());

        }
    }
}
