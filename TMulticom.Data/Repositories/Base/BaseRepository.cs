using IdentityModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMulticom.Domain.Data;
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

        public virtual void Adicionar(TEntity entity)
        {
            _dbSet.Add(entity);
            Salvar();
            
        }

        public virtual void Atualizar(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            Salvar();
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return _dbSet.Find(id) ;
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return _dbSet;
        }

        public virtual void Remover(TEntity entity)
        {
            _dbSet.Remove(entity);
            Salvar();
        }

        public virtual void RemoverPorId(Guid id)
        {
            var item = _dbSet.Find(id);
            _dbSet.Remove(item);
            Salvar();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

    }
}
