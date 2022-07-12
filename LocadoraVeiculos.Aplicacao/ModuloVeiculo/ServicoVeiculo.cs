using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using Serilog;

namespace LocadoraVeiculos.Aplicacao.ModuloVeiculo
{
    public class ServicoVeiculo
    {
        private IRepositorioVeiculo repositorioVeiculo;

        public ServicoVeiculo(IRepositorioVeiculo repositorioVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
        }

        public ValidationResult Inserir(Veiculo veiculo)
        {
            Log.Logger.Information("Tentando inserir no Veiculo @{Veiculo", veiculo);
            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
            {
                repositorioVeiculo.Inserir(veiculo);
                Log.Logger.Information("Veiculo{VeiculoNome} inserido com sucesso.", veiculo.VeiculoNome);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Veiculo {Veiculo} -> Motivo: {erro}", veiculo.VeiculoNome, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
        }

        public ValidationResult Editar(Veiculo veiculo)
        {
            Log.Logger.Information("Tentando editar no Veiculo @{Veiculo", veiculo);

            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
            {
                repositorioVeiculo.Editar(veiculo);
                Log.Logger.Information("Veiculo{VeiculoNome} editar com sucesso.", veiculo.VeiculoNome);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Veiculo {VeiculoNome} -> Motivo: {erro}", veiculo.VeiculoNome, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
        }

        private ValidationResult Validar(Veiculo veiculo)
        {
            var validador = new ValidaVeiculo();

            var resultadoValidacao = validador.Validate(veiculo);

            if (NomeDuplicado(veiculo))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));


            return resultadoValidacao;
        }

        private bool NomeDuplicado(Veiculo veiculo)
        {
            var veiculoEncontrado = repositorioVeiculo.SelecionarVeiculoPeloNome(veiculo.VeiculoNome);

            return veiculoEncontrado != null &&
                   veiculoEncontrado.VeiculoNome == veiculo.VeiculoNome;
                   
        }
    }
    
}
