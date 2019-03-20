using System;
using System.Collections.Generic;
using System.Text;

namespace Contatos.ViewModel
{
  public  class PessoaViewModel
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Id { get; set; }

        public string Telefone { get; set; }

        public IEnumerable<TelefoneViewModel> Telefones { get; set; }

        public IEnumerable<EmailViewModel> Emails { get; set; }

        public PessoaViewModel()
        {
            Telefones = new List<TelefoneViewModel>();
            Emails = new List<EmailViewModel>();
        }
    }
}
