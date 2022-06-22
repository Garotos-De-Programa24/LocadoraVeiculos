﻿using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Infra.Compartilhado;
using System;

namespace LocadoraVeiculos.Infra.ModuloCliente
{
    public class RepositorioClienteEmBancoDados : RepositorioBase<Cliente, ValidaCliente, MapeadorCliente>,IRepositorioCliente
    {
        protected override string sqlInserir => throw new NotImplementedException();

        protected override string sqlEditar => throw new NotImplementedException();

        protected override string sqlExcluir => throw new NotImplementedException();

        protected override string sqlSelecionarPorId => throw new NotImplementedException();

        protected override string sqlSelecionarTodos => throw new NotImplementedException();

        public Cliente SelecionarPorNumero(int numero)
        {
            throw new NotImplementedException();
        }

        ValidationResult IRepositorio<Cliente>.Excluir(Cliente registro)
        {
            throw new NotImplementedException();
        }
    }
}
