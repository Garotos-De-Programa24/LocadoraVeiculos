using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloTaxa;
using Serilog;

namespace LocadoraVeiculos.Aplicacao.ModuloTaxa
{
    public class ServicoTaxa
    {
        private IRepositorioTaxa repositorioTaxa;
        public ServicoTaxa(IRepositorioTaxa repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
        }
        public ValidationResult Inserir(Taxa taxa)
        {
            Log.Logger.Information("Tentando inserir no Taxa @{Taxa", taxa);
            ValidationResult resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
            {
                repositorioTaxa.Inserir(taxa);
                Log.Logger.Information("Taxa{TaxaEquipamento} inserido com sucesso.", taxa.Equipamento);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Taxa {TaxaEquipamento} -> Motivo: {erro}", taxa.Equipamento, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxa taxa)
        {
            Log.Logger.Information("Tentando editar no Taxa @{Taxa", taxa);

            ValidationResult resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
            {
                repositorioTaxa.Editar(taxa);
                Log.Logger.Information("Taxa{TaxaEquipamento} editar com sucesso.", taxa.Equipamento);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Taxa {TaxaEquipamento} -> Motivo: {erro}", taxa.Equipamento, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
        }

        private ValidationResult Validar(Taxa taxa)
        {
            var validador = new ValidaTaxa();

            var resultadoValidacao = validador.Validate(taxa);

            if (NomeDuplicado(taxa))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

           
            return resultadoValidacao;
        }

        private bool NomeDuplicado(Taxa taxa)
        {
            var funcionarioEncontrado = repositorioTaxa.SelecionarTaxaPeloNome(taxa.Equipamento);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Equipamento == taxa.Equipamento &&
                   funcionarioEncontrado.Id != taxa.Id;
        }

       
    }
}
