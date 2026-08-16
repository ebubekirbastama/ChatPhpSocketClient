# ChatPhpSocketClient

![C#](https://img.shields.io/badge/C%23-.NET-239120?style=for-the-badge&logo=csharp&logoColor=white)
![Windows Forms](https://img.shields.io/badge/UI-Windows%20Forms-512BD4?style=for-the-badge)
![TCP](https://img.shields.io/badge/Network-TCP-0A66C2?style=for-the-badge)
![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.0-512BD4?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Legacy%20%2F%20Experimental-orange?style=for-the-badge)

> C# Windows Forms kullanılarak hazırlanmış, TCP socket üzerinden uzak bir servise mesaj göndermeyi deneyen eski nesil bir istemci uygulaması.

## 📌 Proje Hakkında

`ChatPhpSocketClient`, adı PHP socket istemcisine işaret etse de mevcut kaynak kodu ağırlıklı olarak **C# Windows Forms + TCP Socket** istemcisi şeklindedir.

Uygulama arayüzden girilen mesajı, kod içerisinde belirtilen IP adresi ve port üzerinden TCP bağlantısı kurarak göndermeyi dener. Gönderim sonucunu arayüzdeki liste alanına aktarır.

Proje, TCP socket iletişiminin temel mantığını ve Windows Forms üzerinden basit bir istemci arayüzünün nasıl oluşturulabileceğini incelemek için değerlendirilebilir.

## ✨ Mevcut Özellikler

- 🖥️ Windows Forms tabanlı arayüz
- 🎨 MetroFramework tabanlı form
- 🌐 IPv4 TCP socket bağlantısı
- 📤 Metin mesajı gönderme
- 🔌 IP adresi + port ile uzak servise bağlanma
- 🧩 Ayrı bir `Client` sınıfı ile socket işlemlerini yürütme
- ⚠️ Temel exception mesajı gösterimi

## 🧰 Teknoloji Kartları

| Teknoloji | Kullanım |
|---|---|
| 🟢 **C#** | Ana programlama dili |
| 🪟 **Windows Forms** | Masaüstü kullanıcı arayüzü |
| 🔷 **.NET Framework 4.0** | Hedef çalışma platformu |
| 📡 **System.Net.Sockets** | TCP socket iletişimi |
| 🎨 **MetroFramework** | Arayüz bileşenleri |

## 📁 Proje Yapısı

```text
ChatPhpSocketClient/
├── ChatPhpSocketClient.sln
├── ChatPhpSocketClient/
│   ├── Chat Alanı.cs
│   ├── Chat Alanı.Designer.cs
│   ├── Chat Alanı.resx
│   ├── Class1.cs
│   ├── Program.cs
│   ├── Properties/
│   └── ChatPhpSocketClient.csproj
├── LICENSE
└── README.md
```

## ⚙️ Gereksinimler

- Windows
- Visual Studio / MSBuild
- .NET Framework 4.0
- MetroFramework bileşenleri
- Bağlanılacak TCP servisi

> Proje dosyasında MetroFramework DLL'leri için yerel makineye ait sabit göreli yollar bulunduğundan, başka bir bilgisayarda derleme öncesinde bu referansların yeniden yapılandırılması gerekebilir.

## 🚀 Kurulum

Repository'yi klonlayın:

```bash
git clone https://github.com/ebubekirbastama/ChatPhpSocketClient.git
cd ChatPhpSocketClient
```

Ardından `ChatPhpSocketClient.sln` dosyasını Visual Studio ile açın.

MetroFramework referanslarını kendi geliştirme ortamınıza göre düzeltin ve çözümü derleyin.

## ▶️ Kullanım

Uygulamanın mevcut kodunda bağlantı hedefi sabit olarak örnek değerlerle tanımlanmıştır:

```csharp
new Client("ipadresi", 1234)
```

Gerçek bir test ortamında kullanmadan önce bu değerleri kontrolünüzde bulunan TCP sunucusunun adresi ve portuyla yapılandırmanız gerekir.

Mesaj alanına metin girdikten sonra gönderme düğmesi `Client.start(...)` metodunu çağırır ve mesaj TCP socket üzerinden gönderilmeye çalışılır.

## 🔍 Çalışma Mantığı

```text
Windows Forms
     │
     ▼
Mesaj Girişi
     │
     ▼
Client.start()
     │
     ▼
TCP Socket
     │
     ▼
IP + Port
     │
     ▼
Uzak TCP Servisi
```

`Client` sınıfı `IPAddress.Parse`, `Socket`, `IPEndPoint` ve `Encoding.ASCII` kullanarak bağlantı oluşturur ve mesajı byte dizisine çevirerek gönderir.

## ⚠️ Mevcut Kod Durumu

Bu repository **legacy / deneysel** bir projedir. Mevcut implementasyonda:

- IP adresi ve port kaynak kod içine gömülüdür.
- Socket bağlantı hataları ayrıntılı şekilde yönetilmemektedir.
- Bağlantı için timeout tanımlanmamıştır.
- İletişim protokolü veya mesaj formatı ayrıca tanımlanmamıştır.
- `while (clientSocket.Connected)` akışı üretim kullanımı için yeniden ele alınmalıdır.
- `Send()` dönüş değerinin kullanıcıya anlamlı bir durum olarak gösterilmesi için iyileştirme gerekir.
- MetroFramework referansları yerel dosya yollarına bağlıdır.

README, mevcut kodu olduğundan daha gelişmiş göstermemek amacıyla bu sınırlamaları özellikle belirtmektedir.

## 🔐 Güvenlik ve Etik Kullanım

Bu istemci yalnızca **size ait veya bağlantı kurma yetkiniz bulunan TCP servislerinde** kullanılmalıdır.

- Yetkisiz sistemlere bağlantı denemeyin.
- Kimlik bilgilerini kaynak koduna eklemeyin.
- Test sırasında mümkünse izole bir ağ kullanın.
- Üretim ortamında TLS/şifreli iletişim gereksinimini değerlendirin.

## 🛠️ Modernizasyon Önerileri

Projeyi güncel bir uygulamaya dönüştürmek için:

- .NET Framework 4.0 yerine güncel .NET sürümüne geçiş
- IP/port bilgilerinin `appsettings` veya yapılandırma dosyasından okunması
- Socket timeout ve cancellation desteği
- `async/await` tabanlı ağ iletişimi
- Bağlantı ve gönderim hatalarının ayrıntılı yönetimi
- `NetworkStream` ile kontrollü veri akışı
- Mesaj protokolünün açık şekilde tanımlanması
- TLS/SSL desteği
- Structured logging
- Unit/integration testleri
- MetroFramework bağımlılığının güncel UI teknolojileriyle değiştirilmesi

## 📄 Lisans

Repository içerisinde bulunan `LICENSE` dosyasına bakınız.

## 👤 Geliştirici

**Ebubekir Bastama**

- GitHub: [@ebubekirbastama](https://github.com/ebubekirbastama)

---

⭐ Projeyi faydalı bulduysanız repository'ye yıldız bırakabilirsiniz.
