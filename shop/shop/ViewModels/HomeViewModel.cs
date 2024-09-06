using shop.Commands;
using shop.Models;
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
    public class HomeViewModel : ViewModelBase
    {
        public ObservableCollection<Category> Categories { get; set; }
        private Category selectedProduct;
        public Category SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        private DelegateCommand openAllProductCommand;
        public ICommand OpenAllProductCommand
        {
            get
            {
                if (openAllProductCommand == null)
                {
                    openAllProductCommand = new DelegateCommand(() =>
                    {
                        App.OpenAllProduct();
                    });
                }

                return openAllProductCommand;

            }
        }
        private DelegateCommand openCategorProductCommand;
        public ICommand OpenCategorProductCommand
        {
            get
            {
                if (openCategorProductCommand == null)
                {
                    openCategorProductCommand = new DelegateCommand(() =>
                    {
                        App.OpenAllCategorProduct(SelectedProduct);
                    });
                }

                return openCategorProductCommand;

            }
        }

        public HomeViewModel()
        {
            Categories = new ObservableCollection<Category>(db.Categories);

        }
    }
}
