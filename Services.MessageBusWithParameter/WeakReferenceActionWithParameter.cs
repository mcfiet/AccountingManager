using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Services.MessageBusWithParameter
{
    public class WeakReferenceActionWithParameter<T> : WeakReferenceAction, IActionParameter
    {
        private Action<T> action;
        public WeakReferenceActionWithParameter(object target, Action<T> action)
            : base(target, null)
        {
            this.action = action;
        }
        public void Execute()
        {
            if (action != null && Target != null && Target.IsAlive)
                action(default(T));
        }
        public void Execute(T parameter)
        {
            if (action != null && Target != null && Target.IsAlive)
                this.action(parameter);
        }
        public Action<T> Action
        {
            get
            {
                return action;
            }
        }
        #region IActionParameter Members
        public void ExecuteWithParameter(object parameter)
        {
            this.Execute((T)parameter);
        }
        #endregion
    }
}