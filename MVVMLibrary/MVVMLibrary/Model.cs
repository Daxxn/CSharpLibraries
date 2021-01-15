using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMLibraryFW
{
   public class BaseModel : INotifyPropertyChanged
   {
      public event PropertyChangedEventHandler PropertyChanged = (s, e) => { };

      public void OnPropertyChanged([CallerMemberName] string name = null)
      {
         if (!String.IsNullOrEmpty(name))
         {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
         }
      }
   }
}
