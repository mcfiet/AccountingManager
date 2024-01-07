using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages
{
    public class OpenOfferWindowMessage
    {
        public OfferViewModel IncomingOffer { get; set; }
        public bool NewOffer { get; set; }
    }
}
