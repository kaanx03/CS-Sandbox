namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Destede 1-2-3-4-5-6-7-8-9-10(king queen) ve As: 1 veya 11



            string winner = "";

            List<int> desteListesi = new() { 1,2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }; // Şimdilik 11 eleman var gibi düşünelim
            List<int> oyuncuEli= new();
            List<int> kasaEli = new();

            int oyuncuEliToplam = 0;
            int kasaEliToplam = 0;

            string oyuncuSecimi;
            bool oyunBitti = false;
            int oyuncuRandomKart;
            int kasaRandomKart;

            Random rnd = new();


            Console.WriteLine("Kartlar dağıtılıyor..");

            for(int i=0; i < 2; i++)
            {
                oyuncuRandomKart = rnd.Next(11);
                kasaRandomKart = rnd.Next(11);
                oyuncuEli.Add(desteListesi[oyuncuRandomKart]);
                kasaEli.Add(desteListesi[kasaRandomKart]);
                oyuncuEliToplam += desteListesi[oyuncuRandomKart];
                kasaEliToplam += desteListesi[kasaRandomKart];
            }

            while (!oyunBitti)
            {
            // Kasa Kartları ve Toplam Ekrana Yazdır
             Console.Write("\n******************\nKasa : ");
            foreach(int kasaKart in kasaEli)
                {
                    Console.Write(kasaKart+",");
                }
                Console.WriteLine($"Kasa Toplam :{kasaEliToplam} \n");

            // Oyuncu Kartları ve Toplam Ekrana Yazdır
            Console.Write("\n******************\nOyuncu : ");
            foreach(int oyuncuKart in oyuncuEli)
                {
                    Console.Write(oyuncuKart + ",");
                }
                Console.WriteLine($"Oyuncu Toplam:{oyuncuEliToplam}\n");


            etiket:
                // Oyuncu kart toplam 21 olma(kazanma veya berabere) durumu --------------------------------------------------------------------
                if (oyuncuEliToplam == 21 && kasaEliToplam > 21)  // Oyuncu 21 Kasa 22
                {
                    winner = "Oyuncu";

                }

                else if (oyuncuEliToplam == 21 && kasaEliToplam == 21) { // Oyuncu 21 Kasa 21
                    winner = "Berabere";
                }

                else if (oyuncuEliToplam == 21 && kasaEliToplam >= 17 && kasaEliToplam != 21) // Oyuncu 21 Kasa 18 (17 veya büyük ama 21 değil)
                {
                    winner = "Oyuncu";
                }

                else if (oyuncuEliToplam == 21 && kasaEliToplam < 17)  // Oyuncu 21 Kasa 17den küçük => Kasa kart çekiyor 21e tamamlarsa berabere
                {
                    bool kasaCek = true;
                    while (kasaCek)
                    {
                        kasaEliToplam += desteListesi[rnd.Next(11)];
                        Console.WriteLine($"Kasa Toplam :{kasaEliToplam} ");
                        if (kasaEliToplam >= 17)
                        {
                            kasaCek = false;
                            if (kasaEliToplam == 21) {
                                winner = "Berabere";
                            }
                            else
                            {
                                winner = "Oyuncu";
                            }
                        }
                    }
                }
            // -----------------------------------------------------------------------------------------------------------------------
            // Kasa kart toplam 21 olma (kazanma veya berabere) durumu
            
            if(kasaEliToplam == 21 && oyuncuEliToplam > 21){ winner = "Kasa"; }

            else if(kasaEliToplam == 21 && oyuncuEliToplam < 21)   // Kasa 21 Oyuncu 21den düşük ise
                {
                    bool oyuncuCek = true;
                    while (oyuncuCek)
                    {
                        oyuncuEliToplam += desteListesi[rnd.Next(11)];
                        Console.WriteLine($"Oyuncu Toplam : {oyuncuEliToplam}");
                        if(oyuncuEliToplam == 21)
                        {
                            winner = "Berabere";
                            oyuncuCek = false;
                        }
                        else if (oyuncuEliToplam > 21)
                        {
                            winner = "Kasa";
                            oyuncuCek = false;
                        }
                    }
                }

            // Kasa 21den fazla olması Oyuncu 21den fazla olması

            if(kasaEliToplam > 21 && oyuncuEliToplam > 21) { winner = "Berabere"; }
             
            // Kasa 21den küçük Oyuncu 21den büyük
            if(kasaEliToplam < 21 && oyuncuEliToplam > 21) { winner = "Kasa"; }

            // Oyuncu 21den küçük Kasa 21den büyük
            if(oyuncuEliToplam < 21 && kasaEliToplam > 21) { winner = "Oyuncu"; }

           
            // **** KASA VE OYUNCU 21'DEN KÜÇÜK ****

            if(oyuncuEliToplam < 21 && kasaEliToplam < 21)
                {
                    Console.WriteLine("Kart çekmek istiyor musun Hayır: 0 Evet : 1");
                    oyuncuSecimi = Console.ReadLine();

                    if(oyuncuSecimi == "1")
                    {
                        oyuncuRandomKart = rnd.Next(11);
                        oyuncuEliToplam += desteListesi[oyuncuRandomKart];
                        oyuncuEli.Add(desteListesi[oyuncuRandomKart]);
                   

                        if(oyuncuEliToplam > 21) { winner = "Kasa"; }
                        else if(oyuncuEliToplam == 21) { goto etiket; }

                    }

                    if(oyuncuSecimi != "1") {
                  
                        if (kasaEliToplam > oyuncuEliToplam) { winner = "Kasa"; }

                        else if (kasaEliToplam < oyuncuEliToplam)
                        {
                        etiket2:
                            kasaRandomKart = rnd.Next(11);
                            kasaEliToplam += desteListesi[kasaRandomKart];
                            kasaEli.Add(desteListesi[kasaRandomKart]);
                            Console.WriteLine($"Kasa Toplam:{kasaEliToplam}");
                            if (kasaEliToplam > oyuncuEliToplam && kasaEliToplam <= 21) { winner = "Kasa"; }
                            else if (kasaEliToplam > oyuncuEliToplam && kasaEliToplam > 21) { winner = "Oyuncu"; }
                            else { goto etiket2; }
                        }
                    
                    }


                }
                
            if(winner == "Kasa" || winner=="Oyuncu" || winner == "Berabere") { oyunBitti = true; }

          



            }
            if(winner == "Oyuncu")
            {
                Console.WriteLine($"Oyuncu Kazandı!");
            }
            else if(winner == "Kasa")
            {
                Console.WriteLine("Kasa Kazandı!");
            }
            else
            {
                Console.WriteLine("Berabere!");
            }
            Console.WriteLine($"Oyuncu: {oyuncuEliToplam} Kasa: {kasaEliToplam}");



        }


    }
}
