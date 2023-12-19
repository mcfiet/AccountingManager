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

        public ClientCollection Clients { get; set; }

        public ArticleCollection Articles { get; set; }

        private int offerId;

        public Administration() { 
        
            Offers = new OfferCollection();
            Clients = new ClientCollection();   
            Articles = new ArticleCollection(); 
        }

        public int getOfferIdFromCreateOffer()
        {
            if (offerId == null)
            {
                offerId = 0;
            }

            return offerId++;
        }

    }
}
