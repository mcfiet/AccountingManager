using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp078.Services.MessageBus;
using De.HsFlensburg.ClientApp078.Services.MessageBusWithParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{
    public class ArticlesWindowViewModel
    {
        public ICommand OpenNewArticleWindowCommand { get; }
        public ArticleCollectionViewModel ArticleList { get; set; }

        public ArticlesWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {

            OpenNewArticleWindowCommand = new RelayCommand(OpenNewArticleWindowMethodWithParameter);

            ArticleList = givenAdministrationViewModel.Articles;

        }


        private void OpenNewArticleWindowMethod()
        {
            ServiceBus.Instance.Send(new OpenNewArticleWindowMessage());
        }
        private void OpenNewArticleWindowMethodWithParameter()
        {
            OpenNewArticleWindowMessage messageObject = new OpenNewArticleWindowMessage();
            Messenger.Instance.Send<OpenNewArticleWindowMessage>(messageObject);
        }

    }
}
