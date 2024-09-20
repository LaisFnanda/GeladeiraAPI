
using Domain.Models;

namespace Services.Interfaces
{
    public interface IItemServices<Item> where Item : class
    {
        Item? ObterItem(int id);
        List<Item> ObterTodos();
        string InserirItem(Item item);
        string Atualizar(Item item);
        string ExcluirItem(int IdItem);
        string RemoverTodos(int numAndar, int numContainer);
        void AdicionarTodos(List<Domain.Models.Item> itens);
        bool ItemExistente (int idItem);

    }
}