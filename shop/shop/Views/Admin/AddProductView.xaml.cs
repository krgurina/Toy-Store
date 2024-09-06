using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using shop.Database;
using shop.Models;

namespace shop.Views
{
    /// <summary>
    /// Логика взаимодействия для AddProductView.xaml
    /// </summary>
    public partial class AddProductView : Page
    { 
        //Category cat = new Category();
       // public int countForID = ShopDbContext.db.PRODUCTS.Count();

        public AddProductView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ShopDbContext.db.PRODUCTS.Last().ID
            //MessageBox.Show(ShopDbContext.db.PRODUCTS.Count().ToString());
            //Database.PRODUCTS product = new Database.PRODUCTS();
            //product.ID = ShopDbContext.db.PRODUCTS.Count()+1;
            //product.TITLE = ProductName.Text;
            //product.CATEGORY = ProductCategoryName.Text;
            //product.PRICE = Convert.ToInt32(Price.Text);///
            //product.PTING = Convert.ToInt32(Rating.Text);
            //product.DISCRIPTION = ProductDescription.Text;

            //ShopDbContext.db.PRODUCTS.Add(product);
            //ShopDbContext.db.SaveChanges();

            //ProductsGrid.ItemsSource = ShopDbContext.db.PRODUCTS.ToList();

            //   var currentProd = ShopDbContext.db.PRODUCTS.FirstOrDefault(u=>u.TITLE == ProductName.Text&& u.CATEGORY== ProductCategoryName.Text)
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           // ProductsGrid.ItemsSource = ShopDbContext.db.PRODUCTS.ToList();
        }

        //private void Button_delete_Click(object sender, RoutedEventArgs e)
        //{
        //    if (MessageBox.Show("вы действительно хотите удалить этот товар?","уведомление",MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes)
        //    {
        //        //var CurrentItem = ProductsGrid.SelectedItem as PRODUCTS;
        //        //ShopDbContext.db.PRODUCTS.Remove(CurrentItem);
        //        //ShopDbContext.db.SaveChanges();

        //        //ProductsGrid.ItemsSource = ShopDbContext.db.PRODUCTS.ToList();
        //    }
        //}

        private void SearchRequest_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                //ProductsGrid.ItemsSource = ShopDbContext.db.PRODUCTS.Where(item => item.TITLE == SearchRequest.Text || item.TITLE.Contains(SearchRequest.Text)|| item.CATEGORY == SearchRequest.Text || item.CATEGORY.Contains(SearchRequest.Text)).ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
