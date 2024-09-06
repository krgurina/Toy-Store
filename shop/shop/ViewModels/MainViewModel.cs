using shop.Commands;
using shop.Database;
using shop.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using shop.Models;
using System.Collections.ObjectModel;
using System.Windows.Media.Animation;

namespace shop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public static RoutedCommand Exit { get; set; }
        public static string textForSearch { get; set; }


        //корзина
        private DelegateCommand openCartCommand;
        public ICommand OpenCartCommand
        {
            get
            {
                if (openCartCommand == null)
                {
                    openCartCommand = new DelegateCommand(() =>
                    {
                        textForSearch=String.Empty;
                        App.OpenCart();
                    });
                }
                return openCartCommand;

            }
        }

        //личный кабинет
        private DelegateCommand openUserCommand;
        public ICommand OpenUserCommand
        {
            get
            {
                if (openUserCommand == null)
                {
                    openUserCommand = new DelegateCommand(() =>
                    {
                        textForSearch = String.Empty;
                        App.OpenUserCab();
                    });
                }
                return openUserCommand;

            }
        }

        //о нас

        private DelegateCommand? openAboutUsCommand;
        public ICommand OpenAboutUsCommand
        {
            get
            {
                if (openAboutUsCommand == null)
                {
                    openAboutUsCommand = new DelegateCommand(App.OpenAboutUs);
                }
                return openAboutUsCommand;

            }
        }


        private DelegateCommand openCatalogCommand;
        public ICommand OpenCatalogCommand
        {
            get
            {
                if (openCatalogCommand == null)
                {
                    openCatalogCommand = new DelegateCommand(() =>
                    {
                        textForSearch = String.Empty;
                        App.OpenAllProduct();
                    });
                }
                return openCatalogCommand;

            }
        }

        //главная
        private DelegateCommand openHomePageCommand;
        public ICommand OpenHomePageCommand
        {
            get
            {
                if (openHomePageCommand == null)
                {
                    openHomePageCommand = new DelegateCommand(() =>
                    {
                        textForSearch = String.Empty;
                        App.OpenHome();
                    });
                }
                return openHomePageCommand;

            }
        }
       
        //выход
        private DelegateCommand closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                {
                    closeCommand = new DelegateCommand(() =>
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
                            App.OpenLoginWindow();
                            window.Close();
                        };
                        window.BeginAnimation(UIElement.OpacityProperty, animation);

                    });
                }
                return closeCommand;

            }
        }

        //поиск
        private DelegateCommand searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                {
                    searchCommand = new DelegateCommand(() =>
                    {
                        App.OpenAllProduct(textForSearch);
                    });
                }
                return searchCommand;

            }
        }
       

    }
}
