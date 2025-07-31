# ASP.NET Core MVC Temel Projeleri

> ℹ️ Bu projede Github'ta görünen HTML/CSS/JS oranları yanıltıcıdır. Ayrıntılı not için dosyanın sonundaki \"Geliştirici Notu\" kısmına bakabilirsiniz.

Bu repoda, **ASP.NET Core MVC** teknolojisini adım adım öğrenmek amacıyla geliştirilmiş iki adet temel seviye proje yer almaktadır. Bu projeler, başlangıçtan orta seviyeye kadar ASP.NET Core MVC'nin sıkça kullanılan özelliklerini kapsamaktadır. Geliştirme süreci boyunca hem teorik bilgilerin pratiğe dökülmesi hem de yazılım mimarisi açısından doğru yaklaşımların uygulanması hedeflenmiştir.

Projeler, **Murat Yücedağ'ın "100 Derste ASP.NET Core MVC"** adlı popüler [YouTube Eğitim Serisi](https://youtube.com/playlist?list=PLKnjBHu2xXNOld1njNVQ5fk0e12oqiWc8&si=EI6iLpfe-yfMRjYu) temel alınarak hazırlanmıştır. Eğitim boyunca edinilen kazanımlar, bu repoda somut uygulamalar hâline getirilmiştir.

---

## 1. CoreMvcPersonel

### Proje Açıklaması

ASP.NET Core MVC ile ilk temellerin atıldığı bu projede, basit bir personel yönetim sistemi geliştirilmiştir. Amaç; MVC desenini, view-engine yapılarını ve temel HTTP isteklerinin nasıl işlendiğini kavramaktır.

### Öğrenilen Temel Konular

* Model-View-Controller (MVC) mimarisi ve veri akışı
* Razor Page yapısı ve CSHTML dosya organizasyonu
* Model Binding
* Layout kullanımı ve tekrar eden yapıların yönetimi
* Attribute kullanımı:

  * `[HttpGet]`, `[HttpPost]`
  * `[Authorize]`, `[Key]`, `[Column(TypeName = ...)]`
* Routing mantığı
* Program.cs ve Startup ayarları ile middleware yapısını anlama

### Veritabanı ve Entity Framework Core

* Code First yaklaşımı
* Entity Framework Core kullanımı
* İlişkili tablolar: `Departman`, `Personel`, `Admin`
* CRUD (Create, Read, Update, Delete) işlemlerinin gerçekleştirilmesi

### Authentication & Authorization

* Basit seviye giriş/çıkış yapısı
* `[Authorize]` attribute'u ile sayfa erişim kısıtlamaları

### Kullanılan Teknolojiler

* ASP.NET Core MVC
* Entity Framework Core
* C#
* SQL Server

---

## 2. CoreAndFood

### Proje Açıklaması

CoreAndFood, bir market/mağaza sisteminin ürün ve fiyat yönetimini sağlayan, admin paneline sahip daha kapsamlı bir ASP.NET Core MVC projesidir. Bu projede hem kullanıcı tarafı hem de yönetici tarafı detaylandırılmıştır. Admin kullanıcılar kategori ve ürün yönetimi gerçekleştirebilir, ayrıca istatistiksel verilerle raporlama yapabilir.

### Öne Çıkan Özellikler

* Anasayfada tüm kullanıcılar için ürün ve fiyat listeleme
* Admin girişiyle kontrol paneline erişim
* Kategori ve ürünler için CRUD işlemleri
* İstatistik sayfasında dinamik ve grafiksel veri gösterimi
* Admin giriş-çıkış sistemi

### Teknik Detaylar ve Gelişmiş Uygulamalar

* Repository Design Pattern ile katmanlı mimari
* ViewComponent kullanımı ile sayfa parçacıklarını dinamikleştirme
* X.PagedList.Extensions ile listeleme için sayfalama (pagination)
* JSON veri üretimi: `IActionResult` dönüş tipiyle API benzeri yapı
* Google Charts ile istatistikleri görselleştirme
* Entity Framework Core (Code First)
* İlişkili modeller: `Category`, `Product`, `Admin`, `Context`
* LINQ ile verisel analiz
* Dosya yükleme özelliği:

  * Bilgisayardan resim seçme
  * `Guid` ile benzersiz dosya adı oluşturma
  * `wwwroot` klasörüne kaydetme ve görüntüleme

### Authentication & Authorization

* Gelişmiş kullanıcı yetkilendirme
* `[Authorize]` ve `[AllowAnonymous]` attribute'larının bilinçli kullanımı

### Kullanılan Teknolojiler

* ASP.NET Core MVC
* Entity Framework Core
* C#
* SQL Server
* X.PagedList.Extensions
* Google Charts

---

## Öğrenim Yolculuğu ve Amaç

Bu iki proje, sırasıyla temel ve orta seviye ASP.NET Core MVC kavramlarının öğrenilmesi ve uygulanması için hazırlanmıştır. İlk proje olan **CoreMvcPersonel**, temel yapılar ve basit işlevler içerirken; ikinci proje olan **CoreAndFood**, bu yapıların geliştirilerek daha fonksiyonel bir hale getirilmesini ve web projelerinde karşılaşılabilecek pratik ihtiyaçların karşılanmasını amaçlamıştır.

Her iki proje de gerçek hayattaki uygulamaların basitleştirilmiş simülasyonlarıdır. Öğrenme sürecinde anlaşılması gereken temel yapı taşlarını barındırırlar. MVC tasarım deseni, katmanlı mimari, veri yönetimi, kullanıcı yetkilendirmesi, görsel veri sunumu ve sayfa organizasyonu gibi önemli kavramlar her iki projede de farklı seviyelerde işlenmiştir.

---

## 👨‍💻 Geliştirici Notu

> GitHub'daki dil yüzdeleri biraz yanıltıcı olabilir. `wwwroot` klasöründe hazır temalardan gelen HTML, CSS ve JavaScript dosyaları var ama projede asıl odak backend tarafıydı. Bu dosyaları ben yazmadım, sadece projeye entegre ettim.

Bu projeler, ASP.NET Core MVC yapısını öğrenme sürecimin farklı aşamalarında hazırlanmış çalışmalardır. Hem temel kavramları oturtmak, hem de daha kapsamlı uygulamalara geçiş için önemli birer adımdı.

---

## Kaynak

🎓 **Murat Yücedağ** – [100 Derste ASP.NET Core MVC YouTube Serisi](https://youtube.com/playlist?list=PLKnjBHu2xXNOld1njNVQ5fk0e12oqiWc8&si=EI6iLpfe-yfMRjYu)

---

## Projeden Bazı Ekran Görüntüleri

<img width="1828" height="2303" alt="image" src="https://github.com/user-attachments/assets/8b8cd738-d4ea-4c2b-90ff-fb0c821e0b61" />
<img width="1920" height="1020" alt="image" src="https://github.com/user-attachments/assets/b7ba758a-bebb-4427-b76b-a353913d20ab" />
<img width="1920" height="1020" alt="image" src="https://github.com/user-attachments/assets/99ca76a6-f675-47e4-afc6-5350ce2fbd94" />



