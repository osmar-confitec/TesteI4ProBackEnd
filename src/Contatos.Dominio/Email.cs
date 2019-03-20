using System;
using System.Collections.Generic;
using System.Text;

namespace Contatos.Dominio
{
   public class Email
    {
        public string EnderecoEmail { get;  set; }

        public Guid PessoaId { get;  set; }

        public Guid Id { get;  set; }

        public virtual Pessoa Pessoa { get;  set; }

        public bool Ativo { get; set; }

        public Email() {
            Id = Guid.NewGuid();
        }
    }
}
