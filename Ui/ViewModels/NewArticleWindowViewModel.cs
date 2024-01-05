using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{
    public class NewArticleWindowViewModel
    {
        public int ArticleNr { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int Price { get; set; }

        public ICommand AddArticle { get; }
        public RelayCommand CloseWindow { get; }

        private AdministrationViewModel AdministrationViewModel;
        public NewArticleWindowViewModel(AdministrationViewModel givenAdministrationViewmodel)
        {
            AddArticle = new RelayCommand(AddArticleMethod); 
            CloseWindow = new RelayCommand(param => CloseWPFWindow(param));
            AdministrationViewModel = givenAdministrationViewmodel;
        }

        private void AddArticleMethod()
        {
            ArticleViewModel cvm = new ArticleViewModel
            {
                ArticleNr = AdministrationViewModel.Model.getArticleIdFromCreation(),
                Name = Name,
                Description = Description,
                Price = Price
            };
            AdministrationViewModel.Articles.Add(cvm);
        }
        private void CloseWPFWindow(object param)
        {
            Window window = (Window)param;
            window.Close();
        }
    }
}
