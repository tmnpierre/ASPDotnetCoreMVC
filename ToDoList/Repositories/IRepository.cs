using ToDoList.Models;
using System.Linq.Expressions;

namespace ToDoList.Repositories
{
    public interface IRepository<TEntity> 
    {
        bool Add(TEntity tache);
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetAll();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        TEntity? GetById(int id);
        bool Update(TEntity tache);
        bool Delete(int id);
        bool Edit(int id);
    }
}
