using System.ComponentModel;

namespace LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public enum TipoPlano
    {
        [Description("Livre")]
        Livre,
        [Description("Diário")]
        Diario,
        [Description("Controlado")]
        Controlado
    }
}