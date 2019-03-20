using Contatos.Notificacoes.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contatos.App
{
    public abstract class AplicacaoBase : IAplicacaoBase
    {
        bool disposed = false;

        public List<Notificacao> Notificacoes { get; set; }

        protected AplicacaoBase()
        {
            Notificacoes = new List<Notificacao>();
        }

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
    }
}
