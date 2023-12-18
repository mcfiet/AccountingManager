using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Services.MessageBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Ui.Desktop.MessageBusLogic
{
    public class MessageListener
    {
        // Kurzschreibweise für Property, gibt immer true zurück
        public bool BindableProperty => true;
        public MessageListener()
        {
            InitMessenger();
        }

        private void InitMessenger()
        {
            ServiceBus.Instance.Register<OpenNewOfferWindowMessage>(this, OpenNewOfferWindow);
            ServiceBus.Instance.Register<OpenOfferWindowMessage>(this, OpenOfferWindow);
            ServiceBus.Instance.Register<OpenNewClientWindowMessage>(this, OpenNewClientWindow);
            ServiceBus.Instance.Register<OpenNewArticleWindowMessage>(this, OpenNewArticleWindow);
            ServiceBus.Instance.Register<OpenClientsWindowMessage>(this, OpenClientsWindow);
            ServiceBus.Instance.Register<OpenArticlesWindowMessage>(this, OpenArticlesWindow);
            ServiceBus.Instance.Register<OpenAddOfferItemWindowMessage>(this, OpenAddOfferItemWindow);
        }

        private void OpenNewOfferWindow()
        {
            NewOfferWindow myWindow = new NewOfferWindow();
            myWindow.ShowDialog();
        }

        private void OpenOfferWindow()
        {
            OfferWindow myWindow = new OfferWindow();
            myWindow.ShowDialog();
        }

        private void OpenNewClientWindow()
        {
            NewClientWindow myWindow = new NewClientWindow();
            myWindow.ShowDialog();
        }

        private void OpenNewArticleWindow()
        {
            NewArticleWindow myWindow = new NewArticleWindow();
            myWindow.ShowDialog();
        }
        private void OpenClientsWindow()
        {
            ClientsWindow myWindow = new ClientsWindow();
            myWindow.ShowDialog();
        }
        private void OpenArticlesWindow()
        {
            ArticlesWindow myWindow = new ArticlesWindow();
            myWindow.ShowDialog();
        }
        private void OpenAddOfferItemWindow()
        {
            AddOfferItem myWindow = new AddOfferItem();
            myWindow.ShowDialog();
        }
    }
}
