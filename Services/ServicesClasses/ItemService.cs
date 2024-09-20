using Domain.Models;
using Microsoft.Data.SqlClient;
using Repository.Interface;
using Services.Interfaces;

namespace Services.ServicesClasses
{
    public class ItemService : IItemServices<Item>
    {
        private readonly IRepository<Item> _repository;

        public ItemService(IRepository<Item> repository) => _repository = repository;

        public void AdicionarTodos(List<Item> itens)
        {
            foreach (var item in itens)
            {
                var itensContainer = ObterTodos();
                itensContainer = itensContainer?.Where(c => c.Andar == item.Andar && c.Container == item.Container).ToList();

                if (itensContainer is not null)
                    _repository.InserirItem(item);
                else
                    throw new Exception("Container já está cheio");
            }
        }

        public Item? ObterItem(int idItem)
        {
            Item item = new Item();

            try
            {
                if (idItem == 0)
                    return null;

                item = _repository.ObterItem(item);

                if (item != null)
                    return item;
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Item> ObterTodos() => _repository.ObterTodos();

        public string InserirItem(Item item)
        {
            try
            {
                if (item != null)
                {
                    if (PosicaoPreenchida(item))
                    throw new Exception("Posição já preenchida");

                    var itemExistente = ObterItem(item.IdItem);

                    if (itemExistente == null)
                    {
                        _repository.InserirItem(item);
                        return "Item cadastrado com sucesso!";
                    }
                    else
                        throw new Exception("Item já existente na geladeira.");
                }
                else
                    return "Item inválido.";
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }                    
        }

        public string Atualizar(Item item)
        {
            try
            {
                if (item != null)
                {
                    _repository.Atualizar(item);
                    return "Item alterado com sucesso!";
                }
                else
                    return "Item inválido.";
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }

        public string ExcluirItem(int IdItem)
        {
            try
            {
                if (IdItem == 0)
                    throw new Exception("Item inválido! Por favor, tente novamente.");
                else
                {
                    _repository.ExcluirItem(IdItem);
                    return "Item deletado com sucesso!";
                }
            }
            catch (SqlException)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string RemoverTodos(int numAndar, int numContainer)
        {
            var itensContainer = ObterTodos();

            itensContainer = itensContainer?.Where(c => c.Andar == numAndar && c.Container == numContainer).ToList();

            if (itensContainer is not null && itensContainer.Count() > 0)
            {
                foreach (var item in itensContainer)
                    _repository.ExcluirItem(item.IdItem);
            }
            else
                throw new Exception("Container está vazio!");

            return "Container esvaziado com sucesso!";

        }

        private bool PosicaoPreenchida(Item item)
        {
            var lstItems = ObterTodos();
            lstItems = lstItems?.Where(i => i.Andar == item.Andar
                                                            && i.Container == item.Container
                                                            && i.Posicao == item.Posicao).ToList();
            var itemRetornado = lstItems?.FirstOrDefault();

            return itemRetornado != null;
        }

        public bool ItemExistente (int idItem) => _repository.ItemExistente(idItem);
    }
}