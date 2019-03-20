using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contatos.Dominio.Services
{
    public interface IPessoaService: IServiceBase<Pessoa>
    {
        void ExcluirMail(string Id);
        void ExcluirTelefone(string Id);
    }
}
