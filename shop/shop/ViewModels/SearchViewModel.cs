using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shop.Models;
using shop.Database;
using System.Collections.ObjectModel;
using shop.Views;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Input;
using shop.Commands;
using System.Windows;
using System.Windows.Controls;
using shop.unitOfWork;
using MaterialDesignThemes.Wpf;

namespace shop.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private Page page { get; set; } = new SearchView();
        public ObservableCollection<Category> Categories { get; set; }

        private ObservableCollection<Product> products { get; set; }
        public ObservableCollection<Product> SearchProducts { get; set; }
        public ObservableCollection<Product> SortProducts { get; set; }

        private ObservableCollection<Product> productsInCart;
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

        public string SelectedSort { get; set; }
        public int SelectedSortIndex { get; set; }

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

       
        private Category selectedCategory;
        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }
        private double minValue;
        public double MinValue
        {
            get { return minValue; }
            set
            {
                minValue = Math.Round(value, 2);
                OnPropertyChanged("MinValue");
            }
        }
        private double maxValue;
        public double MaxValue
        {
            get { return maxValue; }
            set
            {
                maxValue = Math.Round(value);
                OnPropertyChanged("MaxValue");
            }
        }
        private int productsCount;
        public int ProductsCount
        {
            get { return productsCount; }
            set
            {
                productsCount = Products.Count();
                OnPropertyChanged("ProductsCount");
            }
        }
        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }
        public string textForSearch { get; set; }





        
        public SearchViewModel()
        {
            Products = new ObservableCollection<Product>(db.Products);
            SortProducts = new ObservableCollection<Product>(Products.OrderBy(x => x.Rating));
            Products = new ObservableCollection<Product>(SortProducts);
            Categories = new ObservableCollection<Category>(db.Categories);
        }
        public SearchViewModel(Category category)
        {
            Products = new ObservableCollection<Product>(db.Products.Where(c=>c.Category==category));
            SortProducts = new ObservableCollection<Product>(Products.OrderBy(x => x.Rating));
            Products = new ObservableCollection<Product>(SortProducts);
            Categories = new ObservableCollection<Category>(db.Categories);
        }

        public SearchViewModel(string searctReqest)
        {
            Products = new ObservableCollection<Product>(db.Products.Where(x => x.Title.Contains(searctReqest)));
            SortProducts = new ObservableCollection<Product>(Products.OrderBy(x => x.Rating));
            Products = new ObservableCollection<Product>(SortProducts);
            Categories = new ObservableCollection<Category>(db.Categories);
            
        }

        private DelegateCommand searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                {
                    searchCommand = new DelegateCommand(() =>
                    {
                        Products = new ObservableCollection<Product>(db.Products.Where(x => x.Title.Contains(textForSearch)));
                    });
                }
                return searchCommand;

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


                            if (SelectedProduct != null)
                            {
                                //проверка на наличие такого товара в корзине
                                var existingCartItem = db.Carts.FirstOrDefault(c => c.User == App.CurrentUser && c.Product == SelectedProduct);
                                if (existingCartItem != null)
                                {
                                    using (UnitOfWork unit = new UnitOfWork())
                                    {
                                        existingCartItem.Count += 1;
                                        unit.CartRepository.Update(existingCartItem);
                                        unit.Save();
                                    }

                                }
                                else
                                {
                                    Cart cart = new Cart();
                                    cart.Count = 1;
                                    cart.Product = SelectedProduct;
                                    cart.User = App.CurrentUser;
                                    cart.SumPrice = SelectedProduct.Price;

                                    db.Carts.Add(cart);
                                    db.SaveChanges();

                                    //using (UnitOfWork unit = new UnitOfWork())
                                    //{
                                    //    Cart cart = new Cart();
                                    //    cart.Count = 1;
                                    //    cart.Product = SelectedProduct;
                                    //    cart.User = App.CurrentUser;
                                    //    cart.SumPrice = SelectedProduct.Price;

                                    //    unit.CartRepository.Create(cart);
                                    //    unit.SaveCart();

                                    //}


                                    //db.Carts.Add(cart);
                                    //db.SaveChanges();
                                    MessageBox.Show("товар добавлен в корзину");
                                }

                            }
                            else
                                MessageBox.Show("вы ничего не выбрали");
                        }
                        else MessageBox.Show("Админ не может добавлять товары в корзину");
                    });
                }
                return addToCart;

            }
        }

        //фильтрация
        private DelegateCommand filterCommand;
        public ICommand FilterCommand
        {
            get
            {
                if (filterCommand == null)
                {
                    filterCommand = new DelegateCommand(() =>
                    {
                        if (SelectedCategory != null && MaxValue != 0)
                        {
                            Products = new ObservableCollection<Product>(db.Products.Where(x => x.Price >= MinValue && x.Price <= MaxValue && x.Category.Name == SelectedCategory.Name));

                        }

                        if (SelectedCategory != null && MinValue == 0 && MaxValue == 0)
                        {
                            Products = new ObservableCollection<Product>(db.Products.Where(x => x.Category.Name == SelectedCategory.Name));

                        }
                        if (MaxValue!=0 && SelectedCategory == null)
                        {
                            Products = new ObservableCollection<Product>(db.Products.Where(x => x.Price >= MinValue && x.Price <= MaxValue));

                        }

                        if (SelectedSortIndex == 0)
                        {
                            SortProducts = new ObservableCollection<Product>(Products.OrderBy(x => x.Price));
                            Products = new ObservableCollection<Product>(SortProducts);
                        }
                        if (SelectedSortIndex == 1)
                        {
                            SortProducts = new ObservableCollection<Product>(Products.OrderByDescending(x => x.Price));
                            Products = new ObservableCollection<Product>(SortProducts);
                        }
                        if (SelectedSortIndex == 2)
                        {
                            SortProducts = new ObservableCollection<Product>(Products.OrderByDescending(x => x.Rating));
                            Products = new ObservableCollection<Product>(SortProducts);
                        }
                        ProductsCount = Products.Count();
                    });
                }
                return filterCommand;

            }
        }
        //показать все товары
        private DelegateCommand showAllCommand;
        public ICommand ShowAllCommand
        {
            get
            {
                if (showAllCommand == null)
                {
                    showAllCommand = new DelegateCommand(() =>
                    {
                        Products = new ObservableCollection<Product>(db.Products);

                    });
                }
                ProductsCount = Products.Count();
                return showAllCommand;

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
                                if (App.CurrentUser.Login != "admin")
                                {
                                    App.OpenDetailedInfo(SelectedProduct, 0);
                                }
                                else App.OpenDetailedInfoAsAdmin(SelectedProduct, 0);

                            }
                            else
                                MessageBox.Show("вы ничего не выбрали");
                        });
                    }
                return openDetailedInfoCommand;
            }
        }




    }
}
