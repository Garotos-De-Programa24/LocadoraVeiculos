﻿using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ModuloVeiculo
{
    public class RepositorioAgrupamentoVeiculoEmBancoDados : RepositorioBase<AgrupamentoVeiculo, ValidaAgrupamentoVeiculo, MapeadorAgrupamentoVeiculo>, IRepositorioAgrupamentoVeiculo
    {
        protected override string sqlInserir => throw new NotImplementedException();

        protected override string sqlEditar => throw new NotImplementedException();

        protected override string sqlExcluir => throw new NotImplementedException();

        protected override string sqlSelecionarPorId => throw new NotImplementedException();

        protected override string sqlSelecionarTodos => throw new NotImplementedException();

        public AgrupamentoVeiculo SelecionarPorNumero(int numero)
        {
            throw new NotImplementedException();
        }

        ValidationResult IRepositorio<AgrupamentoVeiculo>.Excluir(AgrupamentoVeiculo registro)
        {
            throw new NotImplementedException();
        }
    }
}