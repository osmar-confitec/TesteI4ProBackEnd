using Contatos.CrossCutting;
using Contatos.Notificacoes.App.Base;
using Contatos.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contatos.Notificacoes.App
{
    public class PessoaValid : ConfigBase<PessoaViewModel>
    {
        public PessoaValid(PessoaViewModel _Obj) : base(_Obj)
        {

        }

        protected override void Config()
        {
            RuleFor(x=>x.Email)
                .NotEmpty().WithMessage("Atenção! Email Requerido!")
                     .EmailAddress().WithMessage("Atenção! Email Inválido");
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Atenção! Nome Requerido!");

            RuleFor(x=>x.Telefone).NotEmpty().WithMessage("Atenção! Telefone Requerido!")
                .Must(TelefoneValido)
                .WithMessage("Atenção! Telefone Inválido!")
                ;

        }

        private bool TelefoneValido(string arg)
        {
            return MetodosComuns.SomenteNumeros(arg).Length > 0;
        }
    }
}
