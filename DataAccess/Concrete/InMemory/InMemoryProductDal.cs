using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{

    public class InMemoryProductDal : IProductDal
    {
        //Burada simülasyon yapacağız. Program başladığında data varmış gibi davranmasını sağlayacağız. 
        //Constructor : bellekte referans aldığı zaman çalışacak olan bloktur.
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>()
            {
                new Product{ ProductId =1, CategoryId=1, ProductName = "Bardak", UnitPrice =15 , UnitsInStock=15  },
                new Product{ ProductId =2, CategoryId=1, ProductName = "Kamera", UnitPrice =500 , UnitsInStock=3  },
                new Product{ ProductId =3, CategoryId=2, ProductName = "Telefon", UnitPrice =1500 , UnitsInStock=2  },
                new Product{ ProductId =4, CategoryId=2, ProductName = "Klavye", UnitPrice =150 , UnitsInStock=65  },
                new Product{ ProductId =5, CategoryId=2, ProductName = "Mouse", UnitPrice =85 , UnitsInStock=1  }
            };
        }
        public void Add(Product product)
        {
            //InMemory çalıştığımız için veritabanına değil, listeye ekleme yapacağız.
            //product parametresi buraya business katmanından gelecek
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //Arayüzden silme işlemi için gönderdiğimiz product'ın, silinecek product ile bilgilerinin aynı olması önemli değil.
            //Burada liste içerisinden silme işlemi yapacağımız için referans numarası üzerinden silme işlemi sağlamamız gerekmekte.
            //veritabanında da aslında benzer bir işlem söz konusu, veritabanında da silme işlemi için primary key kullanırız. 
            //Çünkü ürünleri birbirinden farklı kılan değer primary key'dir. 
            //Burada listeden silme işlemi yapacağımız için, sileceğimiz ürünün referans numarasının yakalamalıyız.
            //parametre üzerinden gelen product'ın idsini kullanarak listede denk gelen product ile id'sini eşlemeliyiz.
            //Bu noktada karşımız LINQ dediğimiz bir sistem çıkmakta.
            //ilk önce linq kullanmadığımızı varsayalım.
            //
            //Product productToDelete = null;
            //foreach (var item in _products)
            //{
            //    if (product.ProductId == item.ProductId)
            //    {
            //        productToDelete = item;
            //    }
            //}
            //_products.Remove(productToDelete);

            //Linq c#'ı diğer dillerden daha güçlü hale getiren kullanımlardan biridir.
            //Linq : language Integrated Query : Dile gömülü sorgulama
            //LINQ ile liste bazlı yapıları tıpkı sql gibi filtreleybiliyoruz.
            //LINQ kullanarak yapalım. SingleOrDefault bi linq sorgusudur. kullanabilmek için System.Linq'i using olarak eklememiz gerekmekte.
            //SingleOrDefault tek bir eleman bulmaya yarar. Product'ı tek tek dolaşır. 
            //p=> : bu işarete lambda deniyor.
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p=>p.CategoryId== categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Tıpkı silme işlemi gibi, burada da güncellenecek referansı bulmalıyım.
            //Bu yaptıklarımız işin mantığı,mutfağı. EntityFramework kullandığımızda, EntityFramework bunları bizim yerimize yapacaktır.
            Product productToUpdate = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
