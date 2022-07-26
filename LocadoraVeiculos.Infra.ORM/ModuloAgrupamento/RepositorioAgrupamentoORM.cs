using System;
using System.Collections.Generic;
using System.Linq;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculos.Infra.ORM.ModuloAgrupamento
{
    public class RepositorioAgrupamentoORM : IRepositorioAgrupamento
    {
        private DbSet<Agrupamento> agrupamentos;
        private readonly LocadoraVeiculoDbContext dbContext;

        public RepositorioAgrupamentoORM(LocadoraVeiculoDbContext dbContext)
        {
            agrupamentos = dbContext.Set<Agrupamento>();
            this.dbContext = dbContext;
        }
        public void Inserir(Agrupamento novoRegistro)
        {
            agrupamentos.Add(novoRegistro);
        }
        public void Editar(Agrupamento registro)
        {
            agrupamentos.Update(registro);
        }

        public void Excluir(Agrupamento registro)
        {
            agrupamentos.Remove(registro);
        }

        public Agrupamento SelecionarPorId(Guid id)
        {
            return agrupamentos.SingleOrDefault(x => x.Id == id);
        }

        public Agrupamento SelecionarAgrupamentoPorNome(string nome)
        {
            return agrupamentos.SingleOrDefault(x => x.Nome == nome);
        }
        public List<Agrupamento> SelecionarTodos()
        {
            return agrupamentos.ToList();
        }
    }
}
