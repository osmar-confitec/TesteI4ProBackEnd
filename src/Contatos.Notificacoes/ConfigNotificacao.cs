using Contatos.Notificacoes.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contatos.Notificacoes
{
    public class ConfigNotificacao
    {
        public ConfigNotificacao(Notificacao notificacao)
        {

            Notificacao = notificacao;
        }

        public Notificacao Notificacao { get; private set; }
    }
}
