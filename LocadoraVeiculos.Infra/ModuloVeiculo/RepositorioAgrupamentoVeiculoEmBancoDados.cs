using FluentValidation.Results;
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
    public class RepositorioAgrupamentoVeiculoEmBancoDados : RepositorioBase<Agrupamento, ValidaAgrupamentoVeiculo, MapeadorAgrupamentoVeiculo>, IRepositorioAgrupamentoVeiculo
    {
        protected override string sqlInserir => throw new NotImplementedException();

        protected override string sqlEditar => throw new NotImplementedException();

        protected override string sqlExcluir => throw new NotImplementedException();

        protected override string sqlSelecionarPorId => throw new NotImplementedException();

        protected override string sqlSelecionarTodos => throw new NotImplementedException();

        public Agrupamento SelecionarPorNumero(int numero)
        {
            throw new NotImplementedException();
        }

        ValidationResult IRepositorio<Agrupamento>.Excluir(Agrupamento registro)
        {
            throw new NotImplementedException();
        }
    }
}
