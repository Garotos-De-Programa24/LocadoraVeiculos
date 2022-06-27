using LocadoraVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloAgrupamento
{
    public class Agrupamento : EntidadeBase<Agrupamento>
    {
        public Agrupamento()
        {
        }

        public Agrupamento(string nome)
        {
            Nome = nome;            
        }

        public string Nome { get; set; }        

        public override void Atualizar(Agrupamento Registro)
        {
            //teste
        }
        public override bool Equals(object obj)
        {
            Agrupamento agrupamento = obj as Agrupamento;

            if (agrupamento == null)
                return false;

            return
                agrupamento.Id.Equals(Id) &&
                agrupamento.Nome.Equals(Nome);
                
        }
    }
}
