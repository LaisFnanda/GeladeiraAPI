using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interface
{
    internal interface IContainer
    {
        void AdicionarItem(int posicao, Item item);
        Item? RetornarItem(int posicao);
        void RemoverItem(int posicao);
        bool EstaCheio();
        bool EstaVazio();
    }
}
