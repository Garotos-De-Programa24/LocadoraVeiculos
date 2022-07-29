using LocadoraVeiculos.Dominio.Compartilhado;

namespace LocadoraVeiculos.Dominio.ModuloLocação
{
    public interface IRepositorioLocacao : IRepositorio<Locacao>
    {
        Locacao SelecionarLocacaoPorCliente(string nome);

    }
}
