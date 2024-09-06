using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using shop.Commands;
using shop.Database;
using shop.ViewModels;
using shop.ViewModels.Admin;
using shop.Views;
using shop.Views.Admin;
using shop.Models;
using System.Windows.Media.Animation;
using shop.Services;

namespace shop.ViewModels
{
    public class AuthViewModel : ViewModelBase
    {
       
        //логин
        private string login;

        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        // пароль
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                this.errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }
        private DelegateCommand loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new DelegateCommand(() =>
                    {
                        if (Login == null | Password == null)
                        ErrorMessage = "Введите все данные!";
                        else
                        {
                            //раскодирование паролей
                            Password = SecurePassService.Hash(Password);
                            App.CurrentUser = db.Users.Where(a => a.Login == Login && a.Password == Password).FirstOrDefault();

                            if (App.CurrentUser != null)
                            {
                                if (App.CurrentUser.Login == "admin")
                                {
                                    Close();
                                    App.StartAdmin();
                                }
                                else
                                {
                                    Close();
                                    App.StartUser();

                                }
                            }
                            else
                            {
                            ErrorMessage= "такого пользователя нет";
                            }
                        }

                      
                    });
                }
                
                return loginCommand;

            }
        }

       
        private DelegateCommand openRegCommand;
        public ICommand OpenRegCommand
        {
            get
            {
                if (openRegCommand == null)
                {
                    openRegCommand = new DelegateCommand(() =>
                    {
                        App.OpenReg();
                    });
                }
                return openRegCommand;

            }
        }


        private DelegateCommand openForgonPassCommand;
        public ICommand OpenForgonPassCommand
        {
            get
            {
                if (openForgonPassCommand == null)
                {
                    openForgonPassCommand = new DelegateCommand(() =>
                    {
                        App.OpenForgonPass();
                    });
                }
                return openForgonPassCommand;

            }
        }

        public void Close()
        {
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            DoubleAnimation animation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = TimeSpan.FromSeconds(0.5)
            };
            animation.Completed += (s, e) =>
            {
                window.Visibility = Visibility.Hidden;
                window.Close();
            };
            window.BeginAnimation(UIElement.OpacityProperty, animation);
        }
    }
}
