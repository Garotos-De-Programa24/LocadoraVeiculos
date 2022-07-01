using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Apresentacao.Compartilhado;
using LocadoraVeiculos.Apresentacao.ModuloPlanoDeCobrança;
using LocadoraVeiculos.Dominio.ModuloPlanoDeCobranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.Apresentacao.ModuloPlanoDeCobranca
{
    public class ControladorPlanoDeCobranca : ControladorBase
    {
        private readonly IRepositorioPlanoCobranca repositorioPlanoCobranca;
        private TelaCadastroPlanoCobranca telaCadastroPlanoCobranca;
        private readonly ServicoPlanoCobranca ServicoPlanoCobranca;

        public ControladorPlanoDeCobranca(IRepositorioPlanoCobranca repositorioPlanoCobranca, ServicoPlanoCobranca servicoPlanoCobranca)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
            this.ServicoPlanoCobranca = servicoPlanoCobranca;
        }
        public override void Inserir()
        {
            throw new NotImplementedException();
        }
        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

       

        public override UserControl ObtemListagem()
        {
            throw new NotImplementedException();
        }
    }
}
