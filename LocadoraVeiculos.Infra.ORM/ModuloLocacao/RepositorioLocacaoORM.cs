﻿

using LocadoraVeiculos.Dominio.ModuloLocação;
using LocadoraVeiculos.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Infra.ORM.ModuloLocacao
{
    public class RepositorioLocacaoORM : IRepositorioLocacao
    {
        private DbSet<Locacao> locacacoes;
        private readonly LocadoraVeiculoDbContext _dbContext;
        public RepositorioLocacaoORM(LocadoraVeiculoDbContext dbContext)
        {
            _dbContext = dbContext;
            locacacoes = _dbContext.Set<Locacao>();
           
                
        }
        public void Inserir(Locacao novoRegistro)
        {
            locacacoes.Add(novoRegistro);
        }
        public void Editar(Locacao registro)
        {
            locacacoes.Update(registro);
        }

        public void Excluir(Locacao registro)
        {
            locacacoes.Remove(registro);
        }

        public Locacao SelecionarPorId(Guid id)
        {
            return locacacoes.FirstOrDefault(x => x.Id == id);
        }

        public List<Locacao> SelecionarTodos()
        {
            return locacacoes
                .Include(x => x.Agrupamento)
                .Include(x => x.Cliente)
                .Include(x => x.Condutor)
                .Include(x => x.Funcionario)
                .Include(x => x.Plano)
                .Include(x => x.Taxas)
                .Include(x => x.Veiculo)
                .ToList();
        }
    }
}
