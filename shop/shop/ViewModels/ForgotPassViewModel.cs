using shop.Commands;
using shop.Models;
using shop.Services;
using shop.unitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace shop.ViewModels
{
    public class ForgotPassViewModel : ViewModelBase
    {
        private string login;

        public string Login
        {
            get { return login; }
            set
            {
                this.login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Password { get; set; }
        public string Password2 { get; set; }
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

        //назад
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

        private DelegateCommand changePassCommand;
        public ICommand ChangePassCommand
        {
            get
            {
                if (changePassCommand == null)
                {
                    changePassCommand = new DelegateCommand(() =>
                    {
                        try
                        {
                            ErrorMessage = string.Empty;
                            if (Password == null || Password2 == null || Login == null)
                            {
                                throw new Exception("все поля долны быть заполнены");
                            }
                            using (UnitOfWork unit = new UnitOfWork())
                            { 
                                Users user = db.Users.Where(x => x.Login == Login).FirstOrDefault();

                                if (user == null)
                                {
                                    throw new Exception("Такого пользователя нет");
                                }
                                if (AddUser(Password, user.Login))
                                {
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

                                    unit.UserRepository.Update(user);
                                    unit.Save();
                                    App.OpenRegSuccessView("Пароль успешно изменён");
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
                return changePassCommand;

            }
        }
        
        //функция для валидации пользователй
        bool AddUser(string Password, string Login)
        {
            using (UnitOfWork unit = new UnitOfWork())
            {
                Users users = unit.UserRepository.Get(x => x.Login == Login).FirstOrDefault();
                var user = new Users
                {
                    Login = Login,
                    Password = Password,
                    Name = users.Name,
                    Surname = users.Surname,
                    Email = users.Email,
                    Phone = users.Phone,
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
}
