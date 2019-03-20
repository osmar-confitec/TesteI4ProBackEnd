using Contatos.Dominio.Repository;
using Contatos.Notificacoes.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contatos.Dominio.Services
{
    public class ServicoBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {

        private readonly IRepositorioBase<TEntity> repositorio;

        public ServicoBase(IRepositorioBase<TEntity> iRepositorio)
        {
            repositorio = iRepositorio;
            Notificacoes = new List<Notificacao>();
        }

        bool disposed = false;

        public List<Notificacao> Notificacoes { get; set; }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {

                // Free any other managed objects here.
                //
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Adicionar(TEntity item)
        {
            repositorio.Adicionar(item);
        }

        public void Atualizar(TEntity item)
        {
            repositorio.Atualizar(item);
        }

        public void Deletar(TEntity item)
        {
            repositorio.Deletar(item);
        }

        public async Task<bool> ExisteInformacao(Expression<Func<TEntity, bool>> consulta)
        {
          return await  repositorio.ExisteInformacao(consulta);
        }

        public async Task<TEntity> Inserir(TEntity item)
        {
                 return   await repositorio.Inserir(item);
        }

        public async Task<IEnumerable<TEntity>> ObterItens(Expression<Func<TEntity, bool>> consulta)
        {
            return await repositorio.ObterItens(consulta);
        }

        public async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await repositorio.ObterTodos();
        }

        public async Task<TEntity> ObterUmItem(Expression<Func<TEntity, bool>> consulta)
        {
            return await repositorio.ObterUmItem(consulta);
        }

        public async Task<bool> SalvarTodos()
        {
           return await repositorio.SalvarTodos();
        }
    }
}
