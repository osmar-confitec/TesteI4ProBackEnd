using Contatos.Notificacoes.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contatos.Notificacoes.App.Interface
{
    public interface IConfigBase<T> : IDisposable where T : class
    {
        bool EValido();

        void ObterModelo(T viewModel);

        IReadOnlyList<Notificacao> NotificacoesBusca { get; }
    }
}
