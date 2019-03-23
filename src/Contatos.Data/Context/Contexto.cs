using Contatos.Data.Extensions;
using Contatos.Data.Mappings;
using Contatos.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Contatos.Data.Context
{
   public  class Contexto : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public IConfiguration Configuration { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.AddConfiguration(new PessoaMapping());
            modelBuilder.AddConfiguration(new TelefoneMapping());
            modelBuilder.AddConfiguration(new EmailMapping());
            base.OnModelCreating(modelBuilder);
        }

        public Contexto(IConfiguration _Configuration)
        {
            Configuration = _Configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
