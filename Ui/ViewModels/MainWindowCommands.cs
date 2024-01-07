using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels
{
    public class MainWindowCommands
    {
        public RelayCommand SaveCommand { get;}
        public RelayCommand LoadCommand { get;}
        public RelayCommand OpenNewOfferWindowCommand { get;}
        public RelayCommand OpenOfferCommand { get; }
        public RelayCommand OpenOrderCommand { get;}
        public RelayCommand OpenInvoiceCommand { get;}
        public RelayCommand DeleteOffersCommand { get; }
        public RelayCommand DeleteOrdersCommand { get; }
        public RelayCommand DeleteInvoicesCommand { get; }
        public RelayCommand OpenNewArticleWindowCommand { get;}
        public RelayCommand ImportArticlesCommand { get; }
        public RelayCommand ExportArticlesCommand { get;}
        public RelayCommand DeleteArticlesCommand { get; }
        public RelayCommand OpenNewClientWindowCommand { get;}
        public RelayCommand ExportClientsToXmlCommand { get;}
        public RelayCommand ImportClientsCommand { get; }
        public RelayCommand DeleteClientsCommand { get; }
        public RelayCommand ConvertToOrderCommand { get;}
        public RelayCommand ConvertToInvoiceCommand { get; }
        public MainWindowCommands(MainWindowViewModel mainWindowViewModel)
        {
            SaveCommand = new RelayCommand(mainWindowViewModel.SaveModel);
            LoadCommand = new RelayCommand(mainWindowViewModel.LoadModel);

            OpenNewOfferWindowCommand = new RelayCommand(mainWindowViewModel.OpenNewOfferWindowMethodWithParameter);
            OpenOfferCommand = new RelayCommand(param => mainWindowViewModel.OpenOfferMethodWithParameter(param));
            OpenOrderCommand = new RelayCommand(param => mainWindowViewModel.OpenOrderWindowMethodWithParameter(param));
            OpenInvoiceCommand = new RelayCommand(param => mainWindowViewModel.OpenInvoiceWindowMethodWithParameter(param));
            DeleteOffersCommand = new RelayCommand(mainWindowViewModel.DeleteOffersCommandMethod);
            DeleteOrdersCommand = new RelayCommand(mainWindowViewModel.DeleteOrdersCommandMethod);
            DeleteInvoicesCommand = new RelayCommand(mainWindowViewModel.DeleteInvoicesCommandMethod);

            OpenNewArticleWindowCommand = new RelayCommand(mainWindowViewModel.OpenNewArticleWindowMethodWithParameter);
            ImportArticlesCommand = new RelayCommand(mainWindowViewModel.ImportArticles);
            ExportArticlesCommand = new RelayCommand(mainWindowViewModel.ExportArticlesToXmlFileMethod);
            DeleteArticlesCommand = new RelayCommand(mainWindowViewModel.DeleteArticlesCommandMethod);

            OpenNewClientWindowCommand = new RelayCommand(mainWindowViewModel.OpenNewClientWindowMethod);
            ExportClientsToXmlCommand = new RelayCommand(mainWindowViewModel.ExportClientsToXmlFileMethod);
            ImportClientsCommand = new RelayCommand(mainWindowViewModel.ImportClients);
            DeleteClientsCommand = new RelayCommand(mainWindowViewModel.DeleteClientsCommandMethod);

            ConvertToOrderCommand = new RelayCommand(param => mainWindowViewModel.ConvertToOrderCommandMethodWithParameter(param));
            ConvertToInvoiceCommand = new RelayCommand(param => mainWindowViewModel.ConvertToInvoiceMethodWithParameter(param));

        }  
    }
}
