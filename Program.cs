using System;
using System.Collections.Generic;
using System.Numerics;

namespace MyFirstProgram
{
    class Program
    {


        // Kredi Metotları
        public static void HesaplaIhtiyacKredisi(double anaPara, double faizOrani, int vadeAy)
        {
            double aylikFaizOrani = faizOrani / 100;
            double faktorUst = Math.Pow(1 + aylikFaizOrani, vadeAy);
            double taksitTutari = anaPara * (aylikFaizOrani * faktorUst) / (faktorUst - 1);
            double geriOdenecekToplamTutar = taksitTutari * vadeAy;
            double toplamFaiz = geriOdenecekToplamTutar - anaPara;
            double aylikMaliyetOrani = (toplamFaiz / anaPara) / vadeAy * 100;
            double yillikMaliyetOrani = aylikMaliyetOrani * 12;

            Console.WriteLine($"\nTaksit Tutarı: {taksitTutari:F2}\nGeri Ödenecek Toplam Tutar: {geriOdenecekToplamTutar:F2}\n" +
                $"Aylık Maliyet Oranı: %{aylikMaliyetOrani:F4}\nYıllık Maliyet Oranı: %{yillikMaliyetOrani:F4}\n\n");
        }

        public static void HesaplaIsYeriKredisi(double anaPara, double faizOrani, int vadeAy)
        {
            double aylikFaizOrani = faizOrani / 100;
            double faktorUst = Math.Pow((1 + aylikFaizOrani), vadeAy);
            double taksitTutari = anaPara * (aylikFaizOrani * faktorUst) / (faktorUst - 1);
            double toplamGeriOdeme = taksitTutari * vadeAy;
            double toplamFaiz = toplamGeriOdeme - anaPara;
            double aylikMaliyetOrani = (toplamFaiz / anaPara) / vadeAy * 100;
            double yillikMaliyetOrani = aylikMaliyetOrani * 12;

            Console.WriteLine($"Taksit Tutarı: {taksitTutari:F2}\nGeri Ödenecek Toplam Tutar: {toplamGeriOdeme:F2}\n" +
                $"Aylık Maliyet Oranı: {aylikMaliyetOrani:F4}\nYıllık Maliyet Oranı: {yillikMaliyetOrani:F4}");
        }

        public static void HesaplaKonutKredisi(double anaPara, double faizOrani, int vadeAy)
        {
            double aylikFaizOrani = faizOrani / 100;
            double faktorUst = Math.Pow((1 + aylikFaizOrani),vadeAy);
            double taksitTutari = anaPara * (aylikFaizOrani * faktorUst) / (faktorUst - 1);
            double toplamGeriOdeme = taksitTutari * vadeAy;
            double toplamFaiz = toplamGeriOdeme - anaPara;
            double aylikMaliyetOrani = (toplamFaiz / anaPara) / vadeAy * 100;
            double yillikMaliyetOrani = aylikMaliyetOrani * 12;
            Console.WriteLine($"Taksit Tutarı: {taksitTutari:F2}\nGeri Ödenecek Toplam Tutar: {toplamGeriOdeme:F2}\n" +
               $"Aylık Maliyet Oranı: {aylikMaliyetOrani:F4}\nYıllık Maliyet Oranı: {yillikMaliyetOrani:F4}");
        }

        // Finans Metodu
        public static void DogrulaIban(string iban)
        {

        }

