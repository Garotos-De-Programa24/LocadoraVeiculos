using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.ModuloFuncionario
{
    public class RepositorioFuncionarioEmBancoDados : RepositorioBase<Funcionario, ValidaFuncionario, MapeadorFuncionario>, IRepositorioFuncionario
    {
        protected override string sqlInserir => throw new NotImplementedException();

        protected override string sqlEditar => throw new NotImplementedException();

        protected override string sqlExcluir => throw new NotImplementedException();

        protected override string sqlSelecionarPorId => throw new NotImplementedException();

        protected override string sqlSelecionarTodos => throw new NotImplementedException();

        public Funcionario SelecionarPorNumero(int numero)
        {
            throw new NotImplementedException();
        }

        ValidationResult IRepositorio<Funcionario>.Excluir(Funcionario registro)
        {
            throw new NotImplementedException();
        }
    }
}
