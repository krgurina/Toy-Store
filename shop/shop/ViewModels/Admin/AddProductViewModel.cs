using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using shop.Commands;
using shop.Database;
using shop.Models;
using System.Windows;
using shop.Views;
using shop.Views.Admin;
using shop.unitOfWork;
using Microsoft.Win32;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.ComponentModel.DataAnnotations;
using System.Windows.Controls.Primitives;

namespace shop.ViewModels.Admin
{
    public class AddProductViewModel : ViewModelBase
    {
        public string TextForSearch { get; set; }

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
        private string oKMessage;
        public string OKMessage
        {
            get { return oKMessage; }
            set
            {
                this.oKMessage = value;
                OnPropertyChanged(nameof(OKMessage));
            }
        }
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                this.title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        private string price;
        public string Price
        {
            get { return price; }
            set
            {
                this.price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                this.description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        private string imageLink;
        public string ImageLink
        {
            get { return imageLink; }
            set
            {
                this.imageLink = value;
                OnPropertyChanged(nameof(ImageLink));
            }
        }
        private Category category;
        public Category Category
        {
            get { return category; }
            set
            {
                this.category = value;
                OnPropertyChanged(nameof(Category));
            }
        }
       
        public ObservableCollection<Category> Categories { get; set; }
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }
        private Category selectedProduct;
        public Category SelectedCategory
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        private Product selectedItemForDataGrid;

        public Product SelectedItemForDataGrid
        {
            get
            {
                return selectedItemForDataGrid;
            }
            set
            {
                selectedItemForDataGrid = value;
                OnPropertyChanged(nameof(SelectedItemForDataGrid));
            }
        }

        public AddProductViewModel()
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                Products = new ObservableCollection<Product>(unit.ProductRepository.GetWithInclude(c => c.Category));
                Categories = new ObservableCollection<Category>(unit.CategoryRepository.Get());
            }
           
        }

