using shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shop.Repository;
using shop.Models;
using shop.Database;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace shop.unitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private AppConnection db = new AppConnection();
        private ManagerDBRepository<Cart> cartRepository;
        private ManagerDBRepository<Category> categoryRepository;
        private ManagerDBRepository<Order> orderRepository;
        private ManagerDBRepository<Product> productRepository;
        private ManagerDBRepository<Review> reviewRepository;
        private ManagerDBRepository<Users> userRepository;

        public ManagerDBRepository<Cart> CartRepository
        {
            get
            {
                if (cartRepository == null)
                    cartRepository = new ManagerDBRepository<Cart>(db);
                return cartRepository;
            }
        }

        public ManagerDBRepository<Category> CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new ManagerDBRepository<Category>(db);
                return categoryRepository;
            }
        }

        public ManagerDBRepository<Order> OrderRepository
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new ManagerDBRepository<Order>(db);
                return orderRepository;
            }
        }

        public ManagerDBRepository<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ManagerDBRepository<Product>(db);
                return productRepository;
            }
        }

        public ManagerDBRepository<Review> ReviewRepository
        {
            get
            {
                if (reviewRepository == null)
                    reviewRepository = new ManagerDBRepository<Review>(db);
                return reviewRepository;
            }
        }

        public ManagerDBRepository<Users> UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new ManagerDBRepository<Users>(db);
                return userRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
       
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
