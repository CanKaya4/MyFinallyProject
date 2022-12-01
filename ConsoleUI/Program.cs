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
 DataAccess katmanımızda IProduct dal isimli bir interface oluşturduk, içerisine operasyon metotlarımızı yazdık. Bellekte çalışacağımız için
 InMemory isimli klasörümüzün içerisine InMemoryProductDal isimli classımızı oluşturup interface'i dahil ettik. Ve operasyonların içini yazdık.
 Business katmanına geçiyoruz. İlk olarak her zaman önce bir interface yapıyoruz. Product nesne ile çalıştığımız için Business içerisinde inteface'leri IProductService ismi ile kullanıyoruz.
 Bu interface ise iş katmanında kullanacağımız servis operasyonlarını içeriyor. Business katmanı hem Entity katmanını hem de DataAccess katmanını kullanıyor. 
 Bundan dolayı Add reference diyip, DataAccess ve Entity katmanlarını referans veriyoruz.
 Business içerisinde Concrete klasörüne ProductManager ismi ile class oluşturuyoruz. 


 2. Kısım
DataAccess içerisinde kategorilerimiz için ICategoryDal isminde bir interface oluşturuyoruz.
IProductDal içerisinde yazdığımız operasyonların aynısını ICategoryDal içerisinde de yapmamız gerekiyor.
IProductDal içerisindeki metotların aynısı ICategoryDal için yapsam, değiştirmem gereken yerlerse sadece metotların içerisindeki Product parametresi
yerine Category parametresini eklemek olacaktır. Yani sadece veri tiplerini değiştirmem yeterli olacaktır.
Aslında biz bu yapıyı generic class olarak kurabiliriz. Yani gidipte her nesnemizin veri tipini değiştirmek yerine generic sınıflardan yararlanabiliriz.
Generic bir interface yapsak, category veya product yerine generic T olsa. 
Bu kuracağımız generic yapının adı Generic Repository Desing Patter, generic repository tasarım deseni.
DataAccess katmanı içerisinde Abstract klasörüne IEntityRepository isminde generic bir interface ekliyorum. interface'imin generic olması için
<T> ibaresini ekliyorum. T standarttır, Type kısaltmasıdır.
IEntityReposiyory. I : Interface'i tanımlıyor, Entity : Nesnelerim, product, category veya ilerleyen zamanlarda customer gibi,  
IProductDal içerisindeki operasyonlarımı IEntityRepository interface'ime koyuyorum. Parametre olarak T tipinde entity geri göndermesini istiyorum.
T generictir, yani ben bu IEntityRepository interface'imi nerede inherit edersem, orada T tipini doldurmalıyım. T tipi product,category vs olabilir.
Generi sınıfım içerisinde GetAll metodumun altında T tipinde Get metodu yazıyorum. GetAll hepsini getirecek metodumdu, Get ise filterelen datayı
bana getirmeli. Bunun için Expression isimli yapıyı kullanıyoruz. Expression System.Linq kütüphanesinden gelir. Filtre = null demek
Filtre vermeyedebilirsin demek. Bu ifadayi GetAll metodumuzda kullanacağız, eğerki bir filtre yoksa tüm ürünleri gösterebilelim diye.
Oluşturduğum IEntityRepository interface'imi IProductDal'a inherit etsem ve T tipini Product olarak versem, aynı şekilde
ICategoryDal için de yapıp T tipini Category olarak versem işlem tamamlanır. Projemizi bir adım daha ileri taşıdık bu işlem ile.
Şimdi ise test edelim. Entity Katmanım içerisinde yeni bir nesne oluşturuyorum. İsmi Customer. Bu Customer classıma yine entity katmanımda, abstract
klasörü altında bulunan IEntity interface'imden inherit ediyorum. Daha sonra DataAccess katmanımda ICustomerDal isimli bir interface oluşturuyorum.
ICustomerDal içerisinde operasyonları yazmayacağım, çünkü bu işlem için oluşturduğum generic sınıfım mevcut. Tek yapmam gereken IEntityRepository'i
ICustomerDal'a inherit edip T tipi olarak Customer belirtmek olacaktır.
*/
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;

class Program
{
    static void Main(string[] args)
    {
        ProductManager productDals= new ProductManager(new InMemoryProductDal());
        foreach (var item in productDals.GetAll())
        {
            Console.WriteLine(item.ProductName);
        }
    }
}