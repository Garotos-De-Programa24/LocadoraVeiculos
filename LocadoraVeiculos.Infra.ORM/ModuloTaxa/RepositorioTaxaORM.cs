using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Infra.ORM.ModuloCliente
{
    public class RepositorioTaxaORM : IRepositorioTaxa
    {
        private DbSet<Taxa> taxas;
        private readonly LocadoraVeiculoDbContext dbContext;

        public RepositorioTaxaORM(LocadoraVeiculoDbContext dbContext)
        {
            taxas = dbContext.Set<Taxa>();
            this.dbContext = dbContext;
        }
        public void Inserir(Taxa novoRegistro)
        {
            taxas.Add(novoRegistro);
        }
        public void Editar(Taxa registro)
        {
            taxas.Update(registro);
        }

        public void Excluir(Taxa registro)
        {
            taxas.Remove(registro);
        }

        public Taxa SelecionarPorId(Guid id)
        {
            return taxas.SingleOrDefault(x => x.Id == id);
        }

        public Taxa SelecionarTaxaPeloNome(string nome)
        {
            return taxas.SingleOrDefault(x => x.Equipamento == nome);
        }
        public List<Taxa> SelecionarTodos()
        {
            return taxas.ToList();
        }
    }
}
