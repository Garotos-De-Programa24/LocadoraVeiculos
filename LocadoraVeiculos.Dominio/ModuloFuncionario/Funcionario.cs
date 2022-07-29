using LocadoraVeiculos.Dominio.Compartilhado;
using System;

namespace LocadoraVeiculos.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public Funcionario()
        {
        }

        public Funcionario(string nome, string login, string senha, string salario, DateTime admissao, bool gerente)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            Salario = salario;
            DataAdmissao = admissao;
            Gerente = gerente;
        }

        public string Nome { get; set; }
        public string Salario { get; set; }
        public DateTime DataAdmissao { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }        
        public bool Gerente { get; set; }

        
        public override bool Equals(object obj)
        {
            Funcionario funcionario = obj as Funcionario;

            if (funcionario == null)
                return false;

            return
                funcionario.Id.Equals(Id) &&
                funcionario.Nome.Equals(Nome) &&
                funcionario.Login.Equals(Login) &&
                funcionario.Senha.Equals(Senha) &&
                funcionario.Salario.Equals(Salario) &&
                funcionario.DataAdmissao.Equals(DataAdmissao) &&
                funcionario.Gerente.Equals(Gerente);
        }
        public string GetGerente()
        {
            if(Gerente == false)
            {
                return "Não";
            }
            else
            {
                return "Sim";
            }
        }
    }
}
