using Contatos.Notificacoes.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contatos.Notificacoes.Base
{
    public abstract class Notificacao
    {
        protected Notificacao(CriticidadeEnum criticidade, string propriedade, string mensagem, CamadaEnum? camada, TipoNotificacaoEnum? tiponotificacao)
        {
            Criticidade = criticidade;
            Propriedade = propriedade;
            Mensagem = mensagem;
            Camada = camada;
            TipoNotificacao = tiponotificacao;
            NotificacaoId = Guid.NewGuid();
        }

        protected CriticidadeEnum Criticidade { get; private set; }

        public string Propriedade { get; private set; }

        protected Guid NotificacaoId { get; }

        public bool AdicionadoManualmente { get; private set; }

        public void SetarAdicionadoManualmente(bool set)
        {
            AdicionadoManualmente = set;
        }


        public string Mensagem { get; private set; }

        protected CamadaEnum? Camada { get; private set; }

        protected TipoNotificacaoEnum? TipoNotificacao { get; private set; }

        public void SetTipoNotificacao(TipoNotificacaoEnum tipoNotificacao)
        {
            if (TipoNotificacao.HasValue && TipoNotificacao == tipoNotificacao)
                return;
            TipoNotificacao = tipoNotificacao;
        }

        public void SetMessage(string msg)
        {
            Mensagem = msg;
        }


        public void SetPropriedade(string msg)
        {
            Propriedade = msg;
        }


    }
}
