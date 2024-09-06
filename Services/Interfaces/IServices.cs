using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IServices<TEntity> where TEntity : class
    {
        TEntity ObterItem(TEntity entity);
        List<TEntity> ObterTodos();
        void Inserir(TEntity entity);
        void Atualizar(TEntity entity);
        void Excluir(TEntity entity);
    }
}
