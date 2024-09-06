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
using shop.Views;

namespace shop.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthView.xaml
    /// </summary>
    public partial class AuthView : Page
    {
        public AuthView()
        {
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //    using (AppConnection db = new AppConnection())
        //    {

        //        var CurrentUser = db.Users.FirstOrDefault(u => u.LOGIN == login.Text && u.PASSWORD == password.Text);

        //        if (CurrentUser != null)
        //        {
        //            LoginView loginView = new LoginView();
        //            // loginView.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        //            if (CurrentUser.LOGIN == "admin" && CurrentUser.PASSWORD == "admin")
        //            {

        //                loginView.Close();

        //                Admin.Admin adminMain = new Admin.Admin();
        //                adminMain.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        //                adminMain.Show();


        //                //loginView.clo
        //            }
        //            else
        //            {
        //                loginView.Close();
        //                MainWindow main = new MainWindow();
        //                main.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        //                main.Show();
        //            }


        //        }
        //    }
        //}
    }
}
