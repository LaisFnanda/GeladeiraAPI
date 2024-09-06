using Domain;
using Repository.Interface;
using Services.Interfaces;

namespace Services.ServicesClasses
{
    public class ItemService : IServices<Item>
    {
        IRepository<Item> _repository;

        public ItemService(IRepository<Item> repository) => _repository = repository;

        public Item ObterItem(Item item) => _repository.ObterItem(item);

        public List<Item> ObterTodos() => _repository.ObterTodos();

        public void Inserir(Item item) => _repository?.Inserir(item);

        public void Atualizar(Item item) => _repository.Atualizar(item);

        public void Excluir(Item item) => _repository.Excluir(item);
    }
}
