using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data.Context;
using Models.Entities;

namespace Data.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet;
        private Guid userId;
        public GenericRepository(InvoiceDbContext context)
        {
            _dbSet = context.Set<T>();
        }


        public IQueryable<T> Select(string status = DeletedStatus.NotDeleted)
        {
            if (status == DeletedStatus.All)
            {
                return _dbSet.AsQueryable();
            }
            var isDeleted = status == DeletedStatus.Deleted;
            return _dbSet.AsQueryable().Where(m => m.IsDeleted == isDeleted);
        }
        public IQueryable<T> NoTrackingSelect(string status = DeletedStatus.NotDeleted)
        {
            if (status == DeletedStatus.All)
            {
                return _dbSet.AsNoTracking().AsQueryable();
            }
            var isDeleted = status == DeletedStatus.Deleted;
            return _dbSet.AsNoTracking().AsQueryable().Where(m => m.IsDeleted == isDeleted);
        }


        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default, string status = DeletedStatus.NotDeleted)
        {
            if (status == DeletedStatus.All)
            {
                return await _dbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            }
            var isDeleted = status == DeletedStatus.Deleted;
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == isDeleted, cancellationToken);
        }
        public async Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken = default,
            string status = DeletedStatus.NotDeleted)
        {
            return await GetByIdAsync(id, cancellationToken, status) != null;
        }
        public void Add(T obj)
        {
            obj.CreatedById = Guid.Empty;
            obj.CreatedAt = DateTime.Now;
            _dbSet.Add(obj);
        }

        public void AddRange(IEnumerable<T> objects)
        {
            var createdAt = DateTime.Now;

            foreach (var obj in objects)
            {
                obj.CreatedById = userId;
                obj.CreatedAt = createdAt;
            }
            _dbSet.AddRange(objects);
        }
        public void UpdateRange(IEnumerable<T> objects)
        {
            foreach (var obj in objects)
            {
                obj.UpdatedById = userId;
                obj.IsUpdated = true;
            }
        }
        public void DeleteRange(IEnumerable<T> objects)
        {
            var deletedAt = DateTime.Now;

            foreach (var obj in objects)
            {
                obj.IsDeleted = true;
                obj.DeletedAt = deletedAt;
                obj.DeletedById = userId;
            }
        }
        public void Update(T obj)
        {
            obj.UpdatedById = userId;
            obj.IsUpdated = true;
        }

        public void Delete(T obj)
        {
            obj.IsDeleted = true;
            obj.DeletedAt = DateTime.Now;
            obj.DeletedById = userId;
        }

    }
}
