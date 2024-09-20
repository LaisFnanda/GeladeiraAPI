

namespace Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> ObterTodos();
        TEntity ObterItem(TEntity entity);
        void InserirItem(TEntity entity);
        void Atualizar(TEntity entity);
        //void Excluir(TEntity entity);
        void AdicionarTodos(TEntity entity);
        void ExcluirItem(int idItem);

        bool ItemExistente(int idItem);
    }
}
