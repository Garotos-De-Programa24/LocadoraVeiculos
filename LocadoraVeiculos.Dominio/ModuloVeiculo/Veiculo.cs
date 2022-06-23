using LocadoraVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloVeiculo
{
    public class Veiculo : EntidadeBase<Veiculo>
    {
        public string VeiculoNome{ get; set; }
        public string Marca { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }
        public int CapacidadeTanque { get; set; }
        public int KmPercorridos { get; set; }
        public string Combustivel { get; set; }
        public string Cor { get; set; }
        public Agrupamento Agrupamento { get; set; }
        
        public Veiculo()
        {

        }
        public Veiculo(string veiculoNome, string marca, int ano, string placa, int capacidadeTanque, int kmPercorridos, string combustivel, string cor, Agrupamento agrupamentoVeiculo)
        {
            VeiculoNome = veiculoNome;
            Marca = marca;
            Ano = ano;
            Placa = placa;
            CapacidadeTanque = capacidadeTanque;
            KmPercorridos = kmPercorridos;
            Combustivel = combustivel;
            Cor = cor;
            Agrupamento = agrupamentoVeiculo;
        }

        public override void Atualizar(Veiculo Registro)
        {
            throw new NotImplementedException();
        }
    }
}
