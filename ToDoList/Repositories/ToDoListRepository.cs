using ToDoList.Data;
using ToDoList.Models;
using System.Linq.Expressions;

namespace ToDoList.Repositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        public bool Add(ToDoLists tache)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ToDoLists? Get(Expression<Func<ToDoLists, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<ToDoLists> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ToDoLists> GetAll(Expression<Func<ToDoLists, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ToDoLists? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ToDoLists animal)
        {
            throw new NotImplementedException();
        }
    }
}
