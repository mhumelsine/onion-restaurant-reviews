using Isf.XC;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Core.Stores
{
    public interface IStore<T>
    {
        void Add(T entity);
        void Update(T entity);
        T Find(string id);
        void Delete(string id);
        CommandResult CommitChanges();
    }
}
