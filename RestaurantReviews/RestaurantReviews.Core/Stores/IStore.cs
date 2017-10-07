using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Core.Stores
{
    public interface IStore<T>
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T> FindAsync(string id);
        Task DeleteAsync(string id);
    }
}
