using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloVeiculo
{
    public class Veiculo : EntidadeBase<Veiculo>
    {
        public byte [] Foto { get; set; }
        public string VeiculoNome{ get; set; }
        public string Marca { get; set; }
        public string Ano { get; set; }
        public string Placa { get; set; }
        public string CapacidadeTanque { get; set; }
        public string KmPercorridos { get; set; }
        public string Combustivel { get; set; }
        public string Cor { get; set; }
        public Agrupamento Agrupamento { get; set; }
        
        public Veiculo()
        {
            Agrupamento = new Agrupamento();
        }
        public Veiculo(byte[] foto, string veiculoNome, string marca, string ano, string placa, string capacidadeTanque, string kmPercorridos, string combustivel, string cor, Agrupamento agrupamentoVeiculo)
        {
            Foto = foto;
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
