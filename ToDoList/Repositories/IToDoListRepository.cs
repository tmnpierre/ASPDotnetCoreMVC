using ToDoList.Models;
using System.Linq.Expressions;

namespace ToDoList.Repositories
{
    public interface IToDoListRepository
    {
        bool Add(ToDoLists tache);
        ToDoLists? Get(Expression<Func<ToDoLists, bool>> predicate);
        List<ToDoLists> GetAll();
        List<ToDoLists> GetAll(Expression<Func<ToDoLists, bool>> predicate);
        ToDoLists? GetById(int id);
        bool Update(ToDoLists animal);
        bool Delete(int id);
    }
}
