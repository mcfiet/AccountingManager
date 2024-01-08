using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects
{
    [Serializable]
    public class Administration
    {
        public OfferCollection Offers { get; set; }
        public OrderCollection Orders { get; set; }
        public InvoiceCollection Invoices { get; set; }
        public ClientCollection Clients { get; set; }
        public ArticleCollection Articles { get; set; }

        private int offerId;
        private int orderId;
        private int invoiceId;
        private int clientId;
        private int articleId;


        public Administration() { 
        
            Offers = new OfferCollection();
            Orders = new OrderCollection();
            Invoices = new InvoiceCollection();
            Clients = new ClientCollection();   
            Articles = new ArticleCollection(); 
        }

        public int GetOfferIdFromCreation()
        {
            return offerId++;
        }
        public int GetOrderIdFromCreation()
        {
            return orderId++;
        }
        public int GetInvoiceIdFromCreation()
        {
            return invoiceId++;
        }
        public int GetClientIdFromCreation()
        {
            return clientId++;
        }
        public int GetArticleIdFromCreation()
        {
            return articleId++;
        }


    }
}
