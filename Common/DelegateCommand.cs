using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WpfMvvmLearn.Common
{
    public class DelegateCommand : ICommand
    {
        private Action _execute;
        private Func<bool> _canExecute;

        public DelegateCommand(Action execute) : this(execute, () => true) { }

        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }

    public class DelegateCommand<T> : ICommand
    {

        private readonly Action<T> _execute;
        private readonly Func<bool> _canExecute;

        public DelegateCommand(Action<T> execute) : this(execute, () => true) { }

        public DelegateCommand(Action<T> execute, Func<bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
