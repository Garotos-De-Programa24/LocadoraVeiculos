using LocadoraVeiculos.Dominio.Compartilhado;


namespace LocadoraVeiculos.Dominio.ModuloTaxa
{
    public interface IRepositorioTaxa : IRepositorio<Taxa>
    {
        Taxa SelecionarTaxaPeloNome(string nome);
    }
}
