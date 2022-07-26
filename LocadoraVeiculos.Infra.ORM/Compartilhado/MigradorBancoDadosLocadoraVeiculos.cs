using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ORM.Compartilhado
{
    public class MigratorBancoDadosLocadoraVeiculos
    {
        public static void AtualizarBancoDados()
        {
            var configuracao = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("ConfiguracaoAplicacaoORM.json")
              .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var db = new LocadoraVeiculoDbContext(connectionString);

            var migracoesPendentes = db.Database.GetPendingMigrations();

            if (migracoesPendentes.Count() > 0)
                db.Database.Migrate();
        }
    }
}
