﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Linq.Expressions;
using Plantae.Core.Exceptions;

namespace Plantae.Core.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IOwnable
    {
        private DataContext dataContext;

        public Repository(IContextFactory contextFactory) 
        {
            ContextFactory = contextFactory;
        }

        public IEnumerable<T> GetAll(string owner)
        {
            if (owner == null || owner.Trim() == "")
                throw new OwnerNotSpecifiedException();

            return Table.Where(t => t.Owner.Equals(owner));
        }

        public IEnumerable<T> FindAll(Func<T, bool> exp, string owner)
        {
            if (owner == null || owner.Trim() == "")
                throw new OwnerNotSpecifiedException();

            return Table.Where(T => T.Owner.Equals(owner)).Where(exp);
        }

        public T FindSingle(Func<T, bool> exp, string owner)
        {
            if (owner == null || owner.Trim() == "")
                throw new OwnerNotSpecifiedException();

            return Table.Where(T => T.Owner.Equals(owner)).Where(exp).SingleOrDefault<T>();
        }

        public T FindFirst(Func<T, bool> exp, string owner)
        {
            if (owner == null || owner.Trim() == "")
                throw new OwnerNotSpecifiedException();

            return Table.Where(T => T.Owner.Equals(owner)).Where(exp).FirstOrDefault<T>();
        }

        public virtual T FindById(long id, string owner)
        {
            throw new NotImplementedException();
        }

        public void InsertOnSubmit(T entity)
        {
            if (entity.Owner == null || entity.Owner.Trim().Equals(""))
                throw new OwnerNotSpecifiedException();

            Table.InsertOnSubmit(entity);
        }

        public void DeleteOnSubmit(T entity)
        {
            if (entity.Owner == null || entity.Owner.Trim().Equals(""))
                throw new OwnerNotSpecifiedException();

            Table.DeleteOnSubmit(entity);
        }

        public void Save()
        {
            Context.SubmitChanges();
        }

        protected IContextFactory ContextFactory { get; private set; }

        protected DataContext Context
        {
            get { return dataContext ?? (dataContext = ContextFactory.Get()); }
        }

        protected Table<T> Table { get { return Context.GetTable<T>(); } }
    }
}