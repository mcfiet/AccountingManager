using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Services.MessageBusWithParameter
{
    public class WeakReferenceAction
    {
        private WeakReference target;
        private Action action;
        public WeakReferenceAction(object target, Action action)
        {
            this.target = new WeakReference(target);
            this.action = action;
        }
        public WeakReference Target
        {
            get
            {
                return target;
            }
        }
        public void Execute()
        {
            if (action != null && target != null && target.IsAlive)
                action.Invoke();
        }
        public void Unload()
        {
            target = null;
            action = null;
        }
    }
}
