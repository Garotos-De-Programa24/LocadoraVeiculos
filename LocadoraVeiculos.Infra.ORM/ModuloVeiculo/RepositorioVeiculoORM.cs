using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ORM.ModuloVeiculo
{
    public class RepositorioVeiculoORM : IRepositorioVeiculo
    {
        private DbSet<Veiculo> veiculo;
        private readonly LocadoraVeiculoDbContext dbContext;

        public RepositorioVeiculoORM(LocadoraVeiculoDbContext dbContext)
        {
            veiculo = dbContext.Set<Veiculo>();
            this.dbContext = dbContext;
        }
        public void Inserir(Veiculo novoRegistro)
        {
            veiculo.Add(novoRegistro);
        }
        public void Editar(Veiculo registro)
        {
            veiculo.Update(registro);
        }

        public void Excluir(Veiculo registro)
        {
            veiculo.Remove(registro);
        }

        public Veiculo SelecionarPorId(Guid id)
        {
            return veiculo.SingleOrDefault(x => x.Id == id);
        }

        public Veiculo SelecionarVeiculoPeloNome(string nome)
        {
            return veiculo.SingleOrDefault(x => x.VeiculoNome == nome);
        }
        public List<Veiculo> SelecionarTodos()
        {
            return veiculo.ToList();
        }
    }
}
