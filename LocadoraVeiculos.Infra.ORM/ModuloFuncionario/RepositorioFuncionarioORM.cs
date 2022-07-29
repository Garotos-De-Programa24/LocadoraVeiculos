using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Infra.ORM.ModuloFuncionario
{
    public class RepositorioFuncionarioORM : IRepositorioFuncionario
    {
        private DbSet<Funcionario> funcionarios;
        private readonly LocadoraVeiculoDbContext dbContext;
    
        public RepositorioFuncionarioORM(LocadoraVeiculoDbContext dbContext)
        {
            funcionarios = dbContext.Set<Funcionario>();
            this.dbContext = dbContext;
        }

        public void Inserir(Funcionario novoRegistro)
        {
            funcionarios.Add(novoRegistro);
        }

        public void Editar(Funcionario registro)
        {
            funcionarios.Update(registro);
        }
    
        public void Excluir(Funcionario registro)
        {
            funcionarios.Remove(registro);
        }
    
        public Funcionario SelecionarFuncionarioPorNome(string nome)
        {
            return funcionarios.SingleOrDefault(x => x.Nome == nome);
        }
    
        public Funcionario SelecionarFuncionarioPorUsuario(string usuario)
        {
            return funcionarios.SingleOrDefault(x => x.Login == usuario);
        }
    
        public Funcionario SelecionarPorId(Guid id)
        {
            return funcionarios.SingleOrDefault(x => x.Id == id);
        }
    
        public List<Funcionario> SelecionarTodos()
        {
            return funcionarios.ToList();
        }
    }
}
