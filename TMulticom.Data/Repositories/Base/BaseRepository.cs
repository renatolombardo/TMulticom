using IdentityModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMulticom.Domain.Models;

namespace TMulticom.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> AdicionarAsync(TEntity entity)
        {
            var r = await _dbSet.AddAsync(entity);
            await CommitAsync();
            return r.Entity;
        }

        public virtual async Task AtualizarAsync(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await CommitAsync();
        }

        public async Task<TEntity> ObterPorIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ObterTodosAsync()
        {
            return await Task.FromResult(_dbSet);
        }

        public Task RemoverAsync(TEntity entity)
        {
;           _dbSet.Remove(entity);
            return CommitAsync();
        }

        private async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        
    }
}
