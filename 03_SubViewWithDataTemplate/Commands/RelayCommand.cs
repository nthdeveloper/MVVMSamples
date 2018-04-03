using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MVVMSamples.Commands
{
    public class RelayCommand<T> : ICommand
    {
        readonly Action<T> m_ExecuteFunc = null;
        readonly Predicate<T> m_CanExecuteFunc = null;

        public string Label { get; set; }

        public RelayCommand(Action<T> execute) : this(execute, null) { }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute) : this(execute, canExecute, "") { }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute, string label)
        {
            m_ExecuteFunc = execute;
            m_CanExecuteFunc = canExecute;

            Label = label;
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute, ref Action raiseCanExecute,  string label):this(execute, canExecute, label)
        {
            raiseCanExecute = RaiseCanExecuteChanged;
        }        

        public void Execute(object parameter)
        {
            m_ExecuteFunc((T)parameter);
        }

        public bool CanExecute(object parameter)
        {
            return m_CanExecuteFunc == null ? true : m_CanExecuteFunc((T)parameter);
        }

        public event EventHandler CanExecuteChanged;        

        protected void RaiseCanExecuteChanged()
        {
            var _ev = this.CanExecuteChanged;
            if (_ev != null)
                _ev(this, EventArgs.Empty);
        }
    }
}



