using System;
using System.Linq.Expressions;
using Food.Core.Base;
using Microsoft.EntityFrameworkCore;

namespace Food.Infrastructure;

public class Repository<T> : IRepository<T> where T : EntityBase
{
    private readonly FoodDbContext _dbContext;

    public Repository(FoodDbContext context)
    {
        _dbContext = context;
    }

    public void Add(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        _dbContext.SaveChanges();
    }

    public void Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        _dbContext.SaveChanges();
    }

    public T GetById(int id)
    {
        return _dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<T> GetAll()
    {
        return _dbContext.Set<T>().AsEnumerable();
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
    {
        return _dbContext.Set<T>().Where(predicate).AsEnumerable();
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, int offset, int size)
    {
        return _dbContext.Set<T>().Where(predicate)
            .OrderByDescending(x => x.Id)
            .Skip(offset)
            .Take(size).AsEnumerable();
    }

    public int Count()
    {
        return _dbContext.Set<T>().Count();
    }

    public int Count(Expression<Func<T, bool>> predicate)
    {
        return _dbContext.Set<T>().Where(predicate).Count();
    }
}
