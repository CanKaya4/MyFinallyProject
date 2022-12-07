using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                //Referansı yakala,o aslında eklenecek bir nesne, ve ekle. demek
                var addedEntity = northwindContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                northwindContext.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                var deletedEntity = northwindContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                northwindContext.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                return northwindContext.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            //eğer bir filtre verilmemişse tüm ürünleri getir. if ile yazılacak  
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                //ternary operatörü ile yazım
                // Eğer filtre null ise burayı çalıştır                            //Eğer filtre verilmişse burayı çalıştır.
                // return filter == null ? northwindContext.Set<Product>().ToList() : northwindContext.Set<Product>().Where(filter).ToList();
                

                //Normal yazım
                if (filter == null) 
                {
                    return northwindContext.Set<Product>().ToList();
                }
                else
                {
                    return northwindContext.Set<Product>().Where(filter).ToList();
                }
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext northwindContext = new NorthwindContext())
            {
                var updateEntity = northwindContext.Entry(entity);
                updateEntity.State = EntityState.Modified;
                northwindContext.SaveChanges(); 
            }
        }
    }
}