        // Sınav Metotları
        public static bool HesaplaDgsPuan()
        {
            // Kullanıcıdan Alınan Girdiler
            string dgsSayisalDogruText;  // Doğru + Yanlış <= 50
            string dgsSayisalYanlisText;
            string dgsSozelDogruText; // Doğru + Yanlış <= 50
            string dgsSozelYanlisText;
            string onlisansBPuanıText; // 40-80 arası


            Console.Write("DGS: Sayısal Doğru : ");
            dgsSayisalDogruText = Console.ReadLine();
            Console.Write("DGS: Sayısal Yanlış : ");
            dgsSayisalYanlisText = Console.ReadLine();
            Console.Write("DGS: Sözel Doğru : ");
            dgsSozelDogruText = Console.ReadLine();
            Console.Write("DGS: Sözel Yanlış : ");
            dgsSozelYanlisText = Console.ReadLine();
            Console.Write("DGS: Ön Lisans B. Puanı : \n");
            onlisansBPuanıText = Console.ReadLine();

            if (int.TryParse(dgsSayisalDogruText, out int sayisalDogru) && int.TryParse(dgsSayisalYanlisText, out int sayisalYanlis) &&
                int.TryParse(dgsSozelDogruText, out int sozelDogru) && int.TryParse(dgsSozelYanlisText,out int sozelYanlis) &&
                int.TryParse(onlisansBPuanıText, out int onlisansPuan) && (sayisalDogru + sayisalYanlis <= 50) && (sozelDogru + sozelYanlis <= 50) &&
                (onlisansPuan <= 80 && onlisansPuan >= 40) && (sayisalDogru >= 0 && sayisalYanlis >= 0 && sozelDogru >= 0 && sozelYanlis >= 0)
                )
            {
                double sayisalNet = sayisalDogru - (sayisalYanlis / 4.0);
                double sozelNet = sozelDogru - (sozelYanlis / 4.0);
                double toplamNet = sayisalNet + sozelNet;

                double sayisalYuzde = (sayisalNet / 50.0) * 100;
                double sozelYuzde = (sozelNet / 50.0) * 100;
                double toplamYuzde = (toplamNet / 100.0) * 100;

                double dgsSayisalPuani = (sayisalNet * 5.23) + 100;
                double dgsSozelPuani = (sozelNet * 5.46) + 100;

                double dgsEsitAgirlikPuani = (dgsSayisalPuani + dgsSozelPuani) / 2.0;

                double agirlikliOnlisansBasariPuani = onlisansPuan * 0.4;

                Console.WriteLine( $"DGS Sayısal Testi: {sayisalNet:F2} net (%{sayisalYuzde:F2})\n" +
                                   $"DGS Sözel Testi: {sozelNet:F2} net (%{sozelYuzde:F2})\n" +
                                   $"Toplam: {toplamNet:F2} net (%{toplamYuzde:F2})\n\n" +
                                   $"DGS Sayısal Puanı: {dgsSayisalPuani:F5}\n" +
                                   $"DGS Sözel Puanı: {dgsSozelPuani:F5}\n" +
                                   $"DGS Eşit Ağırlık Puanı: {dgsEsitAgirlikPuani:F5}\n\n" +
                                   $"Ağırlıklı Önlisans Başarı Puanı: {agirlikliOnlisansBasariPuani:F5} (Yukarıdaki puanlara dahil edilmiştir.)");

                return true;
            }
            else
            {
                Console.WriteLine("Hatalı Veri Girdiniz! Lütfen Tekrar Deneyiniz \n");
                return false;
            }
     
        }

