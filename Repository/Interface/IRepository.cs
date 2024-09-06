using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> ObterTodos();
        TEntity ObterItem(TEntity entity);
        void Inserir(TEntity entity);
        void Atualizar(TEntity entity);
        void Excluir(TEntity entity);
    }
}
