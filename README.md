# RickAndMorty Api Project
Bu proje Konuşarak Öğren FullStack Stajer Programı Projesidir.
Backend olarak ASP .Net Core Web API
Frontend olarak ASP .Net Core MVc kullanılmıştır.

## Proje hakkında 
Verilen Api daki verileri kendi local database'ime kaydedip Api Oluşturulmuştur. Bu Api MVC Projesinde Consume edilerek gerekli ilişkilerle gelen verileri doğru bir şekilde listelenmiştir.
### Bölümler
* Bölümler sayfasında Bölümler listelendi ve her sayfada 6 adet bölüm gözükecek şekilde sayfalama yapıldı.
* API de Image verisi olmadığı için default olarak temsili bir image konuldu
* Her bölüm kartında bölüme git seçeneği oluşturuldu. Bölüme git butonuna tıklayarak o bölümün id sine göre Api isteği atıldı ve sadece o bölümün verileri ve o bölüme ait olan karakterler listelendi
* Listelenen karakterlerin içerisinde karakterlerin detay sayfası oluşturuldu karaktere git diyerek O karaktere ait id ile Karakterin verileri listelendi
* Search yapabilme fonksiyonu eklendi
### Karakterler
* Karakterler Sayfasında 20 adet Karakter tercihen listelendi ve sayfalama yapıldı.
* Her karakterin verisi karakter kartlarında listelendi
* Karakterin kartlarında Karaktere git seçeneği ile karakterin ıd sine göre istek atıp karakter detay sayfası listelendi.
* Favori karakter için yeni bir db sütunu eklenerek favori karakter ekleme özelliği geldi
* Favoriye eklenen sayı eğer 10 dan büyük olursa şartı için alert eklendi.
### Favoriler
* Favoriler sayfasında favoriye alınmış karakterler listelendi.
* Favoriler sayfasında karakterlerin detayına gitme ve favori karakteri silme butonu eklendi
## Ekran Görüntüleri
![Ekran görüntüsü 2024-02-01 041110](https://github.com/Aydinmfatih/RickAndMortyApi/assets/46519508/6e6cb19f-a632-4c9d-b8ef-5cdb70d9cc80)
![Ekran görüntüsü 2024-02-01 041151](https://github.com/Aydinmfatih/RickAndMortyApi/assets/46519508/6d629c0e-578e-419a-bc25-6c80482ec37b)
![Ekran görüntüsü 2024-02-01 041235](https://github.com/Aydinmfatih/RickAndMortyApi/assets/46519508/bfb99729-3604-45b5-b29d-68ced0b07c88)
![Ekran görüntüsü 2024-02-01 041313](https://github.com/Aydinmfatih/RickAndMortyApi/assets/46519508/8d9a422c-eb01-4b31-a078-c46a1578b6ad)
![Ekran görüntüsü 2024-02-01 041347](https://github.com/Aydinmfatih/RickAndMortyApi/assets/46519508/aa4b4448-b5bd-409e-9bd5-813607fbbc0e)
![Ekran görüntüsü 2024-02-01 041430](https://github.com/Aydinmfatih/RickAndMortyApi/assets/46519508/a789841e-9c29-4d23-afec-a0d89db55fbe)
![Ekran görüntüsü 2024-02-01 041520](https://github.com/Aydinmfatih/RickAndMortyApi/assets/46519508/eda1d819-8687-47a0-bb63-3354ff375d02)
![Ekran görüntüsü 2024-02-01 041606](https://github.com/Aydinmfatih/RickAndMortyApi/assets/46519508/5771c414-7354-478f-ba54-09cbfcc863ee)
![Ekran görüntüsü 2024-02-01 041639](https://github.com/Aydinmfatih/RickAndMortyApi/assets/46519508/c4859c53-d8d0-4650-939e-0bf8c0e39d24)
![Ekran görüntüsü 2024-02-01 041705](https://github.com/Aydinmfatih/RickAndMortyApi/assets/46519508/4d5627ae-fcf3-4c4a-b863-49f45c9eae9a)
![Ekran görüntüsü 2024-02-01 041748](https://github.com/Aydinmfatih/RickAndMortyApi/assets/46519508/0d9be580-5beb-47b7-8c83-6eeafb1c8a71)

