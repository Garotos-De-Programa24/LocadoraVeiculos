using System.ComponentModel;

namespace LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public enum EnunPlano
    {
        [Description("Livre")]
        Livre,
        [Description("Diário")]
        Diario,
        [Description("Controlado")]
        Controlado
    }
}