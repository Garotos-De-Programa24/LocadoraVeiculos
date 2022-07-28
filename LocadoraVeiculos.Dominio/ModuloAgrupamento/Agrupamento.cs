using LocadoraVeiculos.Dominio.Compartilhado;
using System;

namespace LocadoraVeiculos.Dominio.ModuloAgrupamento
{
    public class Agrupamento : EntidadeBase<Agrupamento>
    {
        public Agrupamento(){}

        public Agrupamento(Guid id,string nome)
        {
            Id = id;
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
