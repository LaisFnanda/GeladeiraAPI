using Repository.Interface;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryClasses
{
    public class ItemRepository : IRepository<ItemModels>
    {
        ItemContext _context;
        public ItemRepository(ItemContext context) => _context = context;
        public void Atualizar(ItemModels item)
        {
            try
            {
                _context.Update(item);
                _context.SaveChanges();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Excluir(ItemModels item)
        {
            try
            {
                _context.Remove(item);
                _context.SaveChanges();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Inserir(ItemModels item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ItemModels ObterItem(ItemModels item)
        {
            try
            {
                return _context.Items.First(i => i.IdItem == item.IdItem ||
                                            i.DescricaoItem == item.DescricaoItem ||
                                            i.Posicao == i.Posicao ||
                                            i.Container == item.Container ||
                                            i.Andar == item.Andar);
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ItemModels> ObterTodos()
        {
            try
            {
                return _context.Items.ToList();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
