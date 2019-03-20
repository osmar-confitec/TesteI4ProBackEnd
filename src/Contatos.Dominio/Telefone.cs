using System;
using System.Collections.Generic;
using System.Text;

namespace Contatos.Dominio
{
   public class Telefone
    {
        public Guid Id { get;  set; }

        public string NumeroTelefone { get;  set; }

        public Guid PessoaId { get;  set; }

        public virtual Pessoa Pessoa { get;  set; }

        public bool Ativo { get; set; }

        public Telefone() {
            Id = Guid.NewGuid();
        }

    }
}
