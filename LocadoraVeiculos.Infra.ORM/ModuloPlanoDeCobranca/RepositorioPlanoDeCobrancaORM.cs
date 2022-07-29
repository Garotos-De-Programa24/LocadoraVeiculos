using LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ORM.ModuloPlanoDeCobranca
{
    public class RepositorioPlanoDeCobrancaORM : IRepositorioPlanoCobranca
    {
        private DbSet<PlanoCobranca> planoCobranca;
        private readonly LocadoraVeiculoDbContext dbContext;
    
        public RepositorioPlanoDeCobrancaORM(LocadoraVeiculoDbContext dbContext)
        {
            planoCobranca = dbContext.Set<PlanoCobranca>();
            this.dbContext = dbContext;
        }
        public void Inserir(PlanoCobranca novoRegistro)
        {
            planoCobranca.Add(novoRegistro);
        }
        public void Editar(PlanoCobranca registro)
        {
            planoCobranca.Update(registro);
        }
    
        public void Excluir(PlanoCobranca registro)
        {
            planoCobranca.Remove(registro);
        }
    
        public PlanoCobranca SelecionarPorId(Guid id)
        {
            return planoCobranca.SingleOrDefault(x => x.Id == id);
        }
    
        public PlanoCobranca SelecionarPlanoPorNome(string nome)
        {
            return planoCobranca.SingleOrDefault(x => x.NomePlano == nome);
        }
        public List<PlanoCobranca> SelecionarTodos()
        {
            return planoCobranca.Include(x => x.GrupoVeiculos).ToList();
        }
    }
}
