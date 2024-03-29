﻿using LocadoraVeiculos.Dominio.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloCliente;
using System;

namespace LocadoraVeiculos.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase<Condutor>
    {
        public Condutor(){}

        public Condutor(Cliente cliente, string nome, string cpf, string endereco, string cnhCondutor, DateTime validadeCnh, string email, string telefone)
        {
            this.Cliente = cliente;
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            CnhCondutor = cnhCondutor;
            ValidadeCnh = validadeCnh;
            Email = email;
            Telefone = telefone;
        }
        public Guid? ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string CnhCondutor { get; set; }
        public DateTime ValidadeCnh { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        
        public override bool Equals(object obj)
        {
            Condutor condutor = obj as Condutor;

            if (condutor == null)
                return false;

            return
                condutor.Cliente.Id.Equals(Cliente.Id) &&
                condutor.Id.Equals(Id) &&
                condutor.Nome.Equals(Nome) &&
                condutor.Cpf.Equals(Cpf) &&
                condutor.Endereco.Equals(Endereco) &&
                condutor.CnhCondutor.Equals(CnhCondutor) &&
                condutor.ValidadeCnh.Equals(ValidadeCnh) &&
                condutor.Email.Equals(Email) &&
                condutor.Telefone.Equals(Telefone);
        }
        public override string ToString()
        {
            return string.Format("\nCondutor: {0}\nCPF: {1}\nEndereço: {2}\n" +
                "CNH: {3}\nValidade da CNH: {4}\nEmail: {5}\nTelefone: {6}", Nome,Cpf,Endereco,CnhCondutor,ValidadeCnh.ToShortDateString(),Email,Telefone);
        }
    }
}
