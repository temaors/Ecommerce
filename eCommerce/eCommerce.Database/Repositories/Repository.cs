using eCommerce.Extensions.ExceptionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace eCommerce.Database.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _set;

        protected Repository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _set = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _set.AsTracking();
        }

        public async Task<TEntity?> FindBy(Func<TEntity, bool> predicate) => 
            await Task.Run(() => _set.AsNoTracking().FirstOrDefault(predicate));
        
        public virtual async Task<TEntity> GetById(int id)
        {
            if (id <= 0)
                throw ExceptionsFactory.InvArgException(
                    System.Reflection.MethodBase.GetCurrentMethod()?.Name,
                    @$"Id = {id} is invalid. Id cannot be less than 1");
            
            TEntity objectFromDb = await _set.FindAsync(id) ?? throw new InvalidOperationException();

            if (objectFromDb is null)
            {
                throw ExceptionsFactory.DbObjectIsNullException(
                    System.Reflection.MethodBase.GetCurrentMethod().Name,
                    @$"Object by id = {id} that you try to retrieve from 
                    {GetType().Name} repository is null");
            }
            return objectFromDb;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            EntityEntry<TEntity> create = await _set.AddAsync(entity);
            await _context.SaveChangesAsync();
            
            return create.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            EntityEntry<TEntity> update = _set.Update(entity);
            _context.SaveChanges();
            return update.Entity;
        }

        public virtual async Task Delete(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }
            TEntity entity = await _set.FindAsync(id) ?? throw new NullReferenceException("Could not found object");
            _set.Remove(entity);
            await _context.SaveChangesAsync();
        }

        protected DatabaseFacade GetDatabaseFacade()
        {
            return _context.Database;
        }
        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }