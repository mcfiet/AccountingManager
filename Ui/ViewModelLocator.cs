using De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Logic.Ui
{
    public class ViewModelLocator
    {
        public MainWindowViewModel TheMainWindowViewModel { get; set; }
        public NewClientWindowViewModel TheNewClientWindowViewModel { get; set; }
        public NewArticleWindowViewModel TheNewArticleWindowViewModel { get; set; }
        public OfferWindowViewModel TheOfferWindowViewmodel { get; set; }
        public OrderWindowViewModel TheOrderWindowViewmodel { get; set; }
        public InvoiceWindowViewModel TheInvoiceWindowViewmodel { get; set; }
        public AdministrationViewModel TheAdministrationViewModel { get; set; }
        public AddPositionWindowViewModel TheAddPositionWindowViewModel { get; set; }
        public ErrorWindowViewModel TheErrorWindowViewModel { get; set; }
        public ViewModelLocator()
        {
            TheAdministrationViewModel = new AdministrationViewModel();

            TheOfferWindowViewmodel = new OfferWindowViewModel(TheAdministrationViewModel);
            TheOrderWindowViewmodel = new OrderWindowViewModel();
            TheInvoiceWindowViewmodel = new InvoiceWindowViewModel();
            TheNewClientWindowViewModel = new NewClientWindowViewModel(TheAdministrationViewModel);
            TheNewArticleWindowViewModel = new NewArticleWindowViewModel(TheAdministrationViewModel);

            TheMainWindowViewModel = new MainWindowViewModel(TheAdministrationViewModel);
            TheAddPositionWindowViewModel = new AddPositionWindowViewModel(TheAdministrationViewModel);
            TheErrorWindowViewModel = new ErrorWindowViewModel();
        }
    }
}