        public static bool HesaplaYksPuan()
        {
            // TYT Değişkenler
            string tytTurkceDogruText;
            string tytTurkceYanlisText;
            string tytSosyalBilimlerDogruText;
            string tytSosyalBilimlerYanlisText;
            string tytTemelMatematikDogruText;
            string tytTemelMatematikYanlisText;
            string tytFenBilimleriDogruText;
            string tytFenBilimleriYanlisText;

            // AYT Değişkenler
            string aytTurkDiliEdebiyatiDogruText;
            string aytTurkDiliEdebiyatiYanlisText;
            string aytTarih1DogruText;
            string aytTarih1YanlisText;
            string aytCografya1DogruText;
            string aytCografya1YanlisText;
            string aytTarih2DogruText;
            string aytTarih2YanlisText;
            string aytCografya2DogruText;
            string aytCografya2YanlisText;
            string aytFelsefeDogruText;
            string aytFelsefeYanlisText;
            string aytDinKulturuFelsefeDogruText;
            string aytDinKulturuFelsefeYanlisText;
            string aytMatematikDogruText;
            string aytMatematikYanlisText;
            string aytFizikDogruText;
            string aytFizikYanlisText;
            string aytKimyaDogruText;
            string aytKimyaYanlisText;
            string aytBiyolojiDogruText;
            string aytBiyolojiYanlisText;

            // Yabancı Dil
            string yabanciDilDogruText;
            string yabanciDilYanlisText;

            // Diploma Notu/OBP Değişkeni
            string diplomaNotuText;

            // TYT Verileri Al
            Console.Write("TYT Türkçe Doğru (Toplam 40 soru): ");
            tytTurkceDogruText = Console.ReadLine();
            Console.Write("TYT Türkçe Yanlış: ");
            tytTurkceYanlisText = Console.ReadLine();
            Console.Write("TYT Sosyal Bilimler Doğru (Toplam 20 soru): ");
            tytSosyalBilimlerDogruText = Console.ReadLine();
            Console.Write("TYT Sosyal Bilimler Yanlış: ");
            tytSosyalBilimlerYanlisText = Console.ReadLine();
            Console.Write("TYT Temel Matematik Doğru (Toplam 40 soru): ");
            tytTemelMatematikDogruText = Console.ReadLine();
            Console.Write("TYT Temel Matematik Yanlış: ");
            tytTemelMatematikYanlisText = Console.ReadLine();
            Console.Write("TYT Fen Bilimleri Doğru (Toplam 20 soru): ");
            tytFenBilimleriDogruText = Console.ReadLine();
            Console.Write("TYT Fen Bilimleri Yanlış: ");
            tytFenBilimleriYanlisText = Console.ReadLine();

            // AYT Verileri Al
            Console.Write("AYT Türk Dili ve Edebiyatı Doğru (Toplam 24 soru): ");
            aytTurkDiliEdebiyatiDogruText = Console.ReadLine();
            Console.Write("AYT Türk Dili ve Edebiyatı Yanlış: ");
            aytTurkDiliEdebiyatiYanlisText = Console.ReadLine();
            Console.Write("AYT Tarih-1 Doğru (Toplam 10 soru): ");
            aytTarih1DogruText = Console.ReadLine();
            Console.Write("AYT Tarih-1 Yanlış: ");
            aytTarih1YanlisText = Console.ReadLine();
            Console.Write("AYT Coğrafya-1 Doğru (Toplam 6 soru): ");
            aytCografya1DogruText = Console.ReadLine();
            Console.Write("AYT Coğrafya-1 Yanlış: ");
            aytCografya1YanlisText = Console.ReadLine();
            Console.Write("AYT Tarih-2 Doğru (Toplam 11 soru): ");
            aytTarih2DogruText = Console.ReadLine();
            Console.Write("AYT Tarih-2 Yanlış: ");
            aytTarih2YanlisText = Console.ReadLine();
            Console.Write("AYT Coğrafya-2 Doğru (Toplam 11 soru): ");
            aytCografya2DogruText = Console.ReadLine();
            Console.Write("AYT Coğrafya-2 Yanlış: ");
            aytCografya2YanlisText = Console.ReadLine();
            Console.Write("AYT Felsefe Doğru (Toplam 12 soru): ");
            aytFelsefeDogruText = Console.ReadLine();
            Console.Write("AYT Felsefe Yanlış: ");
            aytFelsefeYanlisText = Console.ReadLine();
            Console.Write("AYT Din Kültürü/Felsefe Doğru (Toplam 6 soru): ");
            aytDinKulturuFelsefeDogruText = Console.ReadLine();
            Console.Write("AYT Din Kültürü/Felsefe Yanlış: ");
            aytDinKulturuFelsefeYanlisText = Console.ReadLine();
            Console.Write("AYT Matematik Doğru (Toplam 40 soru): ");
            aytMatematikDogruText = Console.ReadLine();
            Console.Write("AYT Matematik Yanlış: ");
            aytMatematikYanlisText = Console.ReadLine();
            Console.Write("AYT Fizik Doğru (Toplam 14 soru): ");
            aytFizikDogruText = Console.ReadLine();
            Console.Write("AYT Fizik Yanlış: ");
            aytFizikYanlisText = Console.ReadLine();
            Console.Write("AYT Kimya Doğru (Toplam 13 soru): ");
            aytKimyaDogruText = Console.ReadLine();
            Console.Write("AYT Kimya Yanlış: ");
            aytKimyaYanlisText = Console.ReadLine();
            Console.Write("AYT Biyoloji Doğru (Toplam 13 soru): ");
            aytBiyolojiDogruText = Console.ReadLine();
            Console.Write("AYT Biyoloji Yanlış: ");
            aytBiyolojiYanlisText = Console.ReadLine();

            // Yabancı Dil
            Console.Write("Yabancı Dil (İngilizce) Doğru (Toplam 80 soru): ");
            yabanciDilDogruText = Console.ReadLine();
            Console.Write("Yabancı Dil (İngilizce) Yanlış: ");
            yabanciDilYanlisText = Console.ReadLine();

            // Diploma Notu Al
            Console.Write("Diploma Notu veya OBP (50-100 arası Diploma Notu, 250-500 arası OBP, boş bırakabilirsiniz): ");
            diplomaNotuText = Console.ReadLine();

            if (int.TryParse(tytTurkceDogruText, out int tytTurkceDogruSayisi) &&
       int.TryParse(tytTurkceYanlisText, out int tytTurkceYanlisSayisi) &&
       int.TryParse(tytSosyalBilimlerDogruText, out int tytSosyalBilimlerDogruSayisi) &&
       int.TryParse(tytSosyalBilimlerYanlisText, out int tytSosyalBilimlerYanlisSayisi) &&
       int.TryParse(tytTemelMatematikDogruText, out int tytTemelMatematikDogruSayisi) &&
       int.TryParse(tytTemelMatematikYanlisText, out int tytTemelMatematikYanlisSayisi) &&
       int.TryParse(tytFenBilimleriDogruText, out int tytFenBilimleriDogruSayisi) &&
       int.TryParse(tytFenBilimleriYanlisText, out int tytFenBilimleriYanlisSayisi) &&
       int.TryParse(aytTurkDiliEdebiyatiDogruText, out int aytTurkDiliEdebiyatiDogruSayisi) &&
       int.TryParse(aytTurkDiliEdebiyatiYanlisText, out int aytTurkDiliEdebiyatiYanlisSayisi) &&
       int.TryParse(aytTarih1DogruText, out int aytTarih1DogruSayisi) &&
       int.TryParse(aytTarih1YanlisText, out int aytTarih1YanlisSayisi) &&
       int.TryParse(aytCografya1DogruText, out int aytCografya1DogruSayisi) &&
       int.TryParse(aytCografya1YanlisText, out int aytCografya1YanlisSayisi) &&
       int.TryParse(aytTarih2DogruText, out int aytTarih2DogruSayisi) &&
       int.TryParse(aytTarih2YanlisText, out int aytTarih2YanlisSayisi) &&
       int.TryParse(aytCografya2DogruText, out int aytCografya2DogruSayisi) &&
       int.TryParse(aytCografya2YanlisText, out int aytCografya2YanlisSayisi) &&
       int.TryParse(aytFelsefeDogruText, out int aytFelsefeDogruSayisi) &&
       int.TryParse(aytFelsefeYanlisText, out int aytFelsefeYanlisSayisi) &&
       int.TryParse(aytDinKulturuFelsefeDogruText, out int aytDinKulturuFelsefeDogruSayisi) &&
       int.TryParse(aytDinKulturuFelsefeYanlisText, out int aytDinKulturuFelsefeYanlisSayisi) &&
       int.TryParse(aytMatematikDogruText, out int aytMatematikDogruSayisi) &&
       int.TryParse(aytMatematikYanlisText, out int aytMatematikYanlisSayisi) &&
       int.TryParse(aytFizikDogruText, out int aytFizikDogruSayisi) &&
       int.TryParse(aytFizikYanlisText, out int aytFizikYanlisSayisi) &&
       int.TryParse(aytKimyaDogruText, out int aytKimyaDogruSayisi) &&
       int.TryParse(aytKimyaYanlisText, out int aytKimyaYanlisSayisi) &&
       int.TryParse(aytBiyolojiDogruText, out int aytBiyolojiDogruSayisi) &&
       int.TryParse(aytBiyolojiYanlisText, out int aytBiyolojiYanlisSayisi) &&
       int.TryParse(yabanciDilDogruText, out int yabanciDilDogruSayisi) &&
       int.TryParse(yabanciDilYanlisText, out int yabanciDilYanlisSayisi) &&
       double.TryParse(diplomaNotuText, out double diplomaNotu) &&

       // Soru sayısı kontrolleri
       (tytTurkceDogruSayisi + tytTurkceYanlisSayisi <= 40) &&
       (tytSosyalBilimlerDogruSayisi + tytSosyalBilimlerYanlisSayisi <= 20) &&
       (tytTemelMatematikDogruSayisi + tytTemelMatematikYanlisSayisi <= 40) &&
       (tytFenBilimleriDogruSayisi + tytFenBilimleriYanlisSayisi <= 20) &&
       (aytTurkDiliEdebiyatiDogruSayisi + aytTurkDiliEdebiyatiYanlisSayisi <= 24) &&
       (aytTarih1DogruSayisi + aytTarih1YanlisSayisi <= 10) &&
       (aytCografya1DogruSayisi + aytCografya1YanlisSayisi <= 6) &&
       (aytTarih2DogruSayisi + aytTarih2YanlisSayisi <= 11) &&
       (aytCografya2DogruSayisi + aytCografya2YanlisSayisi <= 11) &&
       (aytFelsefeDogruSayisi + aytFelsefeYanlisSayisi <= 12) &&
       (aytDinKulturuFelsefeDogruSayisi + aytDinKulturuFelsefeYanlisSayisi <= 6) &&
       (aytMatematikDogruSayisi + aytMatematikYanlisSayisi <= 40) &&
       (aytFizikDogruSayisi + aytFizikYanlisSayisi <= 14) &&
       (aytKimyaDogruSayisi + aytKimyaYanlisSayisi <= 13) &&
       (aytBiyolojiDogruSayisi + aytBiyolojiYanlisSayisi <= 13) &&
       (yabanciDilDogruSayisi + yabanciDilYanlisSayisi <= 80) &&

       // Diploma notu kontrolü (50-100 arası Diploma Notu, 250-500 arası OBP)
       ((diplomaNotu >= 50 && diplomaNotu <= 100) || (diplomaNotu >= 250 && diplomaNotu <= 500) || diplomaNotu == 0) &&

       // Negatif değer kontrolleri
       (tytTurkceDogruSayisi >= 0 && tytTurkceYanlisSayisi >= 0) &&
       (tytSosyalBilimlerDogruSayisi >= 0 && tytSosyalBilimlerYanlisSayisi >= 0) &&
       (tytTemelMatematikDogruSayisi >= 0 && tytTemelMatematikYanlisSayisi >= 0) &&
       (tytFenBilimleriDogruSayisi >= 0 && tytFenBilimleriYanlisSayisi >= 0) &&
       (aytTurkDiliEdebiyatiDogruSayisi >= 0 && aytTurkDiliEdebiyatiYanlisSayisi >= 0) &&
       (aytTarih1DogruSayisi >= 0 && aytTarih1YanlisSayisi >= 0) &&
       (aytCografya1DogruSayisi >= 0 && aytCografya1YanlisSayisi >= 0) &&
       (aytTarih2DogruSayisi >= 0 && aytTarih2YanlisSayisi >= 0) &&
       (aytCografya2DogruSayisi >= 0 && aytCografya2YanlisSayisi >= 0) &&
       (aytFelsefeDogruSayisi >= 0 && aytFelsefeYanlisSayisi >= 0) &&
       (aytDinKulturuFelsefeDogruSayisi >= 0 && aytDinKulturuFelsefeYanlisSayisi >= 0) &&
       (aytMatematikDogruSayisi >= 0 && aytMatematikYanlisSayisi >= 0) &&
       (aytFizikDogruSayisi >= 0 && aytFizikYanlisSayisi >= 0) &&
       (aytKimyaDogruSayisi >= 0 && aytKimyaYanlisSayisi >= 0) &&
       (aytBiyolojiDogruSayisi >= 0 && aytBiyolojiYanlisSayisi >= 0) &&
       (yabanciDilDogruSayisi >= 0 && yabanciDilYanlisSayisi >= 0))
                {
                // TYT Ham Puan Hesaplama
                double tytTurkceHamPuan = tytTurkceDogruSayisi - (tytTurkceYanlisSayisi / 4.0);
                double tytSosyalHamPuan = tytSosyalBilimlerDogruSayisi - (tytSosyalBilimlerYanlisSayisi / 4.0);
                double tytMatematikHamPuan = tytTemelMatematikDogruSayisi - (tytTemelMatematikYanlisSayisi / 4.0);
                double tytFenHamPuan = tytFenBilimleriDogruSayisi - (tytFenBilimleriYanlisSayisi / 4.0);

                // TYT Toplam Ham Puan
                double tytToplamHamPuan = tytTurkceHamPuan + tytSosyalHamPuan + tytMatematikHamPuan + tytFenHamPuan;

                // AYT Ham Puan Hesaplama
                double aytEdebiyatHamPuan = aytTurkDiliEdebiyatiDogruSayisi - (aytTurkDiliEdebiyatiYanlisSayisi / 4.0);
                double aytTarih1HamPuan = aytTarih1DogruSayisi - (aytTarih1YanlisSayisi / 4.0);
                double aytCografya1HamPuan = aytCografya1DogruSayisi - (aytCografya1YanlisSayisi / 4.0);
                double aytTarih2HamPuan = aytTarih2DogruSayisi - (aytTarih2YanlisSayisi / 4.0);
                double aytCografya2HamPuan = aytCografya2DogruSayisi - (aytCografya2YanlisSayisi / 4.0);
                double aytFelsefeHamPuan = aytFelsefeDogruSayisi - (aytFelsefeYanlisSayisi / 4.0);
                double aytDinHamPuan = aytDinKulturuFelsefeDogruSayisi - (aytDinKulturuFelsefeYanlisSayisi / 4.0);
                double aytMatematikHamPuan = aytMatematikDogruSayisi - (aytMatematikYanlisSayisi / 4.0);
                double aytFizikHamPuan = aytFizikDogruSayisi - (aytFizikYanlisSayisi / 4.0);
                double aytKimyaHamPuan = aytKimyaDogruSayisi - (aytKimyaYanlisSayisi / 4.0);
                double aytBiyolojiHamPuan = aytBiyolojiDogruSayisi - (aytBiyolojiYanlisSayisi / 4.0);

                // Yabancı Dil Ham Puan
                double yabanciDilHamPuan = yabanciDilDogruSayisi - (yabanciDilYanlisSayisi / 4.0);

                // TYT Puanı (Yaklaşık katsayılar)
                double tytPuani = (tytToplamHamPuan * 5.0) + 100;

                // AYT Puanları (Yaklaşık katsayılar - gerçek katsayılar ÖSYM tarafından her yıl güncellenir)
                double aytSayisalPuan = (aytMatematikHamPuan * 3.0) + (aytFizikHamPuan * 2.8) + (aytKimyaHamPuan * 2.7) + (aytBiyolojiHamPuan * 2.6) + 100;
                double aytSozelPuan = (aytEdebiyatHamPuan * 3.5) + (aytTarih1HamPuan * 3.2) + (aytCografya1HamPuan * 3.0) + 100;
                double aytEsitAgirlikPuan = (aytMatematikHamPuan * 3.2) + (aytEdebiyatHamPuan * 3.0) + (aytTarih1HamPuan * 2.8) + (aytCografya1HamPuan * 2.6) + 100;
                double aytDilPuan = yabanciDilHamPuan * 6.0 + 100;

                // Yerleştirme Puanları (Diploma notu dahil)
                double diplomaKatkisi = 0;
                if (diplomaNotu >= 50 && diplomaNotu <= 100)
                {
                    diplomaKatkisi = diplomaNotu * 5; // Diploma notunu OBP'ye çevir
                }
                else if (diplomaNotu >= 250 && diplomaNotu <= 500)
                {
                    diplomaKatkisi = diplomaNotu;
                }

                double sayisalYerlestirmePuan = (aytSayisalPuan * 0.6) + (tytPuani * 0.4) + (diplomaKatkisi * 0.06);
                double sozelYerlestirmePuan = (aytSozelPuan * 0.6) + (tytPuani * 0.4) + (diplomaKatkisi * 0.06);
                double esitAgirlikYerlestirmePuan = (aytEsitAgirlikPuan * 0.6) + (tytPuani * 0.4) + (diplomaKatkisi * 0.06);
                double dilYerlestirmePuan = (aytDilPuan * 0.6) + (tytPuani * 0.4) + (diplomaKatkisi * 0.06);

                // Çıktı
                Console.WriteLine($"TYT SONUÇLARI\n" +
                    $"Türkçe Ham Puan: {tytTurkceHamPuan:F2}\n" +
                    $"Sosyal Bilimler Ham Puan: {tytSosyalHamPuan:F2}\n" +
                    $"Temel Matematik Ham Puan: {tytMatematikHamPuan:F2}\n" +
                    $"Fen Bilimleri Ham Puan: {tytFenHamPuan:F2}\n" +
                    $"TYT Toplam Ham Puan: {tytToplamHamPuan:F2}\n" +
                    $"TYT Puanı: {tytPuani:F2}\n\n" +

                    $"AYT SONUÇLARI\n" +
                    $"T. Dili ve Edebiyatı Ham Puan: {aytEdebiyatHamPuan:F2}\n" +
                    $"Matematik Ham Puan: {aytMatematikHamPuan:F2}\n" +
                    $"Fizik Ham Puan: {aytFizikHamPuan:F2}\n" +
                    $"Kimya Ham Puan: {aytKimyaHamPuan:F2}\n" +
                    $"Biyoloji Ham Puan: {aytBiyolojiHamPuan:F2}\n" +
                    $"Tarih-1 Ham Puan: {aytTarih1HamPuan:F2}\n" +
                    $"Coğrafya-1 Ham Puan: {aytCografya1HamPuan:F2}\n" +
                    $"Felsefe Ham Puan: {aytFelsefeHamPuan:F2}\n\n" +

                    $"PUAN TÜRLERİ\n" +
                    $"AYT Sayısal Puan: {aytSayisalPuan:F2}\n" +
                    $"AYT Sözel Puan: {aytSozelPuan:F2}\n" +
                    $"AYT Eşit Ağırlık Puan: {aytEsitAgirlikPuan:F2}\n" +
                    $"AYT Dil Puan: {aytDilPuan:F2}\n\n" +

                    $"YERLEŞTIRME PUANLARI (Diploma Notu Dahil)\n" +
                    $"Sayısal Yerleştirme Puanı: {sayisalYerlestirmePuan:F2}\n" +
                    $"Sözel Yerleştirme Puanı: {sozelYerlestirmePuan:F2}\n" +
                    $"Eşit Ağırlık Yerleştirme Puanı: {esitAgirlikYerlestirmePuan:F2}\n" +
                    $"Dil Yerleştirme Puanı: {dilYerlestirmePuan:F2}");

                return true;
            }
                else
                {
                    Console.WriteLine("Geçersiz veri girişi! Lütfen değerleri kontrol edin.");
                return false;
                }



        }

        // Veri Al ve Kontrol Et
        public static bool KrediInputAlVeKontrolEt(string krediTipi)
        {
            string anaParaText;
            string faizOraniText;
            string vadeAyText;
            double anaPara;
            double faizOrani;
            int vadeAy;
            
            Console.WriteLine("Ana Para : ");
            anaParaText = Console.ReadLine();
            Console.WriteLine("Faiz Oranı : ");
            faizOraniText = Console.ReadLine();
            Console.WriteLine("Vade Ay : ");
            vadeAyText = Console.ReadLine();

            if (double.TryParse(anaParaText, out anaPara) &&
                double.TryParse(faizOraniText, out faizOrani) &&
                int.TryParse(vadeAyText, out vadeAy) &&
                anaPara > 0 && faizOrani > 0 && vadeAy > 0)
            {
                switch (krediTipi)
                {
                    case "1": HesaplaIhtiyacKredisi(anaPara, faizOrani, vadeAy); break;
                    case "2": HesaplaIsYeriKredisi(anaPara, faizOrani, vadeAy); break;
                    case "3": HesaplaKonutKredisi(anaPara, faizOrani, vadeAy); break;
                }
                return true;
            }
            else
            {
                Console.WriteLine("Hatalı Giriş!");
                return false;
            }

        }


        static void Main(String[] args)
        {
            // Değişkenler
            bool isOnline = true;
            string anaKategori;
            string krediKategori;
            string sinavKategori;
           

            while (isOnline)
            {
                Console.WriteLine("İşlem yapmak için bir sayı giriniz:\nÇıkış: 0\nKredi: 1\nFinans: 2\nSınav: 3");
                anaKategori = Console.ReadLine();

                switch (anaKategori)
                {
                    case "0": Console.WriteLine("Çıkış Yapılıyor"); isOnline = false; break;
                    case "1":Console.WriteLine("Kredi Seçildi");

                    Console.WriteLine("İşlem yapmak için bir sayı giriniz:\nÇıkış: 0 \nİhtiyaç Kredisi: 1\nİş Yeri Kredisi: 2\nKonut Kredisi: 3");

                    krediKategori = Console.ReadLine();

                        switch (krediKategori)
                        {
                            case "0": break;
                            case "1":
                                do
                                {
                                   if (KrediInputAlVeKontrolEt(krediKategori)){ break; }
                                   
                                }
                                while (true); break;
                            case "2":
                                do
                                {
                                    if (KrediInputAlVeKontrolEt(krediKategori)) { break; }
                                }
                                while (true); break;

                            case "3":
                                do
                                {
                                    if (KrediInputAlVeKontrolEt(krediKategori)) { break; }
                                }
                                while (true); break;
                        }break;
                       
      
                    case "2": Console.WriteLine("Finans Seçildi");

                        Console.WriteLine("Iban Giriniz :");
                        string iban = Console.ReadLine().Replace(" ", "").ToUpper();

                        string ibanUlkeKodu = iban.Substring(0, 2);
                        iban = iban.Substring(2);
                        string kontrolHanesi = iban.Substring(0, 2);

                        Dictionary<string, string> harfDonusturmeTablosu = new Dictionary<string, string>
                                {
                                    { "A", "10" },
                                    { "B", "11" },
                                    { "C", "12" },
                                    { "D", "13" },
                                    { "E", "14" },
                                    { "F", "15" },
                                    { "G", "16" },
                                    { "H", "17" },
                                    { "I", "18" },
                                    { "J", "19" },
                                    { "K", "20" },
                                    { "L", "21" },
                                    { "M", "22" },
                                    { "N", "23" },
                                    { "O", "24" },
                                    { "P", "25" },
                                    { "Q", "26" },
                                    { "R", "27" },
                                    { "S", "28" },
                                    { "T", "29" },
                                    { "U", "30" },
                                    { "V", "31" },
                                    { "W", "32" },
                                    { "X", "33" },
                                    { "Y", "34" },
                                    { "Z", "35" }
                                };

                        foreach (var karakter in ibanUlkeKodu)
                        {
                            if (harfDonusturmeTablosu.ContainsKey(karakter.ToString()))
                            {
                                iban = String.Concat(iban, harfDonusturmeTablosu[karakter.ToString()]);
                            }
                        }
                        iban = String.Concat(iban, kontrolHanesi);
                        iban = iban.Substring(2);

                         BigInteger ibanSayisi =  BigInteger.Parse(iban);

                      if (ibanSayisi % 97 == 1)
                        {
                            Console.WriteLine("Iban Geçerli\n");
                        }
                        else
                        {
                            Console.WriteLine("Iban Geçersiz\n");
                        } break;


                    case "3":

                        

                        Console.WriteLine("İşlem yapmak için bir sayı giriniz:\nÇıkış: 0 \nDgs Puan Hesaplama: 1\nYks Puan Hesaplama: 2\n");      
                        sinavKategori = Console.ReadLine();
                        switch (sinavKategori)
                        {
                            case "0": break;
                            case "1":
                                do
                                {
                                    if (HesaplaDgsPuan()) { break; }
                                }
                                while (true);break;

                            case "2":
                                do
                                {
                                    if (HesaplaYksPuan()) { break; }
                                }
                                while (true);break;
                        }

                        break;

                }
            }


  
    }
}
}