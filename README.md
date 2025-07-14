🎮 Color Switch 
Bu proje, dünya çapında sevilen mobil oyun Color Switch'in Unity oyun motoru ile geliştirilmiş bir yeniden yapımıdır. 
Proje; nesne tabanlı programlama, 2D fizik, kullanıcı arayüzü yönetimi ve Sorumlulukların Ayrılması (Separation of Concerns) ilkesi gibi temel ve orta düzey Unity konularını anlamak için harika bir kaynaktır.

✨ Öne Çıkan Özellikler
Hassas Zıplama Mekaniği: Tek dokunuşla çalışan, Rigidbody2D fiziğine dayalı tepkisel oyuncu kontrolü.
Yıldız Tabanlı Skor Sistemi: Puan, sadece sahnedeki yıldızları toplayarak kazanılır.
Renk Değiştirme ve Çarpışma Mantığı: "Color Changer" nesneleri oyuncunun rengini rastgele değiştirir. Oyuncu, kendi rengi dışındaki bir renk segmentine temas ettiğinde oyun sona erer.
Ayrılmış Sorumluluklar (SoC): Oyun mantığı (GameManager), arayüz yönetimi (UIManager) ve oyuncu davranışları (Player.cs) birbirinden bağımsız script'ler tarafından yönetilerek temiz ve modüler bir kod yapısı oluşturulmuştur.
Dikey İlerleme ve Kamera Takibi: Kamera oyuncuyu dikey eksende akıcı bir şekilde takip ederken, oyuncu yukarı doğru tasarlanmış seviyede ilerler.
Singleton Tasarım Deseni: GameManager ve UIManager gibi yönetici sınıflarına, oyunun herhangi bir yerinden kolayca ve güvenli bir şekilde erişilebilir.

⚙️ Kod Mimarisi ve Teknik Detaylar
Proje, her bir script'in belirli bir göreve odaklandığı, temiz ve verimli bir mimari kullanır. İşte temel script'lerin görev dağılımı:
Script	👑 Görevi
Player.cs	Oyunun ana tetikleyicisi. Oyuncunun zıplama hareketini yönetir. OnTriggerEnter2D ile çarpışmaları dinler. "Star" etiketli nesnelere dokunarak GameManager'a skor eklemesini söyler. "ColorChanger" ile kendi rengini değiştirir. Yanlış renge temas ettiğinde GameManager'a oyunun bittiğini bildirir.
GameManager.cs	Oyunun Durum Yöneticisi (State Manager). Singleton deseni kullanır. Oyunun skorunu bir değişkende tutar. Player'dan gelen istekle skoru günceller ve arayüzün güncellenmesi için UIManager'ı tetikler. Oyunu yeniden başlatma (RestartGame) ve oyun bitiş (GameOver) mantığını içerir.
Rotator.cs	Engellerin sürekli dönmesini sağlar. Hızı, editörden ayarlanabilen public speed değişkeni ile kontrol edilir.
FollowPlayer.cs	Kameranın Player nesnesini dikey (Y) eksende, ancak belirli bir seviyenin altına düşmeyecek şekilde takip etmesini sağlar.
