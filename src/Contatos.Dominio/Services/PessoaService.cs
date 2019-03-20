using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contatos.Dominio.Repository;
using Contatos.Notificacoes;

namespace Contatos.Dominio.Services
{
    public class PessoaService : ServicoBase<Pessoa>, IPessoaService
    {

        protected readonly IPessoaRepository _pessoaRepository;
        protected readonly IEmailRepository _emailRepository;
        protected readonly ITelefoneRepository _telefoneRepository;

        public PessoaService(
                            ITelefoneRepository telefoneRepository,
                            IEmailRepository  emailRepository,
                            IPessoaRepository pessoaRepository
            ) 
            : base(pessoaRepository)
        {

            _pessoaRepository = pessoaRepository;
            _emailRepository = emailRepository;
            _telefoneRepository = telefoneRepository;
        }


        new public async Task<Pessoa> Inserir(Pessoa item)
        {

            if (!item.Telefones.Any())
            {
                Notificacoes.Add(new Erro(
                        Contatos.Notificacoes.Enum.CriticidadeEnum.Media , 
                        "Telefones" ,
                        "Atenção deve haver ao menos um telefone!" ,
                        Contatos.Notificacoes.Enum.CamadaEnum.Dominio , null  ));
            }

            if (!item.Emails.Any())
            {
                Notificacoes.Add(new Erro(
                        Contatos.Notificacoes.Enum.CriticidadeEnum.Media,
                        "Emails",
                        "Atenção deve haver ao menos um email!",
                        Contatos.Notificacoes.Enum.CamadaEnum.Dominio, null));
            }

            if (Notificacoes.Any())
                return null;

            return await _pessoaRepository.Inserir(item);
        }


        public void ExcluirMail(string Id)
        {
            _emailRepository.Deletar(new Email { Id = new Guid(Id) });
        }

        public void ExcluirTelefone(string Id)
        {
            _telefoneRepository.Deletar(new Telefone { Id = new Guid(Id) });
        }
    }
}
