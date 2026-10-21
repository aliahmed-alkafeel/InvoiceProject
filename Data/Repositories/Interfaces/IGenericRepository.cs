using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Models.Entities;

namespace Data.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> Select(string status = DeletedStatus.NotDeleted);
        IQueryable<T> NoTrackingSelect(string status = DeletedStatus.NotDeleted);
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default, string status = DeletedStatus.NotDeleted);
        Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken = default, string status = DeletedStatus.NotDeleted);
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
        void AddRange(IEnumerable<T> objects);
        void UpdateRange(IEnumerable<T> objects);
        void DeleteRange(IEnumerable<T> objects);
    }
    public static class DeletedStatus
    {
        public const string All = "All";
        public const string Deleted = "Deleted";
        public const string NotDeleted = "NotDeleted";
    }
}
