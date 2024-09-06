using shop.Commands;
using shop.Models;
using shop.Views.Admin;
using shop.unitOfWork;
using shop.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Controls;
using shop.Services;
using System.Data.Entity.Validation;
using System.ComponentModel.DataAnnotations;
using Microsoft.Win32;

namespace shop.ViewModels.Admin
{
    public class CategoriesViewModel : ViewModelBase
    {
        public string TextForSearch { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
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
        private string oKMessage;
        public string OKMessage
        {
            get { return oKMessage; }
            set
            {
                this.oKMessage = value;
                OnPropertyChanged("OKMessage");
            }
        }
        private Category selectedItemForDataGrid;

        public Category SelectedItemForDataGrid
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

        private ObservableCollection<Category> categories;
        public ObservableCollection<Category> Categories
        {
            get
            {
                return categories;
            }
            set
            {
                categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }
        public CategoriesViewModel()
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                Categories = new ObservableCollection<Category>(unit.CategoryRepository.Get());
            }
        }
       
        private DelegateCommand addCategoryCommand;
        public ICommand AddCategoryCommand
        {
            get
            {
                if (addCategoryCommand == null)
                {
                    addCategoryCommand = new DelegateCommand(() =>
                    {
                        try
                        {
                            ErrorMessage = string.Empty;
                            if (Name == null || Photo == null)
                            {
                                throw new Exception("все поля долны быть заполнены");
                            }
                            if (db.Categories.Any(a => a.Name == Name))
                            {
                                throw new Exception("Такая категория уже существует");
                            }
                            if (AddCategory(Name,Photo))
                            {
                                using (UnitOfWork unit = new UnitOfWork())
                                {
                                    Category category = new Category();
                                    category.Name = Name;
                                    category.ImageLink = Photo;
                                    Categories.Add(category);

                                    unit.CategoryRepository.Create(category);
                                    unit.Save();
                                }
                                ErrorMessage = string.Empty;
                                OKMessage = "Категория добавлена";
                            }
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
                return addCategoryCommand;

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
                                Photo = openFileDialog.FileName;
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
                        using (UnitOfWork unit = new UnitOfWork())
                        {
                            Categories = new ObservableCollection<Category>(unit.CategoryRepository.Get(x=>x.Name.Contains(TextForSearch)));
                        }
                    });
                }
                return searchCommand;

            }
        }

        //удалить категорию
        private DelegateCommand deleteCategoryCommand;
        public ICommand DeleteCategoryCommand
        {
            get
            {
                if (deleteCategoryCommand == null)
                {
                    deleteCategoryCommand = new DelegateCommand(() =>
                    {
                        try
                        {
                            if (SelectedItemForDataGrid == null)
                                throw new Exception("Вы не выбрали товар!");
                                    

                            if (MessageBox.Show("вы действительно хотите удалить эту категорию?", "уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {                            
                                    db.Orders.RemoveRange(db.Orders.Where(o => o.Product.Category == SelectedItemForDataGrid));
                                    db.Carts.RemoveRange(db.Carts.Where(o => o.Product.Category == SelectedItemForDataGrid));
                                    db.Products.RemoveRange(db.Products.Where(o => o.Category == SelectedItemForDataGrid));
                                    db.Categories.Remove(SelectedItemForDataGrid);
                                    Categories.Remove(SelectedItemForDataGrid);
                                    db.SaveChanges();
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
                return deleteCategoryCommand;

            }
        }

        //изменить категорию
        bool AddCategory(string Name, string Photo)
        {
            var cat = new Category
            {
                Name = Name,
                ImageLink = Photo
            };
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(cat);
            if (Validator.TryValidateObject(cat, context, results, true))
            {
                return true;
            }
            else
            {
                foreach (var error in results)
                {
                    ErrorMessage = error.ErrorMessage;
                }
            }
            return false;
        }
    }
}
