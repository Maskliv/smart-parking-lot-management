using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SmartParkingLot.Api.Domain.Interfaces.Repo;

public interface IRepository<T>
{
    public Task<IEnumerable<T>> Get(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Tuple<int, int>? offset = null,
        string includeProperties = ""
    );

    public Task<T?> GetById(object id);
    

    public Task<T> Insert(T entity);
    public Task Update(T entity);
    public Task Delete(object id);
}
