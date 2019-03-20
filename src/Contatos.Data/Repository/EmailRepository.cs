using Contatos.Data.Context;
using Contatos.Dominio;
using Contatos.Dominio.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contatos.Data.Repository
{
    public class EmailRepository : RepositoryBase<Email>, IEmailRepository
    {
        public EmailRepository(Contexto dataContext) : base(dataContext)
        {

      
        }

        new public void Deletar(Email email)
        {
            var pessConsult = contexto.Emails.FirstOrDefault(x => x.Id.ToString() == email.Id.ToString());
            pessConsult.Ativo = false;

            contexto.SaveChanges();
        }
    }
}
