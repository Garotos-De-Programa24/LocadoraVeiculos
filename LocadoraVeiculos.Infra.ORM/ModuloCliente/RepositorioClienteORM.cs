using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Infra.ORM.ModuloCliente
{
    public class RepositorioClienteORM : IRepositorioCliente
    {
        private DbSet<Cliente> clientes;
        private readonly LocadoraVeiculoDbContext dbContext;

        public RepositorioClienteORM(LocadoraVeiculoDbContext dbContext)
        {
            clientes = dbContext.Set<Cliente>();
            this.dbContext = dbContext;
        }
        public void Inserir(Cliente novoRegistro)
        {
            clientes.Add(novoRegistro);
        }
        public void Editar(Cliente registro)
        {
            clientes.Update(registro);
        }

        public void Excluir(Cliente registro)
        {
            clientes.Remove(registro);
        }

        public Cliente SelecionarPorId(Guid id)
        {
            return clientes.SingleOrDefault(x => x.Id == id);
        }

        public Cliente SelecionarClientePorNome(string nome)
        {
            return clientes.SingleOrDefault(x => x.Nome == nome);
        }
        public List<Cliente> SelecionarTodos()
        {
            return clientes.ToList();
        }
    }
}
