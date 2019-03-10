using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Yield.Core.Entities.Interfaces;

namespace Yield.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(string partitionId, string id);

        Task<IEnumerable<T>> GetItems(int maxCount = 200, int page = 0);

        Task<IEnumerable<T>> GetItems(Expression<Func<T, bool>> predicate, bool crossPartitionQuery, int maxCount = 200, int page = 0);

        Task<T> Create(IEntity item);

        Task<T> Update(string id, T item);

        Task Delete(string id);
    }
}