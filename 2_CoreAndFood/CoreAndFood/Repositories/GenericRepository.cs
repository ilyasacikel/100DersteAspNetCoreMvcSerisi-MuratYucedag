using CoreAndFood.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoreAndFood.Repositories
{
    public class GenericRepository<T> where T : class
    {
        Context context = new Context();
        public List<T> TList()
        {
            return context.Set<T>().ToList();
        }
        public List<T> TList(string p)
        {
            return context.Set<T>().Include(p).ToList();
        }
        public List<T> List(Expression<Func<T,bool>> filter)
        {
            return context.Set<T>().Where(filter).ToList();
        }
        public void TAdd(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }
        public void TDelete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }
        public void TUpdate(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
        public T TGet(int id)
        {
            return context.Set<T>().Find(id);
        }
    }
}
