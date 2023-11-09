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
            ServiceBus.Instance.Register<OpenNewClientWindowMessage>(this, OpenNewClientWindow);
            ServiceBus.Instance.Register<OpenNewArticleWindowMessage>(this, OpenNewArticleWindow);
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
    }
}
