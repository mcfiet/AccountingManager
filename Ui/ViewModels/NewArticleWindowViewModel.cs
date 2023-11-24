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
    public class NewArticleWindowViewModel
    {
        public int ArticleNr { get; set; }
        public String Name { get; set;}
        public String Description { get; set; }
        public int Price { get; set; }

        public ICommand AddArticle { get; }
        private ArticleCollectionViewModel articleCollection;
        public NewArticleWindowViewModel(ArticleCollectionViewModel givenArticleCollection)
        {
            AddArticle = new RelayCommand(AddArticleMethod);
            articleCollection = givenArticleCollection;
        }

        private void AddArticleMethod()
        {
            ArticleViewModel cvm = new ArticleViewModel
            {
                ArticleNr = ArticleNr,
                Name = Name,
                Description = Description,
                Price = Price
            };
            articleCollection.Add(cvm);
        }
    }
}
