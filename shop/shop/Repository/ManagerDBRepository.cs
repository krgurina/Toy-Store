using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace shop.Repository
{
    public class ManagerDBRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        DbContext _context;
        DbSet<TEntity> _dbSet;

        public ManagerDBRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        // Возвращает все записи из таблицы БД, связанной с сущностью TEntity.
        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        // Возвращает записи из таблицы БД, связанной с сущностью TEntity, удовлетворяющие заданному условию (предикату).
        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        // Находит запись в таблице БД по ее Id.
        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        // Добавляет новую запись в таблицу БД, связанную с сущностью TEntity.
        public void Create(TEntity item)
        {
            _dbSet.Add(item);
        }
        // Обновляет данные существующей записи в таблице БД, связанной с сущностью TEntity.
        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        // Удаляет запись из таблицы БД, связанной с сущностью TEntity.
        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
        }

        // Возвращает все записи из таблицы БД, связанной с сущностью TEntity, включая связанные сущности (если указаны параметры includeProperties).
        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        // Возвращает записи из таблицы БД, связанной с сущностью TEntity, удовлетворяющие заданному условию (предикату), включая связанные сущности (если указаны параметры includeProperties).
        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        // Вспомогательный метод, используемый в методах GetWithInclude.
        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        // Удаляет несколько записей из таблицы БД, связанной с сущностью TEntity.
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
