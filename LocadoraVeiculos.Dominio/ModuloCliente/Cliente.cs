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
        public Cliente(string nome, int cPFCNPJ, string endereco, int Cnh, string email, int telefone)
        {
            Nome = nome;
            CPFCNPJ = cPFCNPJ;
            Endereco = endereco;
            CNH = Cnh;
            Email = email;
            Telefone = telefone;
        } 

        public string Nome { get; set; }
        public int CPFCNPJ { get; set; }
        public string Endereco { get; set; }
        public int Telefone { get; set; }
        public int CNH { get; set; }
        public string Email { get; set; }

        public override void Atualizar(Cliente Registro)
        {
            //teste
        }
    }
}
