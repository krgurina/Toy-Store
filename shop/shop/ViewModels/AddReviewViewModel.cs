using shop.Commands;
using shop.Models;
using shop.unitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace shop.ViewModels
{
    public class AddReviewViewModel : ViewModelBase
    {
        public string ErrorMessage { get; set; }
        public Users User { get; set; }
        public Product Product { get; set; }
        private string review;
        public string Review
        {
            get { return review; }
            set
            {
                review = value;
                OnPropertyChanged("Review");
            }
        }
        private int userRating;
        public int UserRating
        {
            get { return userRating; }
            set
            {
                userRating = value;
                OnPropertyChanged("UserRating");
            }
        }
        private DelegateCommand sendReviewCommand;
        public ICommand SendReviewCommand
        {
            get
            {
                if (sendReviewCommand == null)
                {
                    sendReviewCommand = new DelegateCommand(() =>
                    {
                        try
                        {
                            MessageBox.Show(UserRating.ToString());

                            if (Review == String.Empty)
                            {
                                throw new Exception("Вы не ввели текст");

                            }
                            else
                            {
                                Review review = new Review();
                                review.User = App.CurrentUser;
                                review.Product = Product;
                                review.ReviewContent = Review;
                                review.UserRating = UserRating;
                                db.Reviews.Add(review);
                                db.SaveChanges();

                                var reviews = db.Reviews.Where(r => r.Product == Product);
                                int totalRatings = reviews.Sum(r => r.UserRating);
                                int reviewCount = reviews.Count();
                                double newRating = totalRatings / reviewCount;
                                double roundedRating = Math.Round(newRating, 1);
                                Product.Rating = roundedRating;

                                db.Products.Update(Product);
                                db.SaveChanges();

                                MessageBox.Show("Спасибо за ваш отзыв");

                                }
                               
                                var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
                                window.Close();
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
                            MessageBox.Show(ErrorMessage);

                        }
                       
                    });
                }
                return sendReviewCommand;

            }
        }


        public AddReviewViewModel(Users user, Product product)
        {
            User=user;
            Product=product;
        }


    }
}
