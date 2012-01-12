using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Plantae.Core.Repositories
{
    public interface IRepository<T> where T : IOwnable
    {
        IEnumerable<T> GetAll(string owner);

        IEnumerable<T> FindAll(Func<T, bool> exp, string owner);

        T FindSingle(Func<T, bool> exp, string owner);

        T FindFirst(Func<T, bool> exp, string owner);

        T FindById(long id, string owner);

        void InsertOnSubmit(T entity);

        void DeleteOnSubmit(T entity);

        void Save();
    }
}
