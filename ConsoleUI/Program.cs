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
ICustomerDal içerisinde operasyonları yazmayacağım, çünkü bu işlem için oluşturduğum generic sınıfımda mevcut. Tek yapmam gereken IEntityRepository'i
ICustomerDal'a inherit edip T tipi olarak Customer belirtmek olacaktır.
IEntityRepository benim generic sınıfımdı, ben bu generic sınıfı inherit eden interface veya classlarım için kendi tiplerini kullanmalırını istemiştim
ama bu generic T interface'ime kurallar getirmek istiyorum. Örneğin T yerine sadece IEntity classlarım gelsin, yani veritabanı tablolarına karşılık gelen classlarım
sadece generic sınıftan yararlansın gibi. Sadece veritabanı nesnesi vermemin sebebi, güncelleme,silme,ekleme vs işlemlerimi veritabanı nesnelerime uygularım.
IEntity'de bir interface'idi ve benim veritabanı nesnelerimi tutuyordu. Bu kural getirme, yani kısıtlama işlemine generic constraint denir.
generic constraint : generic kısıt demektir. Bunu yapabilmek için where T : bu şekilde yazıyorum, bu şu demek: T ne olabilir ?
where T : class yazıyorum, T bir referans tip olmak zorunda demek bu, yani int,string gibi değer verilmesini engellemiş oluyoruz. çünkü int değer tiptir. class dediğimizde sadece referans tipler
alınır. Class kuralımdan sonra IEntity kuralı getiyorum. bu şu demek, T ya IEntity olabilir ya da IEntityden implemente alan classlar olabilir. 
3. kural olarak ise IEntity soyut bir nesne ve ben soyut T yerine soyut nesne verilsin istemiyorum. Bunu kontrol edebilmek için new() yazıyorum.
Bu newlenebilir bi IEntity demek. IEntity'in kendisi interface'idi newlenemez. Ancak IEntity'den implemente alan veritabanı nesnelerim yani, Product
Category ve Customer class'larım newlenebilir ve ben sadece bu class'larım T yerine verilebilsin istiyorum. Bundan dolayı new() diyorum.
EntityFramework ile çalışmaya başlayacağız. InMemory'de alıştırma yaptık ve işin arkaplanını öğrendik, şimdi 1 adım daha ileri taşıyacağız.
EntityFramework teknolojisi ile çalışacağım için DataAccess katmanımda Concrete klasörü altına bir EntityFramework klasörü oluşturuyorum. Bunun sebebi
çalıştığımız teknolojileri klasörleme yapmamızdan kaynaklı. EfProductDal ve EfCategoryDal isminde 2 adet class oluşturuyorum. Ef : EntityFramework Product: Nesnem, dal ise dataacceslayer
isimlendirme verirken kullandığım teknoloji, nesne adı, ve dal koyarız.EfProductDal içerisine IProductDal'ı implemente ediyorum. IProductDal'dan
gelen operasyonlar ile EfProductDal classımı dolduruyorum.
Orm : Veritabanındaki tabloları sanki class'mış gibi ilişkilendirip, bütün sql sorgularını linq ile yaptığımız bir ortamdır.
Orm : Veritabanı nesneleri ile kodlar arasında bir ilişki-bağ kurup veritabanı işlerini yapma sürecidir.
EntityFramework kodlarımızı DataAccess katmanı içerisinde yazacağız. DataAccess katmanına sağ tıklayıp manage NuGet packages diyoruz. 
entityframework.sql yazıp install ediyoruz. Bunu DataAccess içerisinde Dependencies altında kurar. Dependencies : bağımlılıklar demek.
Artık dataaccess katmanı içerisinde entityframeworks kodları yazabiliriz.
Entityframework sürecindeki ilk aşama : Entity katmanımda oluşturduğum Product,Customer,Category classlarını veritabanım ile ilişkilendirmem gerekiyor.
Bu ilişkilendirme işini yapabilmek için Context dediğimiz yapıyı kuruyoruz.
Context : veritabanını ile kendi class'larımızı ilişklendirdiğimiz yerdir.
Context dosyasını DataAccess katmanı içerisinde Concrete klasörü altındaki EntityFramework klasörüne class olarak ekliyoruz.
İsimlendirmesi ise, şuan kullandığımız veritabanı Northwind olduğu için NorthwindContext olarak isimlendirme veriyoruz.
Context olarak verdiğimiz isimlendirme Northwindcontext classımın context görevi gördüğü anlamına gelmez. Context görevini verebilmek için
entityframework ile beraber gelen DbContext base sınıfını implement etmemiz gerekmekte. DbContext sınıfını implemente ettiğimizde
NorthwindContext sınıfımız artık gerçekten context görevi almış olur.
Context classımızın içerisinde veritabanımızın adresini belirtmemiz gerekmekte.
override yazarak OnConfiguring metotunu getirmemiz lazım, içerisindeki base kısmını siliyoruz. oraya  optionsBuilder.UseSqlServer yazıyoruz. 
Bunu yazarak sql server kullanacağımızı beliriyoruz. çift tırnak içerisine bir connection string yazacağız.
Gerçek hayatta connection string olarak bir ip adresi girilir. Ama biz development ortamda olduğumuz için local'a bağlanıcaz. 
bağlantı adresini verdik. Şimdi ise benim hangi nesnem veritabanındaki hangi nesneye karşılık gelecek ? bunu belirtmemiz gerekiyor.
Bunun için proplar oluşturuyoruz, dbset tipinde bir nesne ile yapıyoruz. Dbset içerisine kendi nesnelerimizi, karşılığına ise veritabanı nesnesini yazıyoruz.
Bu bağlantılarıda kurduktan sonra Context classı ile işimiz bitti. Artık entityframework kullanarak Product,Customer veya Category'ler ile ilgili
kodlarımızı yazabiliriz.
EfProductDal üzerinde add metotdu ile başlayalım.
Öncelikle using bloğu oluşturuyoruz.
using : C#'a özel bir yapıdır. bir class newlendiğinde garbage collector belli bir zaman sonra bellekten onu atar. using bloğu içerisine yazdığımız nesneler
using bloğu bittiğinde anında bellekten referanslarını siler. Using içerisinde oluşturduğumuz context classını newliyoruz. Northwindcontext classımız newlenecek.
var keywordü : karşısına ne atanırsa onun veri tipini alan bir keyworddür.
EfProductDal'ın içerisindeki operasyonların içerisini tamamladık. 
Şimdi ise business'da değişklik olmacayak çünkü business classı entityframework'e bağımlı değil. Business'da ki yapımız değişmiyor.
Console içerisinde direkt olarak yazdırılabilir. Sadece ProductManager'ı newlerken IProductDal tipinde bir nesne istiyor. Buraya EfProductDal yazdığımızda 
veritabanından bilgileri çekecektir.
*/
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

class Program
{
    static void Main(string[] args)
    {
        ProductManager productDals= new ProductManager(new EfProductDal());
        foreach (var item in productDals.GetAll())
        {
            Console.WriteLine(item.ProductName);
        }
    }
}