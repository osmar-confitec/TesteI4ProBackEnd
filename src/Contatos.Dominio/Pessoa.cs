using System;
using System.Collections.Generic;
using System.Text;

namespace Contatos.Dominio
{
   public class Pessoa
    {
        public string Nome { get;  set; }

        public Guid Id { get;  set; }

        public bool Preferencial { get; set; }

        public string Email { get;  set; }

        public string Telefone { get;  set; }

        public bool Ativo { get; set; }

        // EF Propriedade de Navegação
        public virtual ICollection<Email> Emails { get; set; }

        public virtual ICollection<Telefone> Telefones { get; set; }

        public Pessoa() {

            Emails = new List<Email>();
            Telefones = new List<Telefone>();
            Id = Guid.NewGuid();

        }

    }
}
