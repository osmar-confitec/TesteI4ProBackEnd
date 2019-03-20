using Contatos.Data.Context;
using Contatos.Dominio;
using Contatos.Dominio.Repository;
using Contatos.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contatos.Data.Repository
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(Contexto dataContext)
            : base(dataContext)
        {

        }

        new public void Atualizar(Pessoa pessoa)
        {
            contexto.Update(pessoa);

            foreach (var item in pessoa.Emails)
            {
                if (item.Id == Guid.Empty)
                    contexto.Entry(item).State = EntityState.Added;
            }

            foreach (var item in pessoa.Telefones)
            {
                if (item.Id == Guid.Empty)
                    contexto.Entry(item).State = EntityState.Added;
            }
            contexto.SaveChanges();
        }


        new public void Deletar(Pessoa pessoa)
        {
            var pessConsult = contexto.Pessoas.FirstOrDefault(x=>x.Id.ToString() == pessoa.Id.ToString());
            pessConsult.Ativo = false;
            
            contexto.SaveChanges();
        }

        public async Task<PessoaViewModel> ObterPessoaDetalhe(Guid guid)
        {
            var person =  await contexto.Pessoas.FirstOrDefaultAsync(x => x.Id.ToString() == guid.ToString() && x.Ativo);
            var EmailsConsult = await contexto.Emails.Where(x => x.PessoaId.ToString() == guid.ToString() && x.Ativo).ToListAsync();
            var TelefonesConsult = await contexto.Telefones.Where(x => x.PessoaId.ToString() == guid.ToString() && x.Ativo).ToListAsync();
            var pes =  new PessoaViewModel {
                Id = person.Id.ToString(),
                Email = person.Email,
                Nome = person.Nome,
                Telefone = person.Telefone,
                Telefones   = TelefonesConsult.Any() ? TelefonesConsult.Select(x => new TelefoneViewModel { NumeroTelefone = x.NumeroTelefone, Id = x.Id.ToString(), Ativo = x.Ativo }) : new List<TelefoneViewModel>(),
                Emails      = EmailsConsult.Any() ? EmailsConsult.Select(x => new EmailViewModel { EnderecoEmail = x.EnderecoEmail, Id = x.Id.ToString(), Ativo = x.Ativo }) : new List<EmailViewModel>() 
            };
           
            return pes;
        }

        public async Task<IEnumerable<PessoaConsultaViewModel>> ObterPessoas(PessoaConsultaViewModel pessoa)
        {
            IQueryable<Pessoa> pessoaConsulta = contexto.Pessoas;

            if (!string.IsNullOrEmpty(pessoa.Nome))
                pessoaConsulta = pessoaConsulta.Where(x => x.Nome.Contains(pessoa.Nome));

            pessoaConsulta = pessoaConsulta.Where(x => x.Ativo);



            var lista = await pessoaConsulta.AsNoTracking().ToListAsync();

            



            return lista.Select(x => new PessoaConsultaViewModel
            {
                Nome = x.Nome,
                Email = x.Email,
                Id = new System.Guid(x.Id.ToString()),
                Telefone = x.Telefone
            }).ToList();
        }
    }
}
