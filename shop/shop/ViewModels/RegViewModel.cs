using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using shop.Views;
using shop.Commands;
using shop.Database;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using shop.Models;
using shop.Services;
using System.ComponentModel.DataAnnotations;
using shop.unitOfWork;

namespace shop.ViewModels
{
    public class RegViewModel : ViewModelBase
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

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

        private DelegateCommand regUserCommand;
        public ICommand RegUserCommand
        {
            get
            {
                if (regUserCommand == null)
                {
                    regUserCommand = new DelegateCommand(() =>
                    {
                        try
                        {
                            ErrorMessage = string.Empty;
                            if (Login == null || Name == null || Surname == null || Password == null || Email == null || Phone == null)
                            {
                                throw new Exception("все поля долны быть заполнены");
                            }
                        
                            if (AddUser(Login, Name, Surname, Password, Email, Phone))
                            {
                                using (UnitOfWork unit = new UnitOfWork())
                                {
                                    Users user = new Users();
                                user.Login = Login;
                                if (Password != Password2)
                                {
                                    throw new Exception("Пароли не совпадают");

                                }
                                if (Password != null & Password[0] != ' ')
                                {
                                    user.Password = SecurePassService.Hash(Password);
                                }
                                else
                                {
                                    throw new Exception("Не верный формат пароля");
                                }
                                user.Name = Name;
                                user.Surname = Surname;
                                user.Email = Email;
                                user.Phone = Phone;

                                if (Login != null || Password != null)
                                {

                                    if (db.Users.Any(a => a.Login == Login))
                                    {
                                        throw new Exception("Пользователь с таким логином уже существует");
                                    }
                                    unit.UserRepository.Create(user);
                                    unit.Save();
                                }                      
                                    EmailSenderService.SendEmail(App.CurrentUser.Email, "Успешная регистрация", "Приятныъ покупок!");
                                    App.OpenRegSuccessView("Вы успешно зарегистрировались");
                                }
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
                return regUserCommand;

            }
        }

        private DelegateCommand openAuthCommand;
        public ICommand OpenAuthCommand
        {
            get
            {
                if (openAuthCommand == null)
                {
                    openAuthCommand = new DelegateCommand(() =>
                    {
                        App.OpenAuth();
                    });
                }
                return openAuthCommand;

            }
        }

        //функция для валидации пользователй
        bool AddUser(string Login, string Name, string Surname, string Password, string Email, string Phone)
        {
            var user = new Users
            {
                Name = Name,
                Surname = Surname,
                Login = Login,
                Password = Password,
                Email = Email,
                Phone = Phone
            };
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(user);
            if (Validator.TryValidateObject(user, context, results, true))
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
