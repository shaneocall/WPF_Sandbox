using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FX_PriceTile_Blotter.Annotations;
using FX_PriceTile_Blotter.Interfaces;

namespace FX_PriceTile_Blotter.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged<T>(ref T oldValue, T newValue,
             [CallerMemberName] string propertyName = null, Action preAction = null, Action postAction = null)
        {
            //Do not add any exception handling here, any excpetions should bubble straight up

            //Invoke any pre event actions, note this is fired regardless of whether the value is set
            preAction?.Invoke();

            //Cast to object to compare values, if they cannot cast then 
            //an exception should be thrown
            if ((object)oldValue == (object)newValue) return;

            //Set the new value
            oldValue = newValue;

            //Raise the value changed handler
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            //Invoke any post event actions
            postAction?.Invoke();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Dispose();
            }
           
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
