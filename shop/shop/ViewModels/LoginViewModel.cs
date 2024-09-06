using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public static void Close()
        {
            var window = System.Windows.Application.Current.Windows;
            window[0].Close();
        }
    }
}
