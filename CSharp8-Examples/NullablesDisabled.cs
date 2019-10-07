using Shared;
using System;
using System.Windows.Input;

namespace CSharp8_Examples.NullablesDisabled
{
    #region Simple Case
    public class SimpleClass
    {
        #nullable disable
        private void ShowMessage()
        {
            var data = Calculate();
            Console.Write(data.ToString());
        }

        public Data Calculate()
        {
            var magic = new Magic();
            if (magic.PerformSome() == 42)
                return magic.GetSomeData();
            return null;
        }
    }

    #endregion

    #region Real Life Example
    public class SimpleCommand_1 : ICommand
    {
        #nullable disable

        private Action<object> ExecuteDelagete { get; }
        private Func<object, bool> CanExecuteDelegate { get; }

        public event EventHandler CanExecuteChanged;


        public SimpleCommand_1(Action<object> executeDelegate, Func<object, bool> canExecuteDelegate = null)
        {
            ExecuteDelagete = executeDelegate;
            CanExecuteDelegate = canExecuteDelegate;
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteDelegate?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            ExecuteDelagete?.Invoke(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }

    public class SimpleCommand_2 : ICommand
    {
#nullable disable

        private Action<object> ExecuteDelagete { get; }
        private Func<object, bool> CanExecuteDelegate { get; }

        public event EventHandler CanExecuteChanged;


        public SimpleCommand_2(Action<object> executeDelegate, Func<object, bool> canExecuteDelegate = null)
        {
            ExecuteDelagete = executeDelegate;
            CanExecuteDelegate = canExecuteDelegate;
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteDelegate?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            ExecuteDelagete?.Invoke(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
    #endregion
}
