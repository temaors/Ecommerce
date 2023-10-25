using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace eCommerce.Database.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _set;

        protected Repository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _set = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _set.AsNoTracking();
        }

        public async Task<TEntity?> FindBy(Func<TEntity, bool> predicate) => 
            await Task.Run(() => _set.FirstOrDefault(predicate));
        
        public async Task<TEntity> GetById(int id)
        {
            if (id <= 0)
            {
                // throw ExceptionsFactory.InvArgException(
                //     System.Reflection.MethodBase.GetCurrentMethod().Name,
                //     @$"Id = {id} is invalid. Id cannot be less than 1");
            }
            
            TEntity objectFromDB = await _set.FindAsync(id);

            if (objectFromDB is null)
            {

                // throw ExceptionsFactory.DbObjectIsNullException(
                //     System.Reflection.MethodBase.GetCurrentMethod().Name,
                //     @$"Object by id = {id} that you try to retrieve from 
                //     {GetType().Name} repository is null"
                //     );
            }
            return objectFromDB;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            EntityEntry<TEntity> create = await _set.AddAsync(entity);
            return create.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            EntityEntry<TEntity> update = _set.Update(entity);
            return update.Entity;
        }

        public virtual async Task Delete(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }
            TEntity entity = await _set.FindAsync(id);
            if (entity != null) _set.Remove(entity);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
        
        protected DatabaseFacade GetDatabaseFacade()
        {
            return _context.Database;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }