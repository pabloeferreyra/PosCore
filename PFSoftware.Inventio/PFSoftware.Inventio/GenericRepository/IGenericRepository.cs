﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PFSoftware.Inventio.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        void Create(T t);

        void Update(T t);

        void Remove(T t);

        List<T> FindAll();

        List<T> FindBy(Expression<Func<T, bool>> predicate);

        T FindSingle(Expression<Func<T, bool>> predicate);
    }
}
