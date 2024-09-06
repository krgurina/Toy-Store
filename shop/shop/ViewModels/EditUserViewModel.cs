using Microsoft.Win32;
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
using System.Windows;
using System.Windows.Input;

namespace shop.ViewModels
{
    public class EditUserViewModel : ViewModelBase
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string surname;
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        private string photo;
        public string Photo
        {
            get
            {
                return photo;
            }
            set
            {
                photo = value;
                OnPropertyChanged(nameof(Photo));
            }
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        private string message;
        public string OKMessage
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                OnPropertyChanged(nameof(OKMessage));
            }
        }

        private Users user;
        public Users User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        //изменить данные пользователя
        private DelegateCommand updUserCommand;
        public ICommand UpdUserCommand

        {
            get
            {
                if (updUserCommand == null)
                {
                    updUserCommand = new DelegateCommand(() =>
                    {
                        try
                        {

                            if (Login != null || Name != null || Surname != null || Email != null || Phone != null)
                            {
                                if (AddUser(Login, Name, Surname, Email, Phone))
                                {
                                                                        MessageBox.Show("Спасибо за ваш отзыв");
                                    using (UnitOfWork unit = new UnitOfWork())
                                    {
                                        //если логин изменился
                                        if (User.Login != Login)
                                        {
                                            if (db.Users.Any(a => a.Login == Login || a.Email == Email))
                                            {
                                                throw new Exception("Пользователь с такими данными уже существует");
                                            }
                                        }

                                        User.Login = Login;
                                        User.Name = Name;
                                        User.Surname = Surname;
                                        User.Email = Email;
                                        User.Phone = Phone;

                                        //db.Users.Update(User);
                                        //db.SaveChanges();

                                        unit.UserRepository.Update(User);
                                        unit.Save();
                                    }
                                    
                                    ErrorMessage = String.Empty;
                                    OKMessage = "Данные изменены";
                                }
                                    
                            }

                            else throw new Exception("Введите все данные");
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
                            OKMessage = String.Empty;
                            ErrorMessage = e.Message;
                        }
                    });
                }
                return updUserCommand;

            }
        }

        //фото пользователя
        private DelegateCommand changePhotoCommand;
        public ICommand ChangePhotoCommand

        {
            get
            {
                if (changePhotoCommand == null)
                {
                    changePhotoCommand = new DelegateCommand(() =>
                    {
                        try
                        {
                            var openFileDialog = new OpenFileDialog();
                            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
                            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                            bool? result = openFileDialog.ShowDialog();
                            if (result == true)
                            {
                                using (UnitOfWork unit = new UnitOfWork())
                                {
                                    Photo = openFileDialog.FileName;
                                    User.Photo = Photo;
                                    //db.Users.Update(User);
                                    //db.SaveChanges();

                                    unit.UserRepository.Update(User);
                                    unit.Save();
                                }
                                
                                ErrorMessage = String.Empty;
                                OKMessage = "Фото изменено";
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
                            OKMessage = String.Empty;
                           ErrorMessage = e.Message;
                        }
                    });
                }
                return changePhotoCommand;
            }
        }

        public EditUserViewModel()
        {
            User = new Users();
            User = App.CurrentUser;

            //заполение полей
            Login = User.Login;
            Name = User.Name;
            Surname = User.Surname;
            Email = User.Email;
            Phone = User.Phone;
            Photo = User.Photo;
        }
        //функция для валидации пользователй
        bool AddUser(string Login, string Name, string Surname, string Email, string Phone)
        {
           // using (UnitOfWork unit = new UnitOfWork())
            //{


                //string pas = unit.UserRepository.Get(x => x.Login == App.CurrentUser.Login).FirstOrDefault().Password;
              //  pas = SecurePassService.Hash(pas);
                var user = new Users
                {
                    Name = Name,
                    Surname = Surname,
                    Login = Login,
                    Password = App.CurrentUser.Login,
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
                    OKMessage = String.Empty;
                    foreach (var error in results)
                    {
                        ErrorMessage = error.ErrorMessage;
                    }
                }
                return false;
           // }
        }
    }
}
