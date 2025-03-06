using Microsoft.EntityFrameworkCore;
using SmartParkingLot.Api.Domain.Entities;
using SmartParkingLot.Api.Domain.Interfaces.Repo;
using SmartParkingLot.Api.Repository.EF;
using System.Linq.Expressions;

namespace SmartParkingLot.Api.Repository
{
    public class ParkingDeviceRepository(AppDbContext _context) : IRepository<Device>
    {
        private readonly char[] _separator = [','];

        public async Task<IEnumerable<Device>> Get(
            Expression<Func<Device, bool>>? filter = null, 
            Func<IQueryable<Device>,IOrderedQueryable<Device>>? orderBy = null, 
            Tuple<int, int>? offset = null, 
            string includeProperties = "")
        {
            var dbSet = _context.Set<Device>();

            IQueryable<Device> query = dbSet;

            query = includeProperties.Split(_separator, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            
            return await query.ToListAsync();
        }

        public async Task<Device?> GetById(object id)
        {
            var dbSet = _context.Set<Device>();
            
            return await dbSet.FindAsync(id); 
        }

        public async Task<Device> Insert(Device entity)
        {
            var dbSet = _context.Set<Device>();
            var newEntity = dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return newEntity.Entity;
        }

        public async Task Update(Device entity)
        {
            var dbSet = _context.Set<Device>();
            dbSet.Attach(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(object id)
        {
            var dbSet = _context.Set<Device>();
            var entityToDelete = dbSet.Find(id);
            if (entityToDelete == null) return;
            if (_context.Entry(entityToDelete).State == EntityState.Detached) dbSet.Attach(entityToDelete);
            dbSet.Remove(entityToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
