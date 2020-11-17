using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DAL.IRepositories
{
    public abstract class BaseRepository<T> where T: class
    {
        private readonly DbSet<T> _table = null;
        private readonly AppDBContext _context = null;

        public BaseRepository(AppDBContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        // **************** list of GET METHODS *************************//
        public async Task<T> GetOne() 
        {
            return await _table.FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }


        // **************** list of INSERT METHODS *************************//
        public async Task AddRange(List<T> objList)
        {
            await _table.AddRangeAsync(objList);
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(T obj)
        {
            await _table.AddAsync(obj);
            _context.Entry<T>(obj).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        // **************** list of update METHODS *************************//
        public async Task UpdateAsync(T obj)
        {
            _table.Attach(obj);
            _context.Entry<T>(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // **************** list of delete METHODS *************************//

        public async Task Delete(T deleteObj)
        {
            _table.Remove(deleteObj);
            _context.Entry<T>(deleteObj).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

    }
}
