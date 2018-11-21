using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FX_PriceTile_Blotter.ViewModels
{
    /// <summary>
    /// Base class for creating a generic disposable view model.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="System.IDisposable" />
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Checks if the property matches the existing value, if not, the new value is set
        /// and fires the PropertyChanged event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        /// <param name="propertyName">Name of the property. </param>
        /// <param name="preAction">An optional action to be carried out on the UI thread before the old and new values are compared.</param>
        /// <param name="postAction">An optional action to be carried out on the UI thread only after the new value has been set.</param>
        protected void OnPropertyChanged<T>(ref T oldValue,
                                            T newValue,
                                            [CallerMemberName] string propertyName = null,
                                            Action preAction = null,
                                            Action postAction = null)
        {

            if (preAction != null)
                System.Windows.Application.Current?.Dispatcher?.Invoke(preAction);

            if (EqualityComparer<T>.Default.Equals(oldValue, newValue)) return;

            preAction?.Invoke();

            oldValue = newValue;

            RaisePropertyChanged(propertyName);

            if (postAction != null)
                System.Windows.Application.Current?.Dispatcher?.Invoke(postAction);

        }

        /// <summary>
        /// Notifies listeners that a property value has changed.
        /// </summary>
        /// <param name="propertyName">Name of the property used to notify listeners.  This
        /// value is optional and can be provided automatically when invoked from compilers
        /// that support <see cref="CallerMemberNameAttribute"/>.</param>
        protected virtual void RaisePropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region DisposeLogic

        /// <summary>
        /// Is this instance disposed?
        /// </summary>
        public bool Disposed { get; private set; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose worker method.
        /// </summary>
        /// <param name="disposing">Are we disposing? 
        /// Otherwise we're finalizing.</param>
        protected virtual void Dispose(bool disposing)
        {
            Disposed = true;
        }

        #endregion
    }
}