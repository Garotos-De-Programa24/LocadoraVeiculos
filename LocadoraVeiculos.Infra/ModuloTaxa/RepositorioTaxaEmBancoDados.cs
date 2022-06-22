using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using LocadoraVeiculos.Infra.Compartilhado;
using System;


namespace LocadoraVeiculos.Infra.ModuloTaxa
{
    public class RepositorioTaxaEmBancoDados : RepositorioBase<Taxa, ValidaTaxa, MapeadorTaxa>, IRepositorioTaxa
    {
        protected override string sqlInserir => throw new NotImplementedException();

        protected override string sqlEditar => throw new NotImplementedException();

        protected override string sqlExcluir => throw new NotImplementedException();

        protected override string sqlSelecionarPorId => throw new NotImplementedException();

        protected override string sqlSelecionarTodos => throw new NotImplementedException();

        public Taxa SelecionarPorNumero(int numero)
        {
            throw new NotImplementedException();
        }

        ValidationResult IRepositorio<Taxa>.Excluir(Taxa registro)
        {
            throw new NotImplementedException();
        }
    }
}
