using ToDoList.Data;
using ToDoList.Models;
using System.Linq.Expressions;

namespace ToDoList.Repositories
{
    public class TacheRepository : ITacheRepository
    {
        private readonly AppDbContext _dbContext;

        public TacheRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(Tache tache)
        {
            var addedObj = _dbContext.Taches.Add(tache);
            _dbContext.SaveChanges();
            return addedObj.Entity.Id > 0;
        }
        public Tache? GetById(int id)
        {
            return _dbContext.Taches.Find(id);
        }
        public Tache? Get(Expression<Func<Tache, bool>> predicate)
        {
            return _dbContext.Taches.FirstOrDefault(predicate);
        }
        public List<Tache> GetAll()
        {
            return _dbContext.Taches.ToList();
        }

        public List<Tache> GetAll(Expression<Func<Tache, bool>> predicate)
        {
            return _dbContext.Taches.Where(predicate).ToList();
        }

        public bool Update(Tache animal)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
