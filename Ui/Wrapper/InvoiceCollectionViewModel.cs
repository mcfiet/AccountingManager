using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp078.Logic.Ui.Base;
using System.ComponentModel;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper
{
    public class InvoiceCollectionViewModel :
        ViewModelSyncCollection<
            InvoiceViewModel,
            Invoice,
            InvoiceCollection>
    {
    }
}
