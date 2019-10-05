using Shared;
using System;
using System.Windows.Input;

#nullable enable

namespace CSharp8_Examples
{

    #region Simple case
    class NullablesEnabled_1
    {
        private void ShowMessage()
        {
            var data = Calculate();
            Console.Write(data?.ToString());
        }

        public Data? Calculate()
        {
            var magic = new Magic();
            if (magic.PerformSome() == 42)
                return magic.GetSomeData();
            return null;
        }
    }

    class NullablesEnabled_2
    {
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
            return new Data();
        }
    }

    class NullablesEnabled_3
    {
        private void ShowMessage()
        {
            var data = Calculate();
            Console.Write(data!.ToString()); //I think I know better
        }

        public Data? Calculate()
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
        private Action<object> ExecuteDelagete { get; }
        private Func<object, bool>? CanExecuteDelegate { get; }

        public event EventHandler? CanExecuteChanged;

        public SimpleCommand_1(Action<object> executeDelegate, Func<object, bool>? canExecuteDelegate = null)
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

        private Action<object> ExecuteDelagete { get; }
        private Func<object, bool> CanExecuteDelegate { get; }

        public event EventHandler CanExecuteChanged = delegate { };

        public SimpleCommand_2(Action<object> executeDelegate) : this(executeDelegate, obj => true)
        {

        }

        public SimpleCommand_2(Action<object> executeDelegate, Func<object, bool> canExecuteDelegate)
        {
            ExecuteDelagete = executeDelegate;
            CanExecuteDelegate = canExecuteDelegate;
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteDelegate.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            ExecuteDelagete.Invoke(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged.Invoke(this, new EventArgs());
        }
    }
    #endregion
}
