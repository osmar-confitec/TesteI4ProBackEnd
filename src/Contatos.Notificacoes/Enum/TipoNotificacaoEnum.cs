using System.ComponentModel;

namespace Contatos.Notificacoes.Enum
{
    public enum TipoNotificacaoEnum
    {

        [Description("CPF já existe")]
        CPFEncontrado = 1,
        [Description("Nome Cliente Não Informado")]
        NomeClienteNaoInformado  = 2

    }
}
