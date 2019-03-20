using Contatos.Notificacoes.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contatos.Dominio.Services
{
   public interface IServiceBase<T> where T : class
    {
        void Deletar(T item);

        Task<bool> SalvarTodos();

        Task<T> Inserir(T item);

        void Adicionar(T item);

        void Atualizar(T item);

        List<Notificacao> Notificacoes { get; set; }

        Task<IEnumerable<T>> ObterItens(Expression<Func<T, bool>> consulta);

        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterUmItem(Expression<Func<T, bool>> consulta);

        Task<bool> ExisteInformacao(Expression<Func<T, bool>> consulta);
    }
}
