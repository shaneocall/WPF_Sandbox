using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using FX_PriceTile_Blotter.ViewModels;

namespace FX_PriceTile_Blotter
{
    /// <summary>
    /// The generic delegate command for view model command binding.
    /// </summary>
    /// <seealso cref="ViewModelBase" />
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class DelegateCommand : ViewModelBase, ICommand
    {
        internal readonly Action<object> _executeWithParameter;
        internal readonly Func<bool> _canExecute;
        internal string _name;
        private readonly ViewModelBase _vm;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="vm">The view model the delegate command is created in.</param>
        /// <param name="execute">The action to execute.</param>
        /// <param name="canExecute">Flag that allows the action to execute.</param>
        /// <param name="name">Optional name for the delegate command that supports binding updates</param>
        /// <param name="propertyName"></param>
        public DelegateCommand(ViewModelBase vm, Action execute, Func<bool> canExecute = null, string name = null,
           [CallerMemberName] string propertyName = null ) : this(vm,
            o => execute(), canExecute, name, propertyName)
        {
        }

        public DelegateCommand(ViewModelBase vm, Action<object> execute, Func<bool> canExecute = null, string name = null, [CallerMemberName] string propertyName = null)
        {
            _executeWithParameter = execute;
            _canExecute = canExecute;
            _name = name;
            _vm = vm;

            if (_vm != null) _vm.PropertyChanged += (sender, args) =>
            {
              if(args.PropertyName == null || string.Equals(args.PropertyName, propertyName)) RaiseCanExecuteChanged();
            };

           
        }

        /// <summary>
        /// Gets or sets the command name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get => _name;
            set => OnPropertyChanged(ref _name, value, Name);
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
        /// <returns>
        ///   <see langword="true" /> if this command can be executed; otherwise, <see langword="false" />.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            if (_executeWithParameter == null)
            {
                return false;
            }

            return _canExecute == null || _canExecute();
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
        public void Execute(object parameter)
        {
            _executeWithParameter?.Invoke(parameter);
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Raises the can execute changed.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            Application.Current?.Dispatcher?.Invoke(() => CanExecuteChanged?.Invoke(this, EventArgs.Empty));
        }

        protected override void Dispose(bool disposing)
        {
            if (_vm != null) _vm.PropertyChanged -= (sender, args) => RaiseCanExecuteChanged();

            base.Dispose(disposing);
        }
    }
}

