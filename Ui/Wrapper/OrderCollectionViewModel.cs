using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp078.Logic.Ui.Base;
using System.ComponentModel;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper
{
    public class OrderCollectionViewModel :
        ViewModelSyncCollection<
            OrderViewModel,
            Order,
            OrderCollection>
    {
    }
}