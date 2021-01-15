using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

      /// <summary>
      /// Testing Only. I wanna know what the hell this does and why it was written.
      /// </summary>
      protected bool SetProperty<T>(ref T _tField, T _tValue, out T _tPreviousValue, [CallerMemberName] string _sPropertyName = null)
      {
         if (!object.Equals(_tField, _tValue))
         {
            _tPreviousValue = _tField;
            _tField = _tValue;
            this.OnPropertyChanged(_sPropertyName);
            return true;
         }

         _tPreviousValue = default(T);
         return false;
      }
   }
}
