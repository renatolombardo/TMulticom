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
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual void Adicionar(T entity)
        {
            _dbSet.Add(entity);
            Salvar();
            
        }

        public virtual void Atualizar(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            Salvar();
        }

        public virtual T ObterPorId(Guid id)
        {
            return _dbSet.Find(id) ;
        }

        public virtual IEnumerable<T> ObterTodos()
        {
            return _dbSet;
        }

        public virtual void Remover(T entity)
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
