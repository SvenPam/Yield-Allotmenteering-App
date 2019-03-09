using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;

namespace Yield.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(string id, string partitionKey = null);

        Task<IEnumerable<T>> GetItems(int maxCount = 200, int page = 0);

        Task<IEnumerable<T>> GetItems(Expression<Func<T, bool>> predicate, bool crossPartitionQuery, int maxCount = 200, int page = 0);

        Task<Document> Create(T item);

        Task<Document> Update(string id, T item);

        Task Delete(string id);
    }
}