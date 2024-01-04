using De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.MessageBusMessages
{
    public class OpenAddOfferItemWindowMessage
    {
        public OfferViewModel OfferMessage { get; set; }
        public OrderViewModel OrderMessage { get; set; }
        public InvoiceViewModel InvoiceMessage { get; set; }
    }
}
