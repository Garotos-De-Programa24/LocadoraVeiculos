
using LocadoraVeiculos.Infra.Compartilhado;

namespace LocadoraVeiculos.Infra.Tests.Compartilhado
{
    public class BaseIntegrationTest
    {
        public BaseIntegrationTest()
        {
            //dependentes
            Db.ExecutarSql("DELETE FROM TBCONDUTOR;");
            Db.ExecutarSql("DELETE FROM TBPLANO;");
            Db.ExecutarSql("DELETE FROM TBVEICULO;");

            //não dependentes
            Db.ExecutarSql("DELETE FROM TBAGRUPAMENTO;");
            Db.ExecutarSql("DELETE FROM TBFUNCIONARIO;");
            Db.ExecutarSql("DELETE FROM TBTAXA;");
            Db.ExecutarSql("DELETE FROM TBCLIENTE;");

           

           
        }
    }
}
