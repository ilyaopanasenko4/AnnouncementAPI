using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace AnnouncementApp.DAL.Interfaces
{
    /// <summary>
    /// repository for working with the model
    /// </summary>
    /// <typeparam name="T">data type class</typeparam>
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task Create(T item);
        void Update(T item);
        void Delete(T item);
        Task<bool> Exist(T item);
    }
}
