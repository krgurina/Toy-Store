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

using shop.Models;
using shop.Database;


namespace shop.Views
{
    /// <summary>
    /// Логика взаимодействия для RegView.xaml
    /// </summary>

    public partial class RegView : Page
    {
        //protected int countForID = ShopDbContext.db.USERS.Count();

        public RegView()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //Database.USERS user = new Database.USERS();
            //user.ID = countForID + 1;
            //user.NAME = userName.Text;
            //user.SURNAME = userSurname.Text;
            //user.LOGIN = login.Text;
            //user.PASSWORD = password.Text;
            //user.EMAIL = userEmail.Text;
            //user.PHONE = userPhone.Text;

            //AppConnection.db.USERS.Add(user);
            //ShopDbContext.db.SaveChanges();
        }
    }
}
