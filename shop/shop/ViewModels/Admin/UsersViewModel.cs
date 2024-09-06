using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using shop.Commands;
using shop.Database;
using shop.Views.Admin;
using shop.Models;
using System.Collections.ObjectModel;

namespace shop.ViewModels.Admin
{
    public class UsersViewModel : ViewModelBase
    {
        public string TextForSearch { get; set; }
        private ObservableCollection<Users> users;
        public ObservableCollection<Users> Users
        {
            get
            {
                return users;
            }
            set
            {
                users = value;
                OnPropertyChanged(nameof(Users));
            }
        }
        public UsersViewModel()
        {
            Users = new ObservableCollection<Users>(db.Users);

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

                        Users = new ObservableCollection<Users>(db.Users.Where(x => x.Login.Contains(TextForSearch)));

                    });
                }
                return searchCommand;

            }
        }
    }
}
