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
            ServiceBus.Instance.Register<OpenNewClientWindowMessage>(this, OpenNewClientWindow);
            ServiceBus.Instance.Register<OpenNewArticleWindowMessage>(this, OpenNewArticleWindow);
            ServiceBus.Instance.Register<OpenClientsWindowMessage>(this, OpenClientsWindow);
        }

        private void OpenNewOfferWindow()
        {
            NewOfferWindow myWindow = new NewOfferWindow();
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
    }
}
