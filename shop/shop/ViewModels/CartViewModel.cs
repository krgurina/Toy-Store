using Microsoft.EntityFrameworkCore;
using shop.Commands;
using shop.Models;
using shop.unitOfWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace shop.ViewModels
{
    public class CartViewModel : ViewModelBase
    {
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
        private ObservableCollection<Product> productsInCart { get; set; }
        public ObservableCollection<Product> ProductsInCart
        {
            get
            {
                return productsInCart;
            }
            set
            {
                productsInCart = value;
                OnPropertyChanged(nameof(ProductsInCart));
            }
        }
        private string productPrice;
        public string ProductPrice
        {
            get
            {
                return productPrice;
            }
            set
            {
                productPrice = value;
                OnPropertyChanged(nameof(ProductPrice));
            }
        }
        
        private Cart selectedProduct;
        public Cart SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        private double summary;
        public double Summary
        {
            get { return summary; }
            set
            {
                summary = value;
                OnPropertyChanged(nameof(Summary));
            }
        }

        private int summaryCount;
        public int SummaryCount
        {
            get { return summaryCount; }
            set
            {
                summaryCount = value;
                OnPropertyChanged(nameof(SummaryCount));
            }
        }
        public CartViewModel()
        {
            Update();
        }

        private DelegateCommand openOrderCommand;
        public ICommand OpenOrderCommand
        {
            get
            {
                if (openOrderCommand == null)
                {
                    openOrderCommand = new DelegateCommand(() =>
                    {
                        App.OpenOrder();
                    });
                }
                return openOrderCommand;

            }
        }

      

        private DelegateCommand increaseCount;
        public ICommand IncreaseCount
        {
            get
            {
                if (increaseCount == null)
                {
                    increaseCount = new DelegateCommand(() =>
                    {
                        if (SelectedProduct != null)
                        {
                            using (UnitOfWork unit = new UnitOfWork())
                            {
                                Cart cart = db.Carts.Where(x => x.ID == SelectedProduct.ID).FirstOrDefault();
                                cart.Count++;
                                cart.SumPrice = cart.Count * SelectedProduct.Product.Price;

                                unit.CartRepository.Update(cart);
                                unit.Save();
                            }            
                            Update();
                        }
                        else
                            MessageBox.Show("вы ничего не выбрали");



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
                        if (SelectedProduct != null)
                        {
                            using (UnitOfWork unit = new UnitOfWork())
                            {
                                Cart cart = db.Carts.Where(x => x.ID == SelectedProduct.ID).FirstOrDefault();
                                cart.Count--;
                                cart.SumPrice = cart.Count * SelectedProduct.Product.Price;


                                //SelectedProduct.Count--;
                                if (cart.Count == 0 || SelectedProduct.Count == 0)
                                {
                                    //db.Carts.Remove(cart);

                                    unit.CartRepository.Remove(cart);
                                    unit.Save();

                                    //db.Carts.Remove(cart);
                                    //db.SaveChanges();
                                    Update();
                                    MessageBox.Show("товар удален");

                                }
                                else
                                    unit.CartRepository.Update(cart);


                                unit.Save();
                            }
                            
                            Update();
                        }
                        else
                            MessageBox.Show("вы ничего не выбрали");



                    });
                }
                return decreaseCount;

            }
        }

        //удалить элемент 
        private DelegateCommand deleteFromCart;
        public ICommand DeleteFromCart
        {
            get
            {
                if (deleteFromCart == null)
                {
                    deleteFromCart = new DelegateCommand(() =>
                    {
                        if (SelectedProduct != null)
                        {
                            using (UnitOfWork unit = new UnitOfWork())
                            {
                                Cart cart = db.Carts.Where(x => x.ID == SelectedProduct.ID).FirstOrDefault();

                                if (cart != null)
                                {
                                    unit.CartRepository.Remove(cart);
                                    unit.Save();

                                    //db.Carts.Remove(cart);
                                    //db.SaveChanges();
                                    Update();
                                    MessageBox.Show("товар удален");
                                }
                                else MessageBox.Show("такого товара нет в бд");

                                
                            }

                            


                        }
                        else
                            MessageBox.Show("вы ничего не выбрали");



                    });
                }
                return deleteFromCart;

            }
        }
        public void Update()
        {
            Summary = 0;
            SummaryCount = 0;
            UserCart = new ObservableCollection<Cart>(db.Carts.Where(x => x.User.ID == App.CurrentUser.ID).Include(c => c.Product));
            foreach (var i in UserCart)
            {
                Summary += i.SumPrice;
                SummaryCount += i.Count;
            }
        }
    }
}
