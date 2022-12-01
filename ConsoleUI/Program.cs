/*                                                        NOTLAR
 * Solution : bizim birbiri ile ilişkili katmanları, projeleri içine koyduğumuz yapının kendisi.                                                       
 Yazılım geliştirme de düzeni soyutlama teknikleri ile yaparız.                                                        
 Veritabanı programlama yaparken, kodlarımızı farklı parçalara-katmanlara bölüyoruz. Nedir bu parçalar ?
 * DataAccess (Veri erişim) : Sadece Veriye ulaşmak için yazdığımız kodları içeren katmandır. Sql'ler burada yazılır.
 * Business (iş) : En çok if kullanacağımız yer. Kurallarımızı yazdığımız yer. Dikkatli ve doğru kodlanmalıdır.
 * UI (user interface) : Kullanıcının gördüğü arayüzdür.
 * Entity : Tüm katmanlarda kullanabileceğimiz, yardımcı bir katman.
 * API : Business'i ve business'e bağlı olan dataccess katmanını api katmanı ile dış dünyaya açıyoruz.  
 ConsoleUI hariç tüm katmanlara 2 adet klasör oluşturuyoruz. Concrete (Somut) ve Abstract (Soyut) isminde iki klasör.
 Soyut nesneleri, yani interface'leri, abstract'ları ve base class'ları Abstract klasörü içerisine koyacağız.
 Abstract klasörünün içerisine referans tutucuları koyacağız.
 Biz abstract klasörünün içine oluşturduğumuz soyut classlar ile uygulamalar arasındaki bağımlılığı minimize edeceğiz.
 Somut classları, yani gerçek işi yapan classları ise Concrete klasörü altında oluşturacağız.
 Erişim belirleyicileri
 * Public : public olan class'a diğer katmanlarda ulaşabilir.
 * internal : Sadece oluşturulan katman içerisinden ulaşılabilir. Bir class'ın default erişim belirleyicisi internal'dır
 Çıplak class kalmamalı, eğer ki bir class herhangi bir inheritance veya interface implementasyonu almıyorsa ileride problem yaşabilir.
 Bundan dolayı biz bu varlıklarımızı işaretleme eğilimine gideriz. Yani gruplarız. 
 Nedir bu gruplama ?
 Entity Katmanında, Concrete klasörü içerisindeki class'lar veritabanı tablosuna karşılık gelir.
 Concrete classlarını gruplamak için Abstract klasörü içerisinde IEntity isminde bir interface oluşturup, 
 Concrete class içeriside veritabanı tablolarıma karşılık gelen tüm class'larımı IEntitiy ile işaretliyorum.
 IEntity'i implemente eden - veya işaretlenen classlar bir veritabanı nesnesidir demek. Bundan dolayı Concrete içerisinde ki 
 class'ları IEntity interface'i ile implemente ediyoruz.
 Entity içerisinde 2 tane veritabanına karşılık gelen nesnem var, Product ve Category isminde. DataAccess içerisinde öncelikle
 Bu nesnelerin interface'leri oluşturulur. İsimlendirme ise IProductDal. I interface, Product nesnesinin adı, dal ise Dataccess layer.
 IProductDal nesnesi  Product ile ilgili operasyonları içeren Interface'dir. Operasyonlar, Ekle,Güncelle,Sil vs işlemlerdir.
 Interface'lerin kendileri internal'dır. Operasyonları ise public'tir. 
 Şimdilik Bellekte çalışacağım, daha sonra EntityFramwork ile devam edeceğim. Çalıştığımız ortam için DataAccess içerisinde klasörleme
 yapıyoruz. InMemory klasörü ekleyeceğim ama daha sonra EntityFramework ile çalışırken de EntityFramework klasörü ekleyeceğim.
 Yani DataAccess katmanında Concrete içerisinde, çalıştığımız teknolojiye göre klasörlendirme yapmalıyız.
 IProductDal interface'ini Concrete'de iş yapan bir sınıf haline getireceğiz. Yani Interface içerisindeki Add,Update,Delete ve GetAll
 Metotlarının içini Concrete içerisinde yazıyoruz. DataAccess içerisinde class oluşturuyoruz. Örnek olarak InMemoryProductDal
 InMemory : Teknolojinin ismi,Product : Çalışacağımız nesne, Dal ise DataAccess Layer
*/
class Program
{
    static void Main(string[] args)
    {

    }
}