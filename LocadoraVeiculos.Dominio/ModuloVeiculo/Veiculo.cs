using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using System;
using System.IO;

namespace LocadoraVeiculos.Dominio.ModuloVeiculo
{
    public class Veiculo : EntidadeBase<Veiculo>
    {
        public byte [] Foto { get; set; }
        public string CaminhoDaFotoNaMaquina { get; set; }
        public string VeiculoNome{ get; set; }
        public string Marca { get; set; }
        public string Ano { get; set; }
        public string Placa { get; set; }
        public string CapacidadeTanque { get; set; }
        public string KmPercorridos { get; set; }
        public string Combustivel { get; set; }
        public string Cor { get; set; }
        public bool Disponivel { get; set; }
        public Agrupamento Agrupamento { get; set; }
        
        public Guid? AgrupamentoId { get; set; }

        public Veiculo(){}
        public Veiculo(string veiculoNome, string marca, string ano, string placa, string capacidadeTanque, string kmPercorridos, string combustivel, string cor, Agrupamento agrupamentoVeiculo, byte[] foto)
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
        public void SalvarFoto(Veiculo veiculo)
        {
            if(veiculo.CaminhoDaFotoNaMaquina != null)
            this.Foto = ConverterFotoParaBytes(veiculo.CaminhoDaFotoNaMaquina);
        }
    
        private byte[] ConverterFotoParaBytes(string caminhoDaFotoNaMaquina)
        {
            byte[] novaFoto;
            using(var stream = new FileStream(caminhoDaFotoNaMaquina, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    novaFoto = reader.ReadBytes((int)stream.Length);
                }
            }
            return novaFoto;
        }

        public override void Atualizar(Veiculo Registro)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            Veiculo veiculo = obj as Veiculo;

            if (veiculo == null)
                return false;

            return
                veiculo.Id.Equals(Id) &&
                veiculo.VeiculoNome.Equals(VeiculoNome) &&
                veiculo.Ano.Equals(Ano) &&
                veiculo.Marca.Equals(Marca) &&
                veiculo.Placa.Equals(Placa) &&
                veiculo.CapacidadeTanque.Equals(CapacidadeTanque) &&
                veiculo.KmPercorridos.Equals(KmPercorridos) &&
                veiculo.Combustivel.Equals(Combustivel) &&
                veiculo.Cor.Equals(Cor) &&
                veiculo.Agrupamento.Equals(Agrupamento) &&
                veiculo.Disponivel.Equals(Disponivel);
        }
    }
}
