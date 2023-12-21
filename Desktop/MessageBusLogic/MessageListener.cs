using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels;
using De.HsFlensburg.ClientApp078.Services.MessageBus;
using De.HsFlensburg.ClientApp078.Services.MessageBusWithParameter;
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
            //InitMessenger();
            InitMessengerWithParameter();
        }

        private void InitMessengerWithParameter()
        {

            Messenger.Instance.Register<OpenNewOfferWindowMessage>(this, delegate (OpenNewOfferWindowMessage messageObject)
            {
                NewOfferWindow myWindow = new NewOfferWindow();
                myWindow.ShowDialog();
            });
            Messenger.Instance.Register<OpenOfferWindowMessage>(this, delegate (OpenOfferWindowMessage messageObject)
            {
                OfferWindow myWindow = new OfferWindow();
                myWindow.ShowDialog();
            });
            Messenger.Instance.Register<OpenAddOfferItemWindowMessage>(this, delegate (OpenAddOfferItemWindowMessage messageObject)
            {
                AddOfferItemWindow myWindow = new AddOfferItemWindow();
                ((AddOfferItemWindowViewModel)myWindow.DataContext).IncomingOffer = messageObject.Message;

                myWindow.ShowDialog();
            });
            Messenger.Instance.Register<OpenNewClientWindowMessage>(this, delegate (OpenNewClientWindowMessage messageObject)
            {
                NewClientWindow myWindow = new NewClientWindow();
                ((NewClientWindowViewModel)myWindow.DataContext).IncomingMessage = messageObject.Message;
                myWindow.ShowDialog();
            });
            Messenger.Instance.Register<OpenClientsWindowMessage>(this, delegate (OpenClientsWindowMessage messageObject)
            {
                ClientsWindow myWindow = new ClientsWindow();
                myWindow.ShowDialog();
            });
            Messenger.Instance.Register<OpenNewArticleWindowMessage>(this, delegate (OpenNewArticleWindowMessage messageObject)
            {
                NewArticleWindow myWindow = new NewArticleWindow();
                myWindow.ShowDialog();
            });
            Messenger.Instance.Register<OpenArticlesWindowMessage>(this, delegate (OpenArticlesWindowMessage messageObject)
            {
                ArticlesWindow myWindow = new ArticlesWindow();
                myWindow.ShowDialog();
            });
        }

        //private void InitMessenger()
        //{
        //    ServiceBus.Instance.Register<OpenNewOfferWindowMessage>(this, OpenNewOfferWindow);
        //    ServiceBus.Instance.Register<OpenOfferWindowMessage>(this, OpenOfferWindow);
        //    ServiceBus.Instance.Register<OpenNewClientWindowMessage>(this, OpenNewClientWindow);
        //    ServiceBus.Instance.Register<OpenNewArticleWindowMessage>(this, OpenNewArticleWindow);
        //    ServiceBus.Instance.Register<OpenClientsWindowMessage>(this, OpenClientsWindow);
        //    ServiceBus.Instance.Register<OpenArticlesWindowMessage>(this, OpenArticlesWindow);
        //    ServiceBus.Instance.Register<OpenAddOfferItemWindowMessage>(this, OpenAddOfferItemWindow);
        //}

        //private void OpenNewOfferWindow()
        //{
        //    NewOfferWindow myWindow = new NewOfferWindow();
        //    myWindow.ShowDialog();
        //}

        //private void OpenOfferWindow()
        //{
        //    OfferWindow myWindow = new OfferWindow();
        //    myWindow.ShowDialog();
        //}

        //private void OpenNewClientWindow()
        //{
        //    NewClientWindow myWindow = new NewClientWindow();
        //    myWindow.ShowDialog();
        //}

        //private void OpenNewArticleWindow()
        //{
        //    NewArticleWindow myWindow = new NewArticleWindow();
        //    myWindow.ShowDialog();
        //}
        //private void OpenClientsWindow()
        //{
        //    ClientsWindow myWindow = new ClientsWindow();
        //    myWindow.ShowDialog();
        //}
        //private void OpenArticlesWindow()
        //{
        //    ArticlesWindow myWindow = new ArticlesWindow();
        //    myWindow.ShowDialog();
        //}
        //private void OpenAddOfferItemWindow()
        //{
        //    AddOfferItem myWindow = new AddOfferItem();
        //    myWindow.ShowDialog();
        //}
    }
}
