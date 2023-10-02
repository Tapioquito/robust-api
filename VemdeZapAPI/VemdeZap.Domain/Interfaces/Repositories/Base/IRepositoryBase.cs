using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VemdeZap.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity, TId>
        where TEntity : class
        where TId : struct
    {
        //Retorna um objeto de consulta
        IQueryable<TEntity> ListarPor(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> ListarEOrdenadosPor<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity ObterPor(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] includeProperties);

        bool Existe(Func<TEntity, bool> where);

        IQueryable<TEntity> Listar(params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> ListarOrdenadosPor<TKey>(Expression<Func<TEntity, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity ObterPorId(TId id, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity Adicionar(TEntity entidade);

        TEntity Editar(TEntity entidade);

        void Remover(TEntity entidade);

        void Remover(IEnumerable<TEntity> entidades);

        void AdicionarLista(IEnumerable<TEntity> entidades);
    }
}
