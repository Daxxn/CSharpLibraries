using System;
using System.Windows.Input;

namespace MVVMLibraryFW
{
   public class Command : ICommand
   {
      public Action<object> ExecuteDelegate { get; set; }
      public event EventHandler CanExecuteChanged = null;

      public Command() { }

      public Command(Action<object> _ExecuteDelegate)
      {
         ExecuteDelegate = _ExecuteDelegate;
      }
      public bool CanExecute(object param)
      {
         return true;
      }

      public void Execute(object _oParameter)
      {
         ExecuteDelegate?.Invoke(_oParameter);
      }
   }
}
