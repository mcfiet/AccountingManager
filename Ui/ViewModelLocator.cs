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

        public ClientCollectionViewModel TheClientCollectionViewModel { get; set; }
        public NewClientWindowViewModel TheNewClientWindowViewModel { get; set; }


        public ArticleCollectionViewModel TheArticleCollectionViewModel { get; set; }
        public NewArticleWindowViewModel TheNewArticleWindowViewModel { get; set; }

        public OfferCollectionViewModel TheOfferCollectionViewModel { get; set; }
        public NewOfferWindowViewModel TheNewOfferWindowViewmodel { get; set; }


        public ViewModelLocator()
        {

            TheMainWindowViewModel = new MainWindowViewModel(TheClientCollectionViewModel, TheArticleCollectionViewModel);

            TheClientCollectionViewModel = new ClientCollectionViewModel();
            TheNewClientWindowViewModel = new NewClientWindowViewModel(TheClientCollectionViewModel);

            TheArticleCollectionViewModel = new ArticleCollectionViewModel();
            TheNewArticleWindowViewModel = new NewArticleWindowViewModel(TheArticleCollectionViewModel);

            TheOfferCollectionViewModel = new OfferCollectionViewModel();
            TheNewOfferWindowViewmodel = new NewOfferWindowViewModel(TheOfferCollectionViewModel);
        }
    }
}
