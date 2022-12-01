using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        //Bu metodum tüm ürünleri döndürüğü için List tipindedir.
        //Buradaki Product farklı bir katmandan gelecek. Bunun için DataAccess katmanına Entity katmanı referans edilmelidir.
        //Product nesnem ile ilgili operasyonları buraya yazıyorum.
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        //Ürünleri kategoriye göre getir.
        List<Product> GetAllByCategory(int categoryId);
    }
}
