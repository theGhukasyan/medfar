using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MedfarTest.Data;
using Microsoft.EntityFrameworkCore;

namespace MedfarTest.Repositories.Common;

public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly MedfarTestDbContext DbContext;
    protected readonly DbSet<T> EntitySet;

    internal GenericRepository(MedfarTestDbContext dbContext)
    {
        DbContext = dbContext;
        EntitySet = DbContext.Set<T>();
    }

    public void Add(T entity)
        => EntitySet.Add(entity);

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        => await EntitySet.AddAsync(entity, cancellationToken);

    public void AddAndSave(T entity)
    {
        Add(entity);
        DbContext.SaveChanges();
    }
    
    public void AddRange(IEnumerable<T> entities)
        => EntitySet.AddRange(entities);

    public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        => await EntitySet.AddRangeAsync(entities, cancellationToken);

    public T? Get(Expression<Func<T, bool>> expression)
        => EntitySet.FirstOrDefault(expression);

    public IEnumerable<T> GetAll()
        => EntitySet.AsEnumerable();

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
        => EntitySet.Where(expression).AsEnumerable();

    public IEnumerable<T> GetAll(int skip, int take)
        => EntitySet.Skip(skip).Take(take).AsEnumerable();

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        => await EntitySet.ToListAsync(cancellationToken);

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        => await EntitySet.Where(expression).ToListAsync(cancellationToken);

    public async Task<IEnumerable<T>> GetAllAsync(int skip, int take, CancellationToken cancellationToken = default)
        => await EntitySet.Skip(skip).Take(take).ToListAsync(cancellationToken);

    public async Task<T?> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        => await EntitySet.FirstOrDefaultAsync(expression, cancellationToken);

    public void Remove(T entity)
        => EntitySet.Remove(entity);

    public void RemoveAndSave(T entity)
    {
        Remove(entity);
        DbContext.SaveChanges();
    }

    public void RemoveRange(IEnumerable<T> entities)
        => EntitySet.RemoveRange(entities);

    public void Update(T entity)
        => EntitySet.Update(entity);

    public void UpdateRange(IEnumerable<T> entities)
        => EntitySet.UpdateRange(entities);

    public int Count()
        => EntitySet.Count();

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        => await EntitySet.AnyAsync(expression, cancellationToken);

    public IQueryable<T> GetAllAsQueryable() => EntitySet.AsQueryable();
}