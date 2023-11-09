using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{
    public class NewArticleWindowViewModel
    {
        public int ArticleNr { get; set; }
        public String Name { get; set;}
        public String Description { get; set; }
        public int Price { get; set; }

        public ICommand AddArticle;
        private ArticleCollectionViewModel articleCollectionViewModel;
        public NewArticleWindowViewModel(ArticleCollectionViewModel viewModelCollection)
        {
            AddArticle = new RelayCommand(AddArticleMethod);
            articleCollectionViewModel = viewModelCollection;

        }

        private void AddArticleMethod()
        {
            ArticleViewModel cvm = new ArticleViewModel();
            cvm.ArticleNr = ArticleNr;
            cvm.Name = Name;
            cvm.Description = Description;
            cvm.Price = Price;
            articleCollectionViewModel.Add(cvm);
        }
    }
}
