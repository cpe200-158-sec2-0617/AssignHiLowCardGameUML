using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowGameCard
{
    class Game
    {
        private Player player1,player2;
        private Deck deck;

        public Game()
        {
            Setup();
            CardPlay();
        }

        private void Setup()
        {
            int Nplayer;
            Console.Write("How many deck? :");

            try { Nplayer = Convert.ToInt32(Console.ReadLine()); }
            catch(Exception e) { Nplayer = 1; }

            deck = new Deck(Nplayer);

            string name1, name2;
            Console.Write("Enter Player 1 name:");
            name1 = Console.ReadLine();
            player1 = new Player(name1, 0, deck);

            Console.Write("Enter Player 2 name:");
            name2 = Console.ReadLine();
            player2 = new Player(name2, 26, deck);

        }

        private void CardPlay()
        {
            while (player1.Pile.Count > 0 && player2.Pile.Count > 0)
            {
                player1.Deal();
                player2.Deal();
                Console.WriteLine(Compare());
                Console.ReadKey();
            }
                
            if (player1.Score > player2.Score)
            {
                Console.WriteLine("\t\t\t\t\t\t{0} (Player 1) wins!", player1.Name);
            }
            else if (player1.Score < player2.Score)
            {
                Console.WriteLine("\t\t\t\t\t\t{0} (Player 2) wins!", player2.Name);
            }
            else
            {
                Console.WriteLine("\t\t\t\t\t\t Tie!");

            }
            Console.WriteLine("\n\t\t\t\t\t\t Press Any Key to Exit");
        }

        public string Compare(int r=1)
        {
            string winner="";
            
            if (r == 1)
            {
                if (player1.RecentCard.Rank < player2.RecentCard.Rank)   
                {
                    player1.Take();
                    player1.Remove();
                    player2.Remove();
                    winner = player1.Name + " wins.  " + player1.Name + ":" + player1.Score + "  " + player2.Name + ":" + player2.Score;
                }
                else if (player1.RecentCard.Rank > player2.RecentCard.Rank)
                {
                    player2.Take();
                    player1.Remove();
                    player2.Remove();
                    winner = player2.Name + " wins.  " + player1.Name + ":" + player1.Score + "  " + player2.Name + ":" + player2.Score;
                }
                else if (player1.RecentCard.Rank == player2.RecentCard.Rank)
                {
                    Console.WriteLine("Draw!");
                    int drewCard = player1.RecentCard.Rank;
                    if (drewCard < player1.Pile.Count || drewCard < player2.Pile.Count)
                    {
                        player1.Deal(player1.RecentCard.Rank + 1);
                        player2.Deal(player2.RecentCard.Rank + 1);
                        Console.Write(Compare(drewCard));
                    }
                    else if (player1.Pile.Count!=1 && player2.Pile.Count!=1)
                    {
                        Console.WriteLine("Not enough cards to play. Shuffling>>>");
                        player1.Shuffle();
                        player2.Shuffle();
                        Console.WriteLine("\nPress Any Key to Continue");
                    }
                    else
                    {
                        Console.WriteLine("\t\t\t\t\tIt is the last card. Game is ending.");
                        player1.Remove();
                        player2.Remove();
                    }
                }
            }
            
            else
            {
                if (player1.RecentCard.Rank < player2.RecentCard.Rank)
                {
                    player1.Take(r + 1);
                    player1.Remove(r + 1);
                    player2.Remove(r + 1);
                    winner = player1.Name + " wins.  " + player1.Name + ":" + player1.Score + "  " + player2.Name + ":" + player2.Score;
                }
                
                else if (player1.RecentCard.Rank > player2.RecentCard.Rank)
                {
                    player2.Take(r + 1);
                    player1.Remove(r + 1);
                    player2.Remove(r + 1);
                    winner = player2.Name + " wins.  " + player1.Name + ":" + player1.Score + "  " + player2.Name + ":" + player2.Score;
                }
                
                else if (player1.RecentCard.Rank == player2.RecentCard.Rank)
                {
                    Console.WriteLine("Tie again! Shuffling>>>");
                    player1.Shuffle();
                    player2.Shuffle();
                    Console.WriteLine("\nPress Any Key to Continue");
                }
            }
            return winner;
        }
        
    }
}
