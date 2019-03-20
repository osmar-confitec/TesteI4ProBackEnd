using Contatos.Notificacoes.App.Interface;
using Contatos.Notificacoes.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contatos.Notificacoes.App.Base
{
    public abstract class ConfigBase<T> : ValidadorBase<T>, IConfigBase<T> where T : class
    {
        bool disposed = false;

        public IReadOnlyList<Notificacao> NotificacoesBusca => Notificacoes;

        T Obj;


        protected ConfigBase(T _Obj)
        {
            Obj = _Obj;
            ObterObjValidacao(Obj);
        }

        protected override T SetarObjetoValidacao()
        {
            return Obj;
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

        public bool EValido() => Evalido;

        public void ObterModelo(T viewModel)
        {
            ObterObjValidacao(viewModel);
        }
    }
}
