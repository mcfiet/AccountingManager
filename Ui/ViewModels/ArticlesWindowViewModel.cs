using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp078.Services.MessageBusWithParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{
    public class ArticlesWindowViewModel
    {
        public ICommand OpenNewArticleWindowCommand { get; }
        public RelayCommand CloseWindow { get; }

        public AdministrationViewModel AdministrationViewModel { get; set; }

        public ArticlesWindowViewModel(AdministrationViewModel givenAdministrationViewModel)
        {

            OpenNewArticleWindowCommand = new RelayCommand(OpenNewArticleWindowMethodWithParameter);
            CloseWindow = new RelayCommand(param => CloseWPFWindow(param));

            AdministrationViewModel = givenAdministrationViewModel;
        }
        private void OpenNewArticleWindowMethodWithParameter()
        {
            OpenNewArticleWindowMessage messageObject = new OpenNewArticleWindowMessage();
            Messenger.Instance.Send<OpenNewArticleWindowMessage>(messageObject);
        }
        private void CloseWPFWindow(object param)
        {
            Window window = (Window)param;
            window.Close();
        }

    }
}
