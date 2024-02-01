using Exercice02Marmosets.Models;
using System.Linq.Expressions;

namespace Exercice02Marmosets.Repositories
{
    public interface IMarmosetRepository
    {
        bool Add(Marmoset marmoset);
        Marmoset? Get(Expression<Func<Marmoset, bool>> predicate);
        List<Marmoset> GetAll();
        List<Marmoset> GetAll(Expression<Func<Marmoset, bool>> predicate);
        Marmoset? GetById(int id);
        bool Update(Marmoset marmoset);
        bool Delete(int id);
    }
}
