using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
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
        public bool BindableProperty => true;
        public MessageListener()
        {
            InitMessengerWithParameter();
        }

        private void InitMessengerWithParameter()
        {

            Messenger.Instance.Register<OpenOfferWindowMessage>(this, delegate (OpenOfferWindowMessage messageObject)
            {
                OfferWindow myWindow = new OfferWindow();
                ((OfferWindowViewModel)myWindow.DataContext).IncomingOffer = messageObject.IncomingOffer;
                ((OfferWindowViewModel)myWindow.DataContext).SelectedClient = messageObject.IncomingOffer.Client;

                myWindow.ShowDialog();
            });
            Messenger.Instance.Register<OpenOrderWindowMessage>(this, delegate (OpenOrderWindowMessage messageObject)
            {
                OrderWindow myWindow = new OrderWindow();
                ((OrderWindowViewModel)myWindow.DataContext).IncomingOrder = messageObject.IncomingOrder;

                myWindow.ShowDialog();
            });
            Messenger.Instance.Register<OpenInvoiceWindowMessage>(this, delegate (OpenInvoiceWindowMessage messageObject)
            {
                InvoiceWindow myWindow = new InvoiceWindow();
                ((InvoiceWindowViewModel)myWindow.DataContext).IncomingInvoice = messageObject.IncomingInvoice;

                myWindow.ShowDialog();
            });
            Messenger.Instance.Register<OpenAddOfferItemWindowMessage>(this, delegate (OpenAddOfferItemWindowMessage messageObject)
            {
                AddPositionWindow myWindow = new AddPositionWindow();
                ((AddPositionWindowViewModel)myWindow.DataContext).IncomingOffer = messageObject.OfferMessage;
                ((AddPositionWindowViewModel)myWindow.DataContext).IncomingOrder = messageObject.OrderMessage;
                ((AddPositionWindowViewModel)myWindow.DataContext).IncomingInvoice = messageObject.InvoiceMessage;

                myWindow.ShowDialog();
            });
            Messenger.Instance.Register<OpenNewClientWindowMessage>(this, delegate (OpenNewClientWindowMessage messageObject)
            {
                NewClientWindow myWindow = new NewClientWindow();
                ((NewClientWindowViewModel)myWindow.DataContext).IncomingMessage = messageObject.Message;
                myWindow.ShowDialog();
            });
            Messenger.Instance.Register<OpenNewArticleWindowMessage>(this, delegate (OpenNewArticleWindowMessage messageObject)
            {
                NewArticleWindow myWindow = new NewArticleWindow();
                myWindow.ShowDialog();
            });
        }
    }
}
