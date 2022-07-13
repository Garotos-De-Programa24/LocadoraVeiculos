using LocadoraVeiculos.Dominio.ModuloAgrupamento;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.Compartilhado;
using LocadoraVeiculos.Infra.ModuloAgrupamento;
using LocadoraVeiculos.Infra.ModuloVeiculo;
using LocadoraVeiculos.Infra.Tests.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Infra.Tests.ModuloVeiculo
{
    [TestClass]
    public class RepositorioVeiculoEmBancoDadosTestes : BaseIntegrationTest
    {
        private Veiculo veiculo;
        private Agrupamento agrupamento;
        private RepositorioVeiculoEmBancoDados repositorio;
        private RepositorioAgrupamentoEmBancoDados repositorioAgrupamento;

        public RepositorioVeiculoEmBancoDadosTestes()
        {
         
            repositorioAgrupamento = new RepositorioAgrupamentoEmBancoDados();
            
            agrupamento = new Agrupamento();
            agrupamento.Nome = "Uber";
         

            veiculo = new()
            {
                VeiculoNome = "Ranger",
                Ano = "2001",
                Marca = "Ford",
                Placa = "CLB1238",
                CapacidadeTanque = "68 Litros",
                KmPercorridos = "103400",
                Combustivel = "Diesel",
                Cor = "Prata",
                Agrupamento = agrupamento,
                
            };

            repositorio = new RepositorioVeiculoEmBancoDados();
        }


        [TestMethod]
        public void Deve_inserir_novo_Veiculo()
        {
            //action
            repositorio.Inserir(veiculo);

            //assert
            var veiculoEncontrado = repositorio.SelecionarPorId(veiculo.Id);

            Assert.IsNotNull(veiculoEncontrado);
            Assert.AreEqual(veiculo, veiculoEncontrado);
        }

        public void Deve_editar_informacoes_Veiculo()
        {
            //arrange                      
            repositorio.Inserir(veiculo);

            //action
            veiculo.VeiculoNome = "Focus";
            veiculo.Ano = "2006";
            veiculo.Marca = "Ford";
            veiculo.Placa = "ABC1234";
            veiculo.CapacidadeTanque = "48 Litros";
            veiculo.KmPercorridos = "57000";
            veiculo.Combustivel = "Gasolina";
            veiculo.Cor = "Branco";

            repositorio.Editar(veiculo);

            //assert
            var veiculoEncontrado = repositorio.SelecionarPorId(veiculo.Id);

            Assert.IsNotNull(veiculoEncontrado);
            Assert.AreEqual(veiculo, veiculoEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_Veiculo()
        {
            //arrange           
            repositorio.Inserir(veiculo);

            //action           
            repositorio.Excluir(veiculo);

            //assert
            var veiculoEncontrado = repositorio.SelecionarPorId(veiculo.Id);
            Assert.IsNull(veiculoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_Veiculo()
        {
            //arrange          
            repositorio.Inserir(veiculo);

            //action
            var veiculoEncontrado = repositorio.SelecionarPorId(veiculo.Id);

            //assert
            Assert.IsNotNull(veiculoEncontrado);
            Assert.AreEqual(veiculo, veiculoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_funcionarios()
        {
            //arrange
            var veiculo1 = new Veiculo("S-10", "Chevrolet", "2005", "ACD3214", "57 litros", "45600", "Gasolina", "Prata", agrupamento);
            var veiculo2 = new Veiculo("HB20", "Hyundai", "2010", "ADA2313", "48 litros", "13500", "Gasolina", "Branco", agrupamento);
            var veiculo3 = new Veiculo("Montana", "Chevrolet", "2004", "AAA1111", "52 litros", "67200", "Gasolina", "Branco", agrupamento);

            var repositorio = new RepositorioVeiculoEmBancoDados();
            repositorio.Inserir(veiculo1);
            repositorio.Inserir(veiculo2);
            repositorio.Inserir(veiculo3);

            //action
            var veiculos = repositorio.SelecionarTodos();

            //assert

            Assert.AreEqual(3, veiculos.Count);

            Assert.AreEqual(veiculo1.VeiculoNome, veiculos[0].VeiculoNome);
            Assert.AreEqual(veiculo2.VeiculoNome, veiculos[1].VeiculoNome);
            Assert.AreEqual(veiculo3.VeiculoNome, veiculos[2].VeiculoNome);

        }
    }
}
