using Contatos.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contatos.App
{
   public interface IPessoaApp: IAplicacaoBase
    {

        Task<IEnumerable<PessoaConsultaViewModel>> ObterPessoas(PessoaConsultaViewModel pessoa);

        Task<PessoaViewModel> ObterPessoa(string Id);

        Task ExcluirPessoa(string Id);

        Task ExcluirTelefone(string Id);

        Task ExcluirMail(string Id);

        Task<PessoaViewModel> AtualizarPessoa(PessoaViewModel pessoa);

        Task<TelefoneViewModel> AtualizarTelefone(TelefoneViewModel telefoneView);

        Task<EmailViewModel> AtualizarEmail(EmailViewModel emailViewModel);

        Task<TelefoneViewModel> IncluirTelefone(TelefoneViewModel telefoneView);

        Task<EmailViewModel> IncluirEmail(EmailViewModel telefoneView);

        Task<PessoaViewModel> IncluirPessoa(PessoaViewModel  pessoa);

    }
}
