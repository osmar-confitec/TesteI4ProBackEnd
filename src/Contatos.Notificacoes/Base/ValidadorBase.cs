using Contatos.Notificacoes.Enum;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contatos.Notificacoes.Base
{
    public abstract class ValidadorBase<T> :
                              AbstractValidator<T> where T : class
    {

        public T ObjValidar { get; private set; }

        /// <summary>
        /// Adicione as configurações do sistema de validações especifica
        /// </summary>
        /// 

        protected void ObterObjValidacao(T Obj)
        {
            ObjValidar = Obj;
        }

        protected abstract T SetarObjetoValidacao();

        protected abstract void Config();

        public virtual bool Validar()
        {
            _Notificacoes.RemoveAll(x => !x.AdicionadoManualmente);

            var Result = Validate(ObjValidar);

            foreach (var failure in Result.Errors)
            {

                var config = ConfigNotificacaoes.FirstOrDefault(x => x.Key.Equals(failure.PropertyName));

                if (!config.Equals(default(KeyValuePair<string, ConfigNotificacao>)))
                {
                    AdicionarNotificacao(config.Value.Notificacao);
                    continue;
                }

                AdicionarNotificacao(new Erro(CriticidadeEnum.Media, null, failure.ErrorMessage, null, null));

            }
            _Evalido = Result.IsValid;
            _Evalido = !_Notificacoes.Any();
            return _Evalido;
        }

        List<Notificacao> _Notificacoes { get; set; }

        protected bool TemNotificacoes => _Notificacoes.Any();

        protected bool TemInformacoes => _Notificacoes.Any(x => x is Informacao);

        protected bool TemAlertas => _Notificacoes.Any(x => x is Alerta);

        protected bool TemErros => _Notificacoes.Any(x => x is Erro);

        protected int QtdAlertas => _Notificacoes.Count(x => x is Alerta);

        protected int QtdInformacoes => _Notificacoes.Count(x => x is Informacao);

        protected int QtdErros => _Notificacoes.Count(x => x is Erro);

        protected int QtdNotificacoes => _Notificacoes.Count();

        public IReadOnlyList<Notificacao> Notificacoes { get { return _Notificacoes.AsReadOnly(); } }

        IDictionary<string, ConfigNotificacao> ConfigNotificacaoes;

        void AdicionarNotificacao(Notificacao notificacao)
        {
            _Notificacoes.Add(notificacao);
        }


        public void AddNotificacao(Notificacao notificacao)
        {
            notificacao.SetarAdicionadoManualmente(true);
            _Notificacoes.Add(notificacao);
        }
        protected void AdicionarAtualizarConfigNotif(string _campo, ConfigNotificacao _config)
        {
            if (ConfigNotificacaoes.Any(x => x.Key.Equals(_campo)))
                ConfigNotificacaoes[_campo] = _config;

            ConfigNotificacaoes.Add(_campo, _config);
        }

        bool _Evalido;
        public bool Evalido { get { Validar(); return _Evalido; } private set { _Evalido = value; } }

        protected ValidadorBase()

        {

            ConfigNotificacaoes = new Dictionary<string, ConfigNotificacao>();

            _Notificacoes = new List<Notificacao>();
            Config();
            ObjValidar = SetarObjetoValidacao();

        }
        //public static class MyCustomValidators
        //{
        //    public static IRuleBuilderOptions<T, IList<TElement>> ListMustContainFewerThan<T, TElement>(IRuleBuilder<T, IList<TElement>> ruleBuilder, int num)
        //    {
        //        return ruleBuilder.Must(list => list.Count < num).WithMessage("The list contains too many items");
        //    }
        //}
    }
}
