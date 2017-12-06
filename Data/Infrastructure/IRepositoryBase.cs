﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



    public interface IRepositoryBase<T> where T:class
    {
        void Add(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T,bool>> where);
        void Update(T entity);
        T Get(Expression<Func<T, bool>> where);
        T GetById(long id);
        IEnumerable<T> getAll();
        T GetById(string id);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where=null, 
            Expression<Func<T, bool>> orderBy=null);
    Task<int> CountAsync();
    Task<List<object>> GetAllAsync();
    Task<TEntity> FindAsync<TEntity>(Expression<Func<TEntity, bool>> match) where TEntity : class;
    Task<List<TEntity>> FindAllAsync<TEntity>(Expression<Func<TEntity, bool>> match) where TEntity : class;
}

