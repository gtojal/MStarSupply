using MStarSupplyApp.Data.Contexts;

namespace MStarSupplyApp.Data.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {

        public virtual void Add(T entity)
        {
            using (var context = new DataContext())
            {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public virtual List<T> GetAll()
        {
            using (var context = new DataContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public virtual T? GetById(Guid id)
        {
            using (var context = new DataContext())
            {
                return context.Set<T>().Find(id);
            }
        }

        public virtual void Update(T entity)
        {
            using (var context = new DataContext())
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }

        public virtual void Delete(T entity)
        {
            using (var context = new DataContext())
            {
                context.Remove(entity);
                context.SaveChanges();
            }
        }
    }
}
