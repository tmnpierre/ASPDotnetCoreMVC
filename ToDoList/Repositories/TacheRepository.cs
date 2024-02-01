using ToDoList.Data;
using ToDoList.Models;
using System.Linq.Expressions;

namespace ToDoList.Repositories
{
    public class TacheRepository : ITacheRepository
    {
        public bool Add(Tache tache)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Tache? Get(Expression<Func<Tache, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Tache> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Tache> GetAll(Expression<Func<Tache, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Tache? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Tache animal)
        {
            throw new NotImplementedException();
        }
    }
}
