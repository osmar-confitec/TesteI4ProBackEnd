using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contatos.Notificacoes
{
    public static class ValidacaoGenerica
    {
        public static IRuleBuilderOptions<T, IList<TElement>> ListMustContainFewerThan<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder, int num)
        {
            return ruleBuilder.Must(list => list.Count < num).WithMessage("The list contains too many items");
        }
    }
}
