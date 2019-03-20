using Contatos.Data.Context;
using Contatos.Dominio;
using Contatos.Dominio.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contatos.Data.Repository
{
    public class TelefoneRepository : RepositoryBase<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(Contexto dataContext) : base(dataContext)
        {
        }

        new public void Deletar(Telefone telefone)
        {
            var pessConsult = contexto.Telefones.FirstOrDefault(x => x.Id.ToString() == telefone.Id.ToString());
            pessConsult.Ativo = false;

            contexto.SaveChanges();
        }
    }
}
