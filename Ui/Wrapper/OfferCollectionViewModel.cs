using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp078.Logic.Ui.Base;
using De.HsFlensburg.ClientApp078.Logic.Ui.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper
{
    public class OfferCollectionViewModel :
        ViewModelSyncCollection<
            OfferViewModel,
            Offer,
            OfferCollection>
    {
    }
}