      //добавление товара
        private DelegateCommand addProducеCommand;
        public ICommand AddProductCommand
        {
            get
            {
                if (addProducеCommand == null)
                {
                    addProducеCommand = new DelegateCommand(() =>
                    {
                        try
                        {
                            
                                ErrorMessage = string.Empty;
                            if (Title != null || SelectedCategory != null || Price != null || Description != null || ImageLink != null)
                            {
                                if (AddProduct(Title, SelectedCategory, Price, Description, ImageLink))
                                {
                                    using (UnitOfWork unit = new UnitOfWork())
                                    {
                                        Product product = new Product();
                                        product.Title = Title;
                                        product.Category = unit.CategoryRepository.FindById(SelectedCategory.CategoryId) ;
                                        product.Price = Convert.ToDouble(Price);
                                        product.Rating = 0;
                                        product.Description = Description;
                                        product.ImageLink = ImageLink;

                                        if (db.Products.Any(a => a == product))
                                        {
                                            throw new Exception("Такой товар уже существует");
                                        }
                                        Products.Add(product);
                                        unit.ProductRepository.Create(product);
                                        unit.Save();
                                    }                                   
                                    ErrorMessage = string.Empty;
                                    OKMessage = "товар добавлен";
                                }
                            }
                            else throw new Exception("все поля долны быть заполнены");

                        }
                        catch (DbEntityValidationException e)
                        {
                            foreach (DbEntityValidationResult validationRes in e.EntityValidationErrors)
                            {
                                foreach (DbValidationError err in validationRes.ValidationErrors)
                                {
                                    OKMessage = string.Empty;
                                    MessageBox.Show(err.ErrorMessage);
                                    ErrorMessage = err.ErrorMessage;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            OKMessage = string.Empty;
                            MessageBox.Show(e.Message);
                            ErrorMessage = e.Message;
                        }

                    });
                }
                return addProducеCommand;
            }
        }
        private DelegateCommand changeProducеCommand;
        public ICommand ChangeProducеCommand
        {
            get
            {
                if (changeProducеCommand == null)
                {
                    changeProducеCommand = new DelegateCommand(() =>
                    {
                        if (Title != null || Category != null || Price != null || Description != null || ImageLink != null)
                        {
                            if (AddProduct(Title, SelectedCategory, Price, Description, ImageLink))
                            {
                                Product product = SelectedItemForDataGrid;
                                product.Title = Title;
                                product.Category = SelectedCategory;
                                product.Price = Convert.ToDouble(Price);
                                product.Rating = product.Rating;
                                product.Description = Description;
                                product.ImageLink = ImageLink;

                                db.Products.Update(product);
                                db.SaveChanges();
                                Products = new ObservableCollection<Product>(db.Products.Include(c => c.Category));


                                MessageBox.Show("товар изменен");
                            }
                        }
                        else throw new Exception("Введите все данные");
                    });
                }
                return changeProducеCommand;

            }
        }
        //фото 
        private DelegateCommand addPhotoCommand;
        public ICommand AddPhotoCommand
        {
            get
            {
                if (addPhotoCommand == null)
                {
                    addPhotoCommand = new DelegateCommand(() =>
                    {
                        try
                        {
                            var openFileDialog = new OpenFileDialog();
                            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
                            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                            bool? result = openFileDialog.ShowDialog();
                            if (result == true)
                            {
                                ImageLink = openFileDialog.FileName;
                                ErrorMessage = String.Empty;
                                OKMessage = "Фото изменено";
                            }
                        }
                        catch (Exception e)
                        {
                            ErrorMessage = e.Message;
                        }
                    });
                }
                return addPhotoCommand;
            }
        }

        //заполнить поля по выбранному объекту
         private DelegateCommand startEditCommand;
        public ICommand StartEditCommand

        {
            get
            {
                if (startEditCommand == null)
                {
                    
                    startEditCommand = new DelegateCommand(() =>
                    {
                        try
                        {
                            if (SelectedItemForDataGrid == null)
                                throw new Exception("Вы не выбрали товар");
                            MessageBox.Show(SelectedItemForDataGrid.Title);

                            Title = SelectedItemForDataGrid.Title;
                            SelectedCategory = SelectedItemForDataGrid.Category;
                            
                            Price = SelectedItemForDataGrid.Price.ToString();
                            Description = SelectedItemForDataGrid.Description;
                            ImageLink = SelectedItemForDataGrid.ImageLink;
                        }
                        catch (Exception e)
                        {
                            ErrorMessage = e.Message;
                        }
                    });
                }
                return startEditCommand;
            }
        }

        //удалить продукт
        private DelegateCommand deleteProducеCommand;
        public ICommand DeleteProducеCommand
        {
            get
            {
                if (deleteProducеCommand == null)
                {
                    deleteProducеCommand = new DelegateCommand(() =>
                    {
                    try
                        {
                            if (MessageBox.Show("вы действительно хотите удалить этот товар?", "уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                if (SelectedItemForDataGrid != null)
                                {
                                    db.Orders.RemoveRange(db.Orders.Where(o => o.Product == SelectedItemForDataGrid));
                                    db.SaveChanges();

                                    db.Carts.RemoveRange(db.Carts.Where(o => o.Product == SelectedItemForDataGrid));
                                    db.SaveChanges();

                                    db.Products.Remove(SelectedItemForDataGrid);
                                    Products.Remove(SelectedItemForDataGrid);
                                    db.SaveChanges();

                                }
                                else
                                {
                                ErrorMessage="Вы не выбрали товар!";
                                }
                               
                            }
                        }
                         catch (DbEntityValidationException e)
                         {
                            foreach (DbEntityValidationResult validationRes in e.EntityValidationErrors)
                            {
                        foreach (DbValidationError err in validationRes.ValidationErrors)
                        {
                                    OKMessage = String.Empty;
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
                return deleteProducеCommand;

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
                        Products = new ObservableCollection<Product>(db.Products.Where(x => x.Title.Contains(TextForSearch)||x.Category.Name.Contains(TextForSearch)));
                    });
                }
                return searchCommand;

            }
        }

        bool AddProduct(string Title, Category category, string Price, string Description, string ImageLink)
        {
            var product = new Product
            {
                Title = Title,
                Category = Category,
                Price = Convert.ToDouble(Price),
                Description = Description,
                ImageLink = ImageLink,
                Rating = 0
        };
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(product);
            if (Validator.TryValidateObject(product, context, results, true))
            {
                ErrorMessage = String.Empty;
                return true;
            }
            else
            {
                foreach (var error in results)
                {
                    OKMessage = String.Empty;
                    ErrorMessage = error.ErrorMessage;
                }
            }
            return false;
        }



    }
}
