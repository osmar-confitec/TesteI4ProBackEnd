using Contatos.Data.Context;
using Contatos.Dominio.Repository;
using Contatos.Notificacoes.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contatos.Data.Repository
{
   public abstract class RepositoryBase<T> : IDisposable, IRepositorioBase<T> where T : class
    {


        public List<Notificacao> Notificacoes { get; set; }

        protected readonly Contexto contexto;

        protected RepositoryBase(Contexto dataContext)
        {
            contexto = dataContext;
            Notificacoes = new List<Notificacao>();


        }

        bool disposed = false;

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

        public async Task<T> Inserir(T item)
        {
            Adicionar(item);
            await contexto.SaveChangesAsync();
            return item;
        }
        public async Task<IEnumerable<T>> ObterItens(Expression<Func<T, bool>> consulta)
        {
            return await contexto.Set<T>().Where(consulta).AsNoTracking().ToListAsync();
        }

        public async Task<T> ObterUmItem(Expression<Func<T, bool>> consulta)
        {
            return await contexto.Set<T>().AsNoTracking().FirstOrDefaultAsync(consulta);
        }

        public async Task<bool> ExisteInformacao(Expression<Func<T, bool>> consulta)
        {
            return await contexto.Set<T>().AnyAsync(consulta);
        }

        public async Task<IEnumerable<T>> ObterTodos()
        {
            return await contexto.Set<T>().AsNoTracking().ToListAsync();
        }

        public void Deletar(T item)
        {
            contexto.Remove(item);
        }

        public async Task<bool> SalvarTodos()
        {
            return await contexto.SaveChangesAsync() > 0;
        }

        

        public void Adicionar(T item)
        {
            contexto.Add(item);
        }

        public void Atualizar(T item)
        {
            contexto.Set<T>().Update(item);
        }
    }
}
