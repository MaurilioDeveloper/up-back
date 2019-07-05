using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Positivo.AtividadesComplementares.Infrastructure.IRepositoy
{
    public interface IRepository<T, Key> : IDisposable where T : class
    {
        List<T> List(Func<T, bool> filter);
        int Count(Func<T, bool> include = null);
        T Find(Key key);
        Task<T> FindAsync(Key key);
        void UpdateAsync(T entity);
        void Insert(T entity);
        IEnumerable<T> UpdateRange(IEnumerable<T> entities);
        T Update(Key key, T entity);
        T Delete(Key key);
        void Delete(T entity);
        void Clean();
    }
}