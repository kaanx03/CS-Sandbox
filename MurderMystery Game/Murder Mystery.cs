namespace VampirKöylü
{

    internal class Program
    {
        // Fisher-Yates Shuffle Algoritması
        static void Shuffle<T>(List<T> list)   
        {
            Random rnd = new();
            int remainingCount = list.Count;  
            while(remainingCount > 1)
            {
                remainingCount--;  
                int randomIndex = rnd.Next(remainingCount + 1);  

                (list[randomIndex], list[remainingCount]) = (list[remainingCount], list[randomIndex]);
            }

        }


        static List<string> createRoleList(int totalPlayer)
        {
            List<string> roleList = new();
            if (totalPlayer == 5) { roleList = new() { "Vampire", "Vampire", "Villager", "Villager","Doctor" }; }
            if (totalPlayer == 6) { roleList = new() { "Vampire", "Vampire", "Villager", "Villager","Doctor","Hunter" }; }
            if (totalPlayer == 7) { roleList = new() { "Vampire", "Vampire", "Villager","Villager", "Villager","Doctor","Hunter" }; }
            if (totalPlayer == 8) { roleList = new() { "Vampire", "Vampire","Vampire","Villager","Villager","Villager","Doctor","Hunter" }; }
            if(totalPlayer >= 9)
            {
                int vampireCount = totalPlayer / 3;
                int villagerCount = totalPlayer - vampireCount - 2;

                for(int i =0; i < vampireCount; i++) { roleList.Add("Vampire"); }

                roleList.Add("Doctor");
                roleList.Add("Hunter");

                for(int i = 0; i < villagerCount; i++) { roleList.Add("Villager"); }

            }
            Shuffle(roleList);

            return roleList;
            
        }


        static void NightPhase(List <Player> players)
        {
            Console.WriteLine("Night Phase...");

           
            bool vampireExist = false;
            bool doctorExist = false;
            bool hunterExist = false;
            string vampireChoice = "";
            string doctorChoice = "";
            string hunterChoice = "";
            bool vampChoiceExist = false;
            bool docChoiceExist = false;
            bool huntChoiceExist = false;

            // Eğer roller var ise onlara kimi öldürmek iyileştirmek istediklerini sor
            foreach (var player in players)
            {
                if (player.Role == "Vampire")
                    vampireExist = true;
                if (player.Role == "Doctor")
                    doctorExist = true;
                if (player.Role == "Hunter")
                    hunterExist = true;
            }

            if (vampireExist)
            {
                Console.WriteLine("**VAMPIRES** :Choose who you want to kill : ");
                foreach(var player in players)
                {
                    if(player.Role != "Vampire") {
                        Console.WriteLine(player.Name);
                    }
                }

                do {
                    vampireChoice = Console.ReadLine().ToLower();
                    

                    foreach(var player in players)
                    {
                        if(vampireChoice == player.Name && player.Role != "Vampire")
                        {
                            vampChoiceExist = true;
                        }                    
                    }
                    if (!vampChoiceExist)
                    {
                        Console.Write("This player doesn't exist or it's vampire try another name : ");
                    }
                }
                while (!vampChoiceExist);

                 
            }

            if (doctorExist)
            {
                Console.WriteLine("**DOCTOR** :Choose who you want to heal : ");
                foreach (var player in players)
                {
                        Console.WriteLine(player.Name);
                }
                do
                {
                    doctorChoice = Console.ReadLine().ToLower();
                    foreach (var player in players)
                    {
                        if(doctorChoice == player.Name)
                        {
                            docChoiceExist = true;
                        }
                    }
                    if (!docChoiceExist)
                    {
                        Console.Write("This player doesn't exist try another name : ");
                    }


                } while (!docChoiceExist);
            }

            if (hunterExist)
            {
                Console.WriteLine("**HUNTER** :Choose who you want to learn their role : ");
                foreach (var player in players)
                {
                    Console.WriteLine(player.Name);
                }
                do
                {
                    hunterChoice = Console.ReadLine().ToLower();
                    foreach (var player in players)
                    {
                        if (hunterChoice == player.Name)
                        {
                            huntChoiceExist = true;
                        }
                    }
                    if (!huntChoiceExist)
                    {
                        Console.Write("This player doesn't exist try another name : ");
                    }


                } while (!huntChoiceExist);

            }

            // Tamam farz edelim vampir öldüreceği kişiyi seçti 2 olasılık var ya öldürür yani player.isAlive = false 
            // Eğer vampirin öldürmeyi seçtiği kişi ile doktorun iyileştirmeyi seçtiği kişi aynı ise bişey yapılmaz.

            if(doctorChoice == vampireChoice && doctorExist && vampireExist)
            {
                Console.WriteLine("Doctor saved the victim!");
            }
            else
            {
                foreach(var player in players){

                    if(vampireChoice == player.Name)
                    {
                        player.Alive = false;
                        Console.WriteLine($"{player.Name} is dead");
                    }
            }
        }

            // Avcının Seçimini yerine getirelim
            if (hunterExist)
            {
                foreach(var player in players)
                {
                    if(hunterChoice == player.Name)
                    {
                        Console.WriteLine($"Role of the {player.Name} is : {player.Role}!");
                    }
                }
            }



       }

        static void DayPhase(List <Player> players)
        {
            Console.WriteLine("Day Phase..");
            // Yaşayan oyuncuları yazdır ve birbirlerine oy kullanmalarını iste

            Dictionary<string, int> alivePlayers = new();
            string vote;

            // Her oyuncuyu alivePlayers dictionarysine koyuyoruz ["kaan",0] şeklinde yanlarında da oyları var
            foreach(var player in players)
            {
                if (player.Alive)
                {
                    alivePlayers.Add(player.Name,0);
                }
            }

           for(int i =0; i < alivePlayers.Count; i++)
            {
                Console.Write("Who do you think is the vampire : ");
                vote = Console.ReadLine();

                if (alivePlayers.ContainsKey(vote))
                {
                    alivePlayers[vote] += 1;
                }
                else
                {
                    Console.WriteLine("Player doesn't exist");
                    i--;
                }
            }

            // Oyları yazdır  

            Console.WriteLine("\nOy Sonuçları : ");
            foreach( var player in alivePlayers)
            {
                Console.WriteLine($"{player.Key} : {player.Value} oy");
            }

            // En çok oy alanı bulup As

            var mostVoted = alivePlayers.OrderByDescending(x => x.Value).First();

            foreach (var player in players)
            {
                if (mostVoted.Key == player.Name)
                {
                    player.Alive = false;
                    Console.WriteLine($"{player.Name} Asıldı!");
                }
            }






        }

        static bool CheckWinCondition(List <Player> players)
        {
            // Eğer vampir kalmamışsa oyun kazanıldı demektir. 
            int aliveVampire = 0;
            foreach(var player in players)
            { 
                if(player.Role == "Vampire" && player.Alive == true)
                {
                    aliveVampire++;
                }
            }
            
            if(aliveVampire == 0)
            {
                Console.WriteLine("All vampires are dead! Villagers have won!!");
                return true;
            }
            else
            {
                Console.WriteLine("Game continues..");
                return false;
            }
       
            


        }

        static void Main(string[] args)
        {

            List<string> roleList = new();

            List<Player> players = new();

            Random rnd = new();

            bool gameOver = false;


            string playerName = "";
            string playerRole = "";

            bool validTotalPlayer = false;
            bool validPlayerName;
            int totalPlayer = 0;

            while (!validTotalPlayer)
            {
                // Oyuncu sayısını öğren
                Console.WriteLine("How many players there will be (min 5) : ");
                totalPlayer = Convert.ToInt32(Console.ReadLine());
                if(totalPlayer > 4) { validTotalPlayer = true; }
            }


            // Oyuncuların sayısına göre isimleri al
            for (int i = 1; i <= totalPlayer; i++)
            {
                validPlayerName = false; 
                while (!validPlayerName)
                {
                    Console.Write($"Enter the name of the {i}. player : ");
                    playerName = Console.ReadLine().ToLower();

                    // İsim kontrolü 
                    bool nameExists = false;
                    foreach (var player in players)
                    {
                        if (playerName == player.Name)
                        {
                            nameExists = true;
                            break;
                        }
                    }

                    if (nameExists)
                    {
                        Console.WriteLine("This player exists!");
                    }
                    else
                    {
                        Player newPlayer = new(playerName, playerRole, true);
                        players.Add(newPlayer);
                        validPlayerName = true;
                    }
                }
            }

            // Dengeli bir rol listesi oluştur
            roleList = createRoleList(totalPlayer);
            
            // Oyunculara rolleri ata
            for(int i = 0; i < totalPlayer; i++)
            {
                players[i].Role = roleList[i];
            }

            Console.WriteLine("\n=== ROLE ASSIGNMENTS ===");
            foreach(var player in players)
            {
                Console.WriteLine($"Player : {player.Name} | Role : {player.Role}");
            }

            bool isNight = true;

            // Oyunu başlat
            while (!gameOver)
            {
                NightPhase(players);
                DayPhase(players);
                gameOver = CheckWinCondition(players);
            }





        }
    }

    class Player
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public bool Alive { get; set; }

        public Player(string playerName, string playerRole, bool playerAlive)
        {
            Name = playerName;
            Role = playerRole;
            Alive = playerAlive;
        }      
    }    
}
