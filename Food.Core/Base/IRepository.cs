using System;
using System.Linq.Expressions;

namespace Food.Core.Base;

public interface IRepository<T> where T : EntityBase
{
    public T GetById(int id);
    public IEnumerable<T> GetAll();
    public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
    public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, int offset, int size);

    public int Count();
    public int Count(Expression<Func<T, bool>> predicate);

    public void Add(T entity);
    public void Update(T entity);
    public void Delete(T entity);
}
