using shop.Commands;
using shop.Models;
using shop.Services;
using shop.unitOfWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace shop.ViewModels.Admin
{
    public class OrdersViewModel : ViewModelBase
    {
        private ObservableCollection<Order> orders;
        public ObservableCollection<Order> Orders
        {
            get
            {
                return orders;
            }
            set
            {
                orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        private Order selectedItemForDataGrid;
        public Order SelectedItemForDataGrid
        {
            get
            {
                return selectedItemForDataGrid;
            }
            set
            {
                selectedItemForDataGrid = value;
                OnPropertyChanged(nameof(SelectedItemForDataGrid));
            }
        }
        private string orderState;
        public string OrderState
        {
            get
            {
                return orderState;
            }
            set
            {
                orderState = value;
                OnPropertyChanged(nameof(OrderState));
            }
        }
        public OrdersViewModel() {

            using (UnitOfWork unit = new UnitOfWork())
            {
                Orders = new ObservableCollection<Order>(unit.OrderRepository.GetWithInclude(c => c.Product, c => c.User));
            }
        }

        //установить новый статус
        private DelegateCommand setStatus1Command;
        public ICommand SetStatus1Command
        {
            get
            {
                if (setStatus1Command == null)
                {
                    setStatus1Command = new DelegateCommand(() =>
                    {
                        if (SelectedItemForDataGrid != null)
                        {
                            using (UnitOfWork unit = new UnitOfWork())
                            {
                                Order order = SelectedItemForDataGrid;
                                order.OrderState = "В обработке";
                                unit.OrderRepository.Update(order);
                                unit.Save();
                                Orders = new ObservableCollection<Order>(unit.OrderRepository.GetWithInclude(c => c.Product, c => c.User));
                            }

                        }
                        else MessageBox.Show("Вы ничего не выбрали");
                    });
                }
                return setStatus1Command;
            }
        }

        private DelegateCommand setStatus2Command;
        public ICommand SetStatus2Command
        {
            get
            {
                if (setStatus2Command == null)
                {
                    setStatus2Command = new DelegateCommand(() =>
                    {
                        if (SelectedItemForDataGrid != null)
                        {
                            using (UnitOfWork unit = new UnitOfWork())
                            {
                                Order order = SelectedItemForDataGrid;
                                order.OrderState = "Отправлен";
                                unit.OrderRepository.Update(order);
                                unit.Save();
                                Orders = new ObservableCollection<Order>(unit.OrderRepository.GetWithInclude(c => c.Product, c => c.User));
                            }
                        }
                        else MessageBox.Show("Вы ничего не выбрали");
                    });
                }
                return setStatus2Command;

            }
        }
        private DelegateCommand setStatus3Command;
        public ICommand SetStatus3Command
        {
            get
            {
                if (setStatus3Command == null)
                {
                    setStatus3Command = new DelegateCommand(() =>
                    {
                        if (SelectedItemForDataGrid != null)
                        {
                            string email = SelectedItemForDataGrid.User.Email;

                            using (UnitOfWork unit = new UnitOfWork())
                            {
                                Order order = SelectedItemForDataGrid;
                                order.OrderState = "Доставлен";
                                unit.OrderRepository.Update(order);
                                unit.Save();
                                Orders = new ObservableCollection<Order>(unit.OrderRepository.GetWithInclude(c => c.Product, c => c.User));
                            }
                            EmailSenderService.SendEmail(email, "Заказ доставлен", "Не забудьте написать отзыв))");
                        }
                        else MessageBox.Show("Вы ничего не выбрали");
                    });
                }
                return setStatus3Command;

            }
        }
    }
}
