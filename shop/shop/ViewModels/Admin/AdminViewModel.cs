using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using shop.Views.Admin;
using shop.Commands;
using System.Windows;
using shop.ViewModels.Admin;
using shop.Models;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace shop.ViewModels.Admin
{
    public class AdminViewModel : ViewModelBase
    {
        
        private DelegateCommand openCategoriesCommand;
        public ICommand OpenCategoriesCommand
        {
            get
            {
                if (openCategoriesCommand == null)
                {
                    openCategoriesCommand = new DelegateCommand(() =>
                    {
                        App.OpenAdminCategory();
                    });
                }
                return openCategoriesCommand;

            }
        }

        private DelegateCommand openProductsCommand;
        public ICommand OpenProductsCommand
        {
            get
            {
                if (openProductsCommand == null)
                {
                    openProductsCommand = new DelegateCommand(() =>
                    {
                        App.OpenAdminProducts();
                    });
                }
                return openProductsCommand;

            }
        }

        private DelegateCommand openUsersCommand;
        public ICommand OpenUsersCommand
        {
            get
            {
                if (openUsersCommand == null)
                {
                    openUsersCommand = new DelegateCommand(() =>
                    {
                        App.OpenAdminUsers();
                    });
                }
                return openUsersCommand;

            }
        }

        private DelegateCommand openOdersCommand;
        public ICommand OpenOdersCommand
        {
            get
            {
                if (openOdersCommand == null)
                {
                    openOdersCommand = new DelegateCommand(() =>
                    {
                        App.OpenAdminOrders();
                    });
                }
                return openOdersCommand;

            }
        }

        private DelegateCommand openCatalogCommand;
        public ICommand OpenCatalogCommand
        {
            get
            {
                if (openCatalogCommand == null)
                {
                    openCatalogCommand = new DelegateCommand(App.OpenAllProductAsAdmin);
                }
                return openCatalogCommand;

            }
        }

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






    }
}
