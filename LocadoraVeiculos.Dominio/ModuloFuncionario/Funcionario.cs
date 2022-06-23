using LocadoraVeiculos.Dominio.Compartilhado;
using System;

namespace LocadoraVeiculos.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public Funcionario()
        {
        }

        public Funcionario(string nome, string login, string senha, decimal salario, DateTime admissao, bool gerente)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            Salario = salario;
            DataAdmissao = admissao;
            Gerente = gerente;
        }

        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataAdmissao { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }        
        public bool Gerente { get; set; }

        public override void Atualizar(Funcionario Registro)
        {
            throw new NotImplementedException();
        }
    }
}
