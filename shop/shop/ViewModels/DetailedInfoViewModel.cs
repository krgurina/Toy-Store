using shop.Commands;
using shop.Models;
using shop.unitOfWork;
using shop.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace shop.ViewModels
{
    public class DetailedInfoViewModel:ViewModelBase
    {
        public Product Product { get; set; }
        public int PreviousPage { get; set; }

        private ObservableCollection<Review> reviews;
        public ObservableCollection<Review> Reviews
        {
            get
            {
                return reviews;
            }
            set
            {
                reviews = value;
                OnPropertyChanged(nameof(Reviews));
            }
        }
       
        private Review selected;
        public Review Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged(nameof(Selected));
            }
        }
        private int count;
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        public DetailedInfoViewModel(Product p, int previousPage)
        {
            Product = new Product();
            Product = p;
            Count = 1;
            Reviews = new ObservableCollection<Review>(db.Reviews.Where(x => x.Product.ID == Product.ID));
            this.PreviousPage = previousPage;        
        }

        // кнопка назад
        private DelegateCommand backCommand;
        public ICommand BackCommand
        {
            get
            {
                if (backCommand == null)
                {
                    backCommand = new DelegateCommand(() =>
                    {
                        if (App.CurrentUser.Login != "admin")
                        {
                            if (PreviousPage == 0)
                            {
                                App.OpenAllProduct();
                            }
                            else App.OpenUserCab();
                        }
                        else App.OpenAllProductAsAdmin();
                    });
                }
                return backCommand;
            }
        }

        //добавление в корзину
        private DelegateCommand addToCart;
        public ICommand AddToCart
        {
            get
            {
                if (addToCart == null)
                {
                    addToCart = new DelegateCommand(() =>
                    {
                        if (App.CurrentUser.Login != "admin")
                        {

                            //проверка на наличие такого товара в корзине
                            var existingCartItem = db.Carts.FirstOrDefault(c => c.User == App.CurrentUser && c.Product == Product);
                            if (existingCartItem != null)
                            {
                                //using (UnitOfWork unit = new UnitOfWork())
                                //{
                                    existingCartItem.Count += Count;
                                db.Carts.Update(existingCartItem);
                                db.SaveChanges();
                               //     unit.CartRepository.Update(existingCartItem);
                               //     unit.Save();
                               //// }
                            }
                            else
                            {
                                //using (UnitOfWork unit = new UnitOfWork())
                                //{
                                    Cart cart = new Cart();
                                    if (Product != null)
                                    {
                                        cart.Count = Count;
                                        cart.Product = Product;
                                        cart.User = App.CurrentUser;
                                        cart.SumPrice = Product.Price * Count;

                                    db.Carts.Add(cart);
                                    db.SaveChanges();
                                    //unit.CartRepository.Create(cart);
                                    //    unit.Save();
                                        MessageBox.Show("товар добавлен в корзину");
                                    }
                                    else MessageBox.Show("товар не найден");
                               // }

                            }
                        }
                        else MessageBox.Show("Вы админ");
                    });
                }
                return addToCart;

            }
        }

        //увеличение количества
        private DelegateCommand increaseCount;
        public ICommand IncreaseCount
        {
            get
            {
                if (increaseCount == null)
                {
                    increaseCount = new DelegateCommand(() =>
                    {
                        Count++;
                    });
                }
                return increaseCount;

            }
        }

        private DelegateCommand decreaseCount;
        public ICommand DecreaseCount
        {
            get
            {
                if (decreaseCount == null)
                {
                    decreaseCount = new DelegateCommand(() =>
                    {
                        Count--;
                    });
                }
                return decreaseCount;

            }
        }

        

    }
}
