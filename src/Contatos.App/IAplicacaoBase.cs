using Contatos.Notificacoes.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contatos.App
{
   public interface IAplicacaoBase : IDisposable
    {
        List<Notificacao> Notificacoes { get; set; }
    }
}
