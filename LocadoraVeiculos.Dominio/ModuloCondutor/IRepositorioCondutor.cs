﻿using LocadoraVeiculos.Dominio.Compartilhado;

namespace LocadoraVeiculos.Dominio.ModuloCondutor
{
    public interface IRepositorioCondutor : IRepositorio<Condutor>
    {
        Condutor SelecionarCondutorPorNome(string nome);
    }
}
