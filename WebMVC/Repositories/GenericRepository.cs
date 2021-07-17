using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebMVC.Models.Entity;

namespace WebMVC.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        NorthwindEntities northwindEntites = new NorthwindEntities();

        public List<T> List()
        {
            return northwindEntites.Set<T>().ToList();
        }

        public T TGet(int id)
        {
            return northwindEntites.Set<T>().Find(id);
        }

        public T Find(Expression<Func<T,bool>> where)
        {
            return northwindEntites.Set<T>().SingleOrDefault(where);
        }

        public void TAdd(T p)
        {
            northwindEntites.Set<T>().Add(p);
            northwindEntites.SaveChanges();
        }

        public void TDelete(T p)
        {
            northwindEntites.Set<T>().Remove(p);
            northwindEntites.SaveChanges();
        }

        public void TUpdate(T p)
        {
            northwindEntites.SaveChanges();
        }
    }
}