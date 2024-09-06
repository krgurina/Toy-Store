using Caliburn.Micro;
using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.ViewModels
{
    public class NotificationControlViewModel : PropertyChangedBase
    {
        private readonly INotificationManager nManager;
        public string MessageText;
        public NotificationControlViewModel(INotificationManager manager)
        {
            nManager = manager;
        }
        public async void Ok()
        {

        }
    }
}
