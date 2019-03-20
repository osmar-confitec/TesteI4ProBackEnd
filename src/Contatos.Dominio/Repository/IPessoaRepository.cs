using Contatos.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contatos.Dominio.Repository
{
   public interface IPessoaRepository: IRepositorioBase<Pessoa>
    {
        Task<IEnumerable<PessoaConsultaViewModel>> ObterPessoas(PessoaConsultaViewModel pessoa);

        Task<PessoaViewModel> ObterPessoaDetalhe(Guid guid);
    }
}
