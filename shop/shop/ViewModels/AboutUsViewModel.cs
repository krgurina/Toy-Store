using shop.Commands;
using shop.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace shop.ViewModels
{
    public class AboutUsViewModel : ViewModelBase
    {
        private string oKMessage;
        public string OKMessage
        {
            get
            {
                return oKMessage;
            }
            set
            {
                oKMessage = value;
                OnPropertyChanged(nameof(OKMessage));
            }
        }
        private string messageText;
        public string MessageText
        {
            get
            {
                return messageText;
            }
            set
            {
                messageText = value;
                OnPropertyChanged(nameof(MessageText));
            }
        }
        private DelegateCommand sendMessageCommand;
        public ICommand SendMessageCommand

        {
            get
            {
                if (sendMessageCommand == null)
                {
                    sendMessageCommand = new DelegateCommand(() =>
                    {
                        try
                        {
                            EmailSenderService.SendEmailFromUser(App.CurrentUser.Email, App.CurrentUser.Login,MessageText);
                        }
                        catch (Exception ex)
                        {
                            OKMessage = ex.Message;
                        }
                        MessageText=String.Empty;
                        OKMessage = "Письмо отправлено";
                    });
                }
                return sendMessageCommand;

            }
        }
        //сслыки
        private DelegateCommand openVKCommand;
        public ICommand OpenVKCommand

        {
            get
            {
                if (openVKCommand == null)
                {
                    openVKCommand = new DelegateCommand(() =>
                    {
                        string vkUrl = "https://www.instagram.com/";
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = vkUrl,
                            UseShellExecute = true
                        });
                    });
                }
                return openVKCommand;

            }
        }
    }
}
