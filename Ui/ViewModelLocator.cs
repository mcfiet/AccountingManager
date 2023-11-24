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
        public NewOfferWindowViewModel TheNewOfferWindowViewmodel { get; set; }
        public AdministrationViewModel TheAdministrationViewModel { get; set; }
        public ClientsWindowViewModel TheClientsWindowViewModel { get; set; }
        public ArticlesWindowViewModel TheArticlesWindowViewModel { get; set; }
        public ViewModelLocator()
        {
            TheAdministrationViewModel = new AdministrationViewModel();

            TheNewOfferWindowViewmodel = new NewOfferWindowViewModel(TheAdministrationViewModel.Offers);
            TheNewClientWindowViewModel = new NewClientWindowViewModel(TheAdministrationViewModel.Clients);
            TheNewArticleWindowViewModel = new NewArticleWindowViewModel(TheAdministrationViewModel.Articles);

            TheMainWindowViewModel = new MainWindowViewModel(TheAdministrationViewModel);
            TheClientsWindowViewModel = new ClientsWindowViewModel(TheAdministrationViewModel);
            TheArticlesWindowViewModel = new ArticlesWindowViewModel(TheAdministrationViewModel);
        }
    }
}
