
using Microsoft.EntityFrameworkCore;
using SmartParkingLot.Api.Domain.Entities;
using SmartParkingLot.Api.Domain.Interfaces.Repo;
using System.Linq.Expressions;


namespace SmartParkingLot.Test.Mocks;

public class MockSpotRepository(DbContext _context) : IRepository<Spot>
{
    private readonly char[] _separator = [','];
    public async Task<IEnumerable<Spot>> Get(
        Expression<Func<Spot, bool>>? filter = null, 
        Func<IQueryable<Spot>, IOrderedQueryable<Spot>>? orderBy = null, 
        Tuple<int, int>? offset = null, 
        string includeProperties = "")
    {
        var dbSet = _context.Set<Spot>();

        IQueryable<Spot> query = dbSet;

        if (filter != null) query = query.Where(filter);

        query = includeProperties.Split(_separator, StringSplitOptions.RemoveEmptyEntries)
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        if (orderBy != null)
        {
            query = orderBy(query);
        }
        if (offset != null)
        {
            query = query.Skip((offset.Item1 - 1) * offset.Item2).Take(offset.Item2);
        }
        return await query.ToListAsync();
    }

    public async Task<Spot?> GetById(object id)
    {
        var dbSet = _context.Set<Spot>();
        return await dbSet.FindAsync(id);
    }

    public async Task<Spot> Insert(Spot entity)
    {
        var dbSet = _context.Set<Spot>();
        var newEntity = dbSet.Add(entity);
        await _context.SaveChangesAsync();
        return newEntity.Entity;

    }

    public async Task Update(Spot entity)
    {
        var dbSet = _context.Set<Spot>();
        dbSet.Attach(entity);
        await _context.SaveChangesAsync();
    }
    public async Task Delete(object id)
    {
        var dbSet = _context.Set<Spot>();
        var entityToDelete = dbSet.Find(id);
        if (entityToDelete == null) return;
        if (_context.Entry(entityToDelete).State == EntityState.Detached) dbSet.Attach(entityToDelete);
        dbSet.Remove(entityToDelete);
        await _context.SaveChangesAsync();
    }
}
