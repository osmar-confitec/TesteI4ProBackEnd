using Contatos.App;
using Contatos.Data.Context;
using Contatos.Data.Repository;
using Contatos.Dominio.Repository;
using Contatos.Dominio.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contatos.IoC
{
   public class Bootstrap
    {

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IPessoaApp, PessoaApp>();

            services.AddScoped<ITelefoneRepository, TelefoneRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();


            services.AddScoped<Contexto>();


        }
    }
}
