using Shared;
using System;
using System.Windows.Input;



namespace CSharp8_Examples
{
    class NullablesDisabled
    {
        #region Simple Case
        //#nullable enable

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

        #endregion

        #region Read Life Example
        public class SimpleCommand : ICommand
        {
            #nullable enable

            private Action<object> ExecuteDelagete { get; }
            private Func<object, bool> CanExecuteDelegate { get; }

            public event EventHandler CanExecuteChanged = delegate { };

            public SimpleCommand(Action<object> executeDelegate) : this(executeDelegate, obj => true)
            {

            }

            public SimpleCommand(Action<object> executeDelegate, Func<object, bool> canExecuteDelegate)
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
}
