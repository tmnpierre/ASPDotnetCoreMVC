using ToDoList.Models;
using System.Linq.Expressions;

namespace ToDoList.Repositories
{
    public interface ITacheRepository
    {
        bool Add(Tache tache);
        Tache? Get(Expression<Func<Tache, bool>> predicate);
        List<Tache> GetAll();
        List<Tache> GetAll(Expression<Func<Tache, bool>> predicate);
        Tache? GetById(int id);
        bool Update(Tache animal);
        bool Delete(int id);
    }
}
