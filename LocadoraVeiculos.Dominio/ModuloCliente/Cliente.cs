﻿using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCondutor;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase<Cliente>
    {
        public Cliente(){}

        public Cliente(string nome, string cpfCnpj, string endereco, string email, string telefone)
        {
            Nome = nome;
            CpfCnpj = cpfCnpj;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
        }

        public string Nome { get; set; }
        public string CpfCnpj { get; set; }        
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        
        public override bool Equals(object obj)
        {
            Cliente cliente = obj as Cliente;

            if (cliente == null)
                return false;

            return
                cliente.Id.Equals(Id) &&
                cliente.Nome.Equals(Nome) &&
                cliente.CpfCnpj.Equals(CpfCnpj) &&
                cliente.Endereco.Equals(Endereco) &&
                cliente.Email.Equals(Email)&&
                cliente.Telefone.Equals(Telefone);
        }

        public override string ToString()
        {
            return string.Format("Cliente: {0}\nCPF/CNPJ: {1}\nEndereço: {2}\n" +
                "Email: {3}\nTelefone: {4}", Nome, CpfCnpj,Endereco,Email,Telefone);
        }
    }
}
