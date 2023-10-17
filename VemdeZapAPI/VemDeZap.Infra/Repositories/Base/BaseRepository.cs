using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VemdeZap.Domain.Entities;
using VemdeZap.Domain.Interfaces.Repositories.Base;

namespace VemDeZap.Infra.Repositories.Base
{
    public class BaseRepository<TEntity, TId> : IRepositoryBase<TEntity, TId>
        where TEntity : BaseEntity
        where TId : struct
    {
        private readonly DbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> ListarPor(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Listar(includeProperties).Where(where);
        }

        public IQueryable<TEntity> ListarEOrdenadosPor<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return ascendente ? ListarPor(where, includeProperties).OrderBy(ordem) : ListarPor(where, includeProperties).OrderByDescending(ordem);
        }

        public TEntity ObterPor(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Listar(includeProperties).FirstOrDefault(where);
        }

        public TEntity ObterPorId(TId id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            if (includeProperties.Any())
            {
                return Listar(includeProperties).FirstOrDefault(x => x.Id.ToString() == id.ToString());
            }

            return _context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> Listar(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (includeProperties.Any())
            {
                return Include(_context.Set<TEntity>(), includeProperties);
            }

            return query;
        }

        public IQueryable<TEntity> ListarOrdenadosPor<TKey>(Expression<Func<TEntity, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return ascendente ? Listar(includeProperties).OrderBy(ordem) : Listar(includeProperties).OrderByDescending(ordem);
        }

        public TEntity Adicionar(TEntity entidade)
        {
            var entity = _context.Add<TEntity>(entidade);
            return entity.Entity;
            //return _context.Set<TEntidade>().Add(entidade);
        }

        public TEntity Editar(TEntity entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;

            return entidade;
        }

        public void Remover(TEntity entidade)
        {
            _context.Set<TEntity>().Remove(entidade);
        }

        public void Remover(IEnumerable<TEntity> entidades)
        {
            _context.Set<TEntity>().RemoveRange(entidades);
        }

        /// <summary>
        /// Adicionar um coleção de entidades ao contexto do entity framework
        /// </summary>
        /// <param name="entidades">Lista de entidades que deverão ser persistidas</param>
        /// <returns></returns>
        public void AdicionarLista(IEnumerable<TEntity> entidades)
        {
            _context.AddRange(entidades);
            //return _context.Set<TEntidade>().AddRange(entidades);
        }

        /// <summary>
        /// Verifica se existe algum objeto com a condição informada
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool Existe(Func<TEntity, bool> where)
        {
            return _context.Set<TEntity>().Any(where);
        }

        /// <summary>
        /// Realiza include populando o objeto passado por parametro
        /// </summary>
        /// <param name="query">Informe o objeto do tipo IQuerable</param>
        /// <param name="includeProperties">Ínforme o array de expressões que deseja incluir</param>
        /// <returns></returns>
        private IQueryable<TEntity> Include(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            return query;
        }


    }
}
