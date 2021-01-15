using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMLibraryFW
{
   public class BaseCommand : ICommand
   {
      public Action<object> ExecuteDelegate { get; set; }
      public event EventHandler CanExecuteChanged = null;

      public BaseCommand() { }

      public BaseCommand(Action<object> _ExecuteDelegate)
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
