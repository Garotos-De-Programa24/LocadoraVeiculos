using LocadoraVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase<Cliente>
    {
        public Cliente()
        {
        }

        public Cliente(string nome, int cpfCnpj, string endereco, int cnhCondutor, string email, int telefone)
        {
            Nome = nome;
            CpfCnpj = cpfCnpj;
            Endereco = endereco;
            CnhCondutor = cnhCondutor;
            Email = email;
            Telefone = telefone;
        }

        public string Nome { get; set; }
        public int CpfCnpj { get; set; }
        public string Endereco { get; set; }
        public int CnhCondutor { get; set; }
        public DateTime ValidadeCnh { get; set; }
        public int Telefone { get; set; }        
        public string Email { get; set; }

        public override void Atualizar(Cliente Registro)
        {
            //teste
        }
    }
}
