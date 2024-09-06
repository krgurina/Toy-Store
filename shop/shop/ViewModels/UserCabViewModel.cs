using Microsoft.EntityFrameworkCore;
using shop.Commands;
using shop.Models;
using shop.Services;
using shop.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace shop.ViewModels
{
    public class UserCabViewModel : ViewModelBase
    {
        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }

        public UserCabView userCabView { get; set; }
        public ObservableCollection<Order> OldUserOrder { get; set; }

        public string Login { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string surname;
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        private Users user;
        public Users User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        private Order selectedProduct;
        public Order SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        private ObservableCollection<Order> userOrder;
        public ObservableCollection<Order> ActiveUserOrder
        {
            get
            {
                return userOrder;
            }
            set
            {
                userOrder = value;
                OnPropertyChanged(nameof(ActiveUserOrder));
            }
        }

        private string errorMes;
        public string ErrorMessage
        {
            get { return errorMes; }
            set
            {
                this.errorMes = value;
                OnPropertyChanged("ErrorMessage");
            }
        }
        public UserCabViewModel() 
        {
            CurrentViewModel = new EditUserViewModel();

            User = new Users();
            User = App.CurrentUser;
            ActiveUserOrder = new ObservableCollection<Order>(db.Orders.Where(x => x.User.ID == App.CurrentUser.ID && x.OrderState=="В обработке" || x.OrderState == "Отправлен").Include(c => c.Product));
            OldUserOrder = new ObservableCollection<Order>(db.Orders.Where(x => x.User.ID == App.CurrentUser.ID && x.OrderState == "Доставлен").Include(c => c.Product));
            userCabView = new UserCabView();          
        }

        //открыть окно для комментов
        private DelegateCommand openAddReviewCommand;
        public ICommand OpenAddReviewCommand
        {
            get
            {
                if (openAddReviewCommand == null)
                {
                    openAddReviewCommand = new DelegateCommand(() =>
                    {
                        if (SelectedProduct != null)
                        {
                            
                            App.OpenAddReview(App.CurrentUser, SelectedProduct.Product);
                        }
                        else
                        {
                            MessageBox.Show("Вы ничего не выбрали");
                        }
                    });
                }
                return openAddReviewCommand;

            }
        }

        //открыть подробную информацию о товаре
        private DelegateCommand openDetailedInfoCommand;
        public ICommand OpenDetailedInfoCommand
        {
            get
            {
                if (openDetailedInfoCommand == null)
                {
                    openDetailedInfoCommand = new DelegateCommand(() =>
                    {
                        if (SelectedProduct != null)
                        {
                            App.OpenDetailedInfo(SelectedProduct.Product, 1);
                        }
                        else
                        {
                            MessageBox.Show("вы ничего не выбрали");

                        }
                    });
                }
                return openDetailedInfoCommand;

            }
        }
        

    }
}
