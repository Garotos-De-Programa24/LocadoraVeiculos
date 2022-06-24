using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.Compartilhado
{
    public abstract class ControladorBase
    {
        public abstract void Inserir();
        public abstract void Editar();
        public abstract void Excluir();
        public abstract UserControl ObtemListagem();        
    }
}

