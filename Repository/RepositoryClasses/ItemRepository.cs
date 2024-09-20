using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Repository.RepositoryClasses
{
    public class ItemRepository : IRepository<Item>
    {
        ItemContext _context;
        public ItemRepository(ItemContext context) => _context = context;

        public void AdicionarTodos(Item entity) =>         
            _context.Items.ToList();
        

        public void Atualizar(Item item)
        {           
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _context.Update(item);
            _context.SaveChanges();        
        }

        public void ExcluirItem(int IdItem)
        {
            var item = _context.Items.Find(IdItem);

            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }

        public void InserirItem(Item item)
        {
                _context.Add(item);
                _context.SaveChanges();            
        }

        public bool ItemExistente(int idItem) => _context.Items.Any(e => e.IdItem == idItem);

        public Item ObterItem(Item item)
        {
                return _context.Items.First(i => i.IdItem == item.IdItem ||
                                            i.DescricaoItem == item.DescricaoItem ||
                                            i.Posicao == i.Posicao ||
                                            i.Container == item.Container ||
                                            i.Andar == item.Andar); 
        }

        public List<Item> ObterTodos()
        {
                return _context.Items.ToList();  
        }
    }
}
