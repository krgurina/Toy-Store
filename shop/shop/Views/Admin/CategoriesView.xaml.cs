using shop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.IO;
using System.Collections.ObjectModel;
using shop.Models;
namespace shop.Views.Admin
{
    /// <summary>
    /// Логика взаимодействия для CategoriesView.xaml
    /// </summary>
    public partial class CategoriesView : Page
    {
        //        public BindingList<Category> categories = new BindingList<Category>();
        //        public BindingList<string> FilterList = new BindingList<string>();
        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();
        public CategoriesView()
        {
            InitializeComponent();
            //LoadData();
            //CategoryList.ItemsSource = categories;
            //categories.ListChanged += categories_ListChanged;

            //categories = LoadData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Add_Categor_Click(object sender, RoutedEventArgs e)
        {
            var newCategory = new Category() { Name = CategoryNameTxB.Text };
            Categories.Add(newCategory);
        }

        //        private void Page_Loaded(object sender, RoutedEventArgs e)
        //        {
        //            LoadData();

        //            //try
        //            //{
        //            //    LoadData();

        //            //}
        //            //catch(Exception ex)
        //            //{
        //            //    MessageBox.Show(ex.Message);
        //            //}
        //            ////categories = new BindingList<Category>()
        //            ////{
        //            ////    new Category(){Name="ddd"}
        //            ////};


        //            //CategoryList.ItemsSource = categories;
        //            //categories.ListChanged += categories_ListChanged;
        //        }

        //        public void NewElementCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        //        {
        //            categories.Add(new Category() { Name = CategoryName.Text });
        //            SaveData(categories);

        //            var categ = new Category();
        //            categ.Name = CategoryName.Text;
        //            categories.Add(categ);
        //            SaveData(categories);
        //            MessageBox.Show("ee");


        //            CategoryList.ItemsSource = categories;


        //            //uint maxId = 0;

        //            //var Sneaker = new Category();
        //            //var list = MainWindow.Sneakers.GetSneakers();
        //            //if (list != null)
        //            //    foreach (var t in list)
        //            //    {
        //            //        if (t.Id > maxId)
        //            //        {
        //            //            maxId = t.Id;
        //            //        }
        //            //    }
        //            //try
        //            //{
        //            //    Sneaker.Id = maxId + 1;

        //            //    Sneaker.Title = TitleFiled.Text;
        //            //    Sneaker.ImagePath = imgPath + ImageFiled.Text + ".jpg";


        //            //}
        //            //catch (Exception ex)
        //            //{
        //            //    MessageBox.Show(ex.Message);
        //            //}
        //            //MainWindow.Sneakers.AddItem(Sneaker);

        //            //this.Close();



        //        }



        //        //сериализация
        //        private string path = @"F:\лабы\ООП\shop\shop\categories.json";

        //        public void LoadData()
        //        {
        //            var fileExists = File.Exists(path);
        //            if (!fileExists)
        //            {
        //                File.CreateText(path).Dispose();
        //                //return new BindingList<Category>();
        //            }
        //            else
        //            {
        //                using (var reader = File.OpenText(path))
        //                {
        //                    var FileText = reader.ReadToEnd();
        //                    //return
        //                    categories = JsonConvert.DeserializeObject<BindingList<Category>>(FileText);
        //                }
        //            }
        //        }
        //        public void SaveData(Object categories)
        //        {
        //            using (StreamWriter writer = File.CreateText(path))
        //            {
        //                string output = JsonConvert.SerializeObject(categories);
        //                writer.Write(output);
        //            }
        //        }
        //        //не работает
        //        private void categories_ListChanged(object sender, ListChangedEventArgs e)
        //        {
        //            if(e.ListChangedType==ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
        //            {
        //                try
        //                {
        //                    SaveData(sender);
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show(ex.Message);
        //                }
        //            }
        //        }

        //        public void LocalCommit()
        //        {
        //            Category[] tmpl = new Category[categories.Count()];
        //            categories.CopyTo(tmpl, 0);
        //            categories.Clear();
        //            FilterList.Clear();
        //            for (int i = 0; i < tmpl.Length; i++)
        //            {
        //                bool Flag = false;

        //                categories.Add(tmpl[i]);
        //                foreach (var item2 in FilterList)
        //                {
        //                    if (tmpl[i].Name == item2)
        //                    {
        //                        Flag = true;
        //                        break;
        //                    }
        //                }
        //                if (Flag != true)
        //                {
        //                    FilterList.Add(tmpl[i].Name);
        //                }
        //            }

        //            SaveData(FilterList);
        //        }
        //        private void Button_Click(object sender, RoutedEventArgs e)
        //        {
        //            var categ = new Category();
        //            MessageBox.Show(CategoryName.Text);

        //            categ.Name = CategoryName.Text;
        //            categories.Add(categ);
        //            SaveData(categories);

        //        }
    }
}
