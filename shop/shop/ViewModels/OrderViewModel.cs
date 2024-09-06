using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using shop.Commands;
using shop.Models;
using shop.Resources;
using shop.unitOfWork;
using shop.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace shop.ViewModels
{
    public class OrderViewModel:ViewModelBase
    {
        public ObservableCollection<Product> products { get; set; }
        private ObservableCollection<Cart> userCart;
        public ObservableCollection<Cart> UserCart
        {
            get
            {
                return userCart;
            }
            set
            {
                userCart = value;
                OnPropertyChanged(nameof(UserCart));
            }
        }
        private string errorMes;
        public string ErrorMessage
        {
            get { return errorMes; }
            set
            {
                this.errorMes = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        private string userCartNumber;
        public string UserCartNumber
        { 
            get
            {
                return userCartNumber;
            }
            set
            {
                userCartNumber = value;
                OnPropertyChanged(nameof(UserCartNumber));
            }
        }
        private string userCartCVV;
        public string UserCartCVV
        {
            get
            {
                return userCartCVV;
            }
            set
            {
                userCartCVV = value;
                OnPropertyChanged(nameof(UserCartCVV));
            }
        }
        private string address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        private double summary;
        public double Summary
        {
            get { return summary; }
            set
            {
                summary = value;
                OnPropertyChanged("Summary");
            }
        }
        private bool _isUserControlVisible;

        public bool IsUserControlVisible
        {
            get
            {
                return _isUserControlVisible;
            }
            set
            {
                _isUserControlVisible = value;
                OnPropertyChanged("IsUserControlVisible");
            }
        }
        public string PayType { get; set; } = "";

        private bool _isRadioButton1Checked;
        public bool IsRadioButton1Checked
        {
            get { return _isRadioButton1Checked; }
            set
            {
                _isRadioButton1Checked = value;
                ShowUserControl = value ? new CartControl() : null;
                OnPropertyChanged(nameof(IsRadioButton1Checked));
                OnPropertyChanged(nameof(ShowUserControl));
            }
        }
        private bool _isRadioButton2Checked;
        public bool IsRadioButton2Checked
        {
            get { return _isRadioButton2Checked; }
            set
            {
                _isRadioButton2Checked = value;
                ShowUserControl2 = value ? new AdressControl() : null;
                OnPropertyChanged(nameof(IsRadioButton2Checked));
                OnPropertyChanged(nameof(ShowUserControl2));
            }
        }
        private UserControl _showUserControl;
        public UserControl ShowUserControl
        {
            get { return _showUserControl; }
            set
            {
                _showUserControl = value;
                OnPropertyChanged(nameof(ShowUserControl));
            }
        }
        private UserControl _showUserControl2;
        public UserControl ShowUserControl2
        {
            get { return _showUserControl2; }
            set
            {
                _showUserControl2 = value;
                OnPropertyChanged(nameof(ShowUserControl2));
            }
        }
  
        public OrderViewModel()
        {
            UserCart = new ObservableCollection<Cart>(db.Carts.Where(x => x.User.ID == App.CurrentUser.ID).Include(c => c.Product));
            foreach (var i in UserCart)
            {
                Summary += i.SumPrice;
            }
            products = new ObservableCollection<Product>();
            foreach (Cart cart in UserCart)
            {
                if (!products.Contains(cart.Product))  // проверяем, нет ли уже такого продукта в коллекции
                {
                    products.Add(cart.Product);  // добавляем продукт в коллекцию
                }
            }
        }
        //кнопка назад
        private DelegateCommand openCartCommand;
        public ICommand OpenCartCommand
        {
            get
            {
                if (openCartCommand == null)
                {
                    openCartCommand = new DelegateCommand(() =>
                    {
                        App.OpenCart();
                    });
                }
                return openCartCommand;

            }
        }
        //получить данные из 1 radiobuttn
        private DelegateCommand getPayType;
        public ICommand GetPayType
        {
            get
            {
                if (getPayType == null)
                {
                    getPayType = new DelegateCommand(() =>
                    {
                        
                    });
                }
                return getPayType;

            }
        }
        //добавление
        private DelegateCommand addOrder;
        public ICommand AddOrder
        {
            get
            {
                if (addOrder == null)
                {
                    addOrder = new DelegateCommand(() =>
                    {
                        try
                        {

                        
                        if (IsRadioButton1Checked==true)
                            CheckCart();
                        else
                            UserCartNumber = "При получении";

                        if (IsRadioButton2Checked == false)
                            Address = "Самовывоз";

                      
                        int count = UserCart.Count(); 
                        MessageBox.Show(UserCartNumber + Address);


                        foreach (Cart cart in UserCart)
                            {
                                Order order = new Order();
                                order.Cart = UserCartNumber;
                                order.Address = Address;                        
                                order.Product = cart.Product;
                                order.User = App.CurrentUser;
                                order.OrderDate = DateTime.Now;
                                order.OrderState = "В обработке";
                                order.Count = cart.Count;
                                order.SumPrice = cart.SumPrice;

                                db.Orders.Add(order);
                            }

                            foreach (Cart cart in UserCart)
                            {
                                db.Carts.Remove(cart);
                            }
                            db.SaveChanges();
                            MessageBox.Show("Заказ офрмлен");
                            App.OpenHome();
                        }
                        catch (DbEntityValidationException e)
                        {
                            foreach (DbEntityValidationResult validationRes in e.EntityValidationErrors)
                            {
                                foreach (DbValidationError err in validationRes.ValidationErrors)
                                {
                                    ErrorMessage = err.ErrorMessage;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            ErrorMessage = e.Message;
                        }
                    });
                }
                return addOrder;
            }
        }

        public void CheckCart()
        {
            string patternNumber = @"^\d{16}$";
            string patternCVV = @"^\d{3}$";

            Regex regex = new Regex(patternNumber);
            Regex regexCVV = new Regex(patternCVV);

            if (!regex.IsMatch(userCartNumber))
            {
                throw new Exception("Неверный формат номера карты");
            }
            if (!regexCVV.IsMatch(userCartCVV))
            {
                throw new Exception("Неверный формат CVV");
            }

        }

        
    }
}
