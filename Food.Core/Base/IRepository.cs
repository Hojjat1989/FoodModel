using System.Linq.Expressions;

namespace Food.Core.Base;

public interface IRepository<T> where T : EntityBase
{
    T GetById(int id);
    IEnumerable<T> GetAll();
    IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
    IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, int offset, int size);

    int Count();
    int Count(Expression<Func<T, bool>> predicate);

    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    void SaveChanges();
}
