using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DemoTest.Domain.Repository.Interfaces
{
    /// <summary>
    /// Interface a ser utilizada pelos repositórios como base para persistência das informações
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Adiciona uma entidade ao contexto na memória
        /// </summary>
        /// <param name="entidade">Entidade a ser adicionada</param>
        /// <returns>TEntity</returns>
        TEntity Adicionar(TEntity entidade);
        /// <summary>
        /// Atualiza uma entidade ao contexto na memória
        /// </summary>
        /// <param name="entidade">Entidade a ser atualizada</param>
        /// <returns>TEntity</returns>
        TEntity Atualizar(TEntity entidade);
        /// <summary>
        /// Retorna uma ou mais entidades da memória de acordo com a expressão informada
        /// </summary>
        /// <param name="expression">Expressão Lambda</param>
        /// <returns>IEnumerable<TEntity></returns>
        IEnumerable<TEntity> RetornarQuando(Expression<Func<TEntity, bool>> expression);
        /// <summary>
        /// Retorna uma ou mais entidades da memória de acordo com a expressão informada
        /// </summary>
        /// <param name="expression">Expressão Lambda</param>
        /// <param name="semRastreio">Determina se haverá rastreio da entidade</param>
        /// <returns>IEnumerable<TEntity></returns>
        public IEnumerable<TEntity> RetornarQuando(Expression<Func<TEntity, bool>> expression, bool semRastreio = false);
        /// <summary>
        /// Retorna uma entidade TEntity de acordo com o id informado
        /// </summary>
        /// <param name="id">ID do Sku</param>
        /// <param name="semRastreio">Determina se haverá rastreio da entidade</param>
        /// <returns>TEntity</returns>
        TEntity RetornarPorID(long id, bool semRastreio = false);
        /// <summary>
        /// Remove uma entidade de acordo com seu ID
        /// </summary>
        /// <param name="id">ID da entidade</param>
        void Deletar(long id);       
        
        /// <summary>
        /// Salva as alterações do contexto na memória
        /// </summary>        
        int SaveChanges();
    }
}
