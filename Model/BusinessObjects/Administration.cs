﻿using System;
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

        public Administration() { 
        
            Offers = new OfferCollection();
            Clients = new ClientCollection();   
            Articles = new ArticleCollection(); 
        }


    }
}
