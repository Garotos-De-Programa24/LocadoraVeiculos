using LocadoraVeiculos.Dominio.ModuloFuncionario;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.Compartilhado
{
    public abstract class ControladorBase
    {
        public abstract void Inserir(Funcionario funcionario);
        public abstract void Editar(Funcionario funcionario);
        public abstract void Excluir(Funcionario funcionario);
        public abstract UserControl ObtemListagem();
    }
}

