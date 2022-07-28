using LocadoraVeiculos.Dominio.ModuloCondutor;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Infra.ORM.ModuloCondutor
{
    public class RepositorioCondutorORM : IRepositorioCondutor
    {
        private DbSet<Condutor> condutores;
        private readonly LocadoraVeiculoDbContext dbContext;
    
        public RepositorioCondutorORM(LocadoraVeiculoDbContext dbContext)
        {
            condutores = dbContext.Set<Condutor>();
            this.dbContext = dbContext;
        }
        public void Inserir(Condutor novoRegistro)
        {
            condutores.Add(novoRegistro);
        }
        public void Editar(Condutor registro)
        {
            condutores.Update(registro);
        }
    
        public void Excluir(Condutor registro)
        {
            condutores.Remove(registro);
        }
    
        public Condutor SelecionarPorId(Guid id)
        {
            return condutores.SingleOrDefault(x => x.Id == id);
        }
    
        public Condutor SelecionarCondutorPorNome(string nome)
        {
            return condutores.SingleOrDefault(x => x.Nome == nome);
        }
        public List<Condutor> SelecionarTodos()
        {
            return condutores.Include(x => x.Cliente).ToList();
        }
    }
}
