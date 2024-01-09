using De.HsFlensburg.ClientApp078.Logic.Ui;
using De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels;
using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using De.HsFlensburg.ClientApp078.Services.MessageBusWithParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

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

                if (messageObject.NewOffer)
                {
                    object wantedNode = myWindow.FindName("OfferButtons");
                    ((OfferWindowViewModel)myWindow.DataContext).NewBtn.CommandParameter = myWindow;

                    if (wantedNode is Grid)
                    {
                        Grid wantedChild = wantedNode as Grid;
                        try
                        {
                            wantedChild.Children.Add(((OfferWindowViewModel)myWindow.DataContext).NewBtn);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Button bereits erstellt: " + e);
                        }
                    }
                }

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
                myWindow.ShowDialog();
            });
            Messenger.Instance.Register<OpenNewArticleWindowMessage>(this, delegate (OpenNewArticleWindowMessage messageObject)
            {
                NewArticleWindow myWindow = new NewArticleWindow();
                myWindow.ShowDialog();
            });
            Messenger.Instance.Register<OpenErrorWindowMessage>(this, delegate (OpenErrorWindowMessage messageObject)
            {
                ErrorWindow myWindow = new ErrorWindow();
                ((ErrorWindowViewModel)myWindow.DataContext).ErrorMessage = messageObject.Message;
                myWindow.ShowDialog();
            });
        }
    }
}
