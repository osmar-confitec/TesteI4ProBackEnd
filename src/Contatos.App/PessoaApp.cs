using Contatos.Dominio;
using Contatos.Dominio.Repository;
using Contatos.Dominio.Services;
using Contatos.Notificacoes.App;
using Contatos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contatos.App
{
    public class PessoaApp : AplicacaoBase, IPessoaApp
    {
        protected readonly IPessoaService _pessoaService;
        protected readonly IPessoaRepository _pessoaRepository;

        public PessoaApp(IPessoaRepository pessoaRepository, IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
            _pessoaRepository = pessoaRepository;

        }

        public Task<EmailViewModel> AtualizarEmail(EmailViewModel emailViewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<PessoaViewModel> AtualizarPessoa(PessoaViewModel pessoa)
        {
            return Task.Run(() =>
            {
                var pessoaPass = new Pessoa {
                    Id = new System.Guid(pessoa.Id),
                    Ativo = true,
                    Email = pessoa.Email,
                    Nome = pessoa.Nome,
                    Telefone = pessoa.Telefone,
                    Telefones = pessoa.Telefones.Any()  ? pessoa.Telefones.Select(x=> new Telefone { Id = string.IsNullOrEmpty(x.Id) ? Guid.Empty : new System.Guid(x.Id), Ativo = x.Ativo , NumeroTelefone = x.NumeroTelefone  }).ToList() : new List<Telefone>(),
                    Emails = pessoa.Emails.Any() ? pessoa.Emails.Select(x => new Email { Id = string.IsNullOrEmpty(x.Id) ? Guid.Empty : new System.Guid(x.Id), Ativo = x.Ativo, EnderecoEmail = x.EnderecoEmail }).ToList() : new List<Email>()
                };
                _pessoaService.Atualizar(pessoaPass);

                return new PessoaViewModel { };
            });
        }

        public Task<TelefoneViewModel> AtualizarTelefone(TelefoneViewModel telefoneView)
        {
            throw new System.NotImplementedException();
        }

        public Task ExcluirMail(string Id)
        {
            return Task.Run(() =>
            {
                _pessoaService.ExcluirMail(Id);
            });
        }

        public  Task ExcluirPessoa(string Id)
        {
            return Task.Run(() =>
            {
                _pessoaService.Deletar(new Pessoa { Id = new System.Guid(Id) });
            });
            
        }

        public Task ExcluirTelefone(string Id)
        {
            return Task.Run(() =>
            {
                _pessoaService.ExcluirTelefone(Id);
            });
        }

        public Task<EmailViewModel> IncluirEmail(EmailViewModel telefoneView)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PessoaViewModel> IncluirPessoa(PessoaViewModel pessoa)
        {

            var cliVal = new PessoaValid(pessoa);
            if (!cliVal.Evalido)
            {
                Notificacoes.AddRange(cliVal.Notificacoes);
                return null;
            }

            var pessoaAdd = new Pessoa
            {
                Ativo = true,
                Email = pessoa.Email,
                Nome = pessoa.Nome,
                Telefone = pessoa.Telefone,
            };

            if (pessoa.Emails.Any())
            {
                pessoaAdd.Emails = pessoa.Emails.Select(x => new Email
                {
                    Ativo = true,
                    Id = Guid.NewGuid(),
                    EnderecoEmail = x.EnderecoEmail

                }).ToList();
            }

            if (pessoa.Telefones.Any())
            {
                pessoaAdd.Telefones = pessoa.Telefones.Select(x => new Telefone {
                    Ativo = true,
                    Id = Guid.NewGuid(),
                    NumeroTelefone = x.NumeroTelefone
                }).ToList();
            }
            var pessAdded = await _pessoaService.Inserir(pessoaAdd);

            if (_pessoaService.Notificacoes.Any())
            {
                Notificacoes.AddRange(_pessoaService.Notificacoes);
                return null;
            }
            return new PessoaViewModel
            {
                Id = pessAdded.Id.ToString(),
                Email = pessAdded.Email,
                Nome = pessAdded.Nome,
                Telefone = pessAdded.Telefone,
                Telefones = pessAdded.Telefones.Any() ? pessAdded.Telefones.Select(x => new TelefoneViewModel { Id = x.Id.ToString(), NumeroTelefone = x.NumeroTelefone, Ativo = x.Ativo }) : new List<TelefoneViewModel>(),
                Emails = pessAdded.Emails.Any() ? pessAdded.Emails.Select(x => new EmailViewModel { Ativo = x.Ativo, EnderecoEmail = x.EnderecoEmail, Id = x.Id.ToString() }) : new List<EmailViewModel>()
            };
        }

        public Task<TelefoneViewModel> IncluirTelefone(TelefoneViewModel telefoneView)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PessoaViewModel> ObterPessoa(string Id)
        {
            return await _pessoaRepository.ObterPessoaDetalhe(new System.Guid(Id));
        }

        public async Task<IEnumerable<PessoaConsultaViewModel>> ObterPessoas(PessoaConsultaViewModel pessoa)
        {
            return await _pessoaRepository.ObterPessoas(pessoa);
        }
    }
}
