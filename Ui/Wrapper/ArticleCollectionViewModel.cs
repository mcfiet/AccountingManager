using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using De.HsFlensburg.ClientApp078.Logic.Ui.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Logic.Ui.Wrapper
{
    public class ArticleCollectionViewModel : 
        ViewModelSyncCollection<
            ArticleViewModel,
            Article,
            ArticleCollection>
    {
        public override void NewModelAssigned()
        {
            //Wenn das neue Model z.B. aus der Deserialisierung kommt,
            //dann muss für jedes Element der Liste (hier: jeder Client in der ClientCollection)
            //sich die Wrapper-Klasse neu im PropertyChanged-EventArgs registrieren

            foreach (var cvm in this)
            {
                var modelPropChanged = cvm.Model as INotifyPropertyChanged;
                if (modelPropChanged != null)
                {
                    modelPropChanged.PropertyChanged += cvm.OnPropertyChangedInModel;
                }
            }
        }
    }
}
