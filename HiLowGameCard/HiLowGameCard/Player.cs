
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowGameCard
{
    class Player
    {
        private List<Card> pile;
        private string name;
        private Card recentCard; 
        private int winningDeck;

        public string Name { get { return name; } }
        public int Score { get { return winningDeck; } }
        public Card RecentCard { get { return recentCard; } }
        public List<Card> Pile { get { return pile; } }

        public Player(string n,int i,Deck d) 
        {
            name = n;
            pile = new List<Card>(d.CardDeck.Count/2);
            
            for(int c=0 ; c < d.CardDeck.Count/2 ; i++,c++)   
            {
                pile.Add(d.CardDeck[i]);
            }
        }

        public void Deal(int cardRank = 1)     
        {
            recentCard = pile[cardRank-1];    
            Console.Write(name + ":" + recentCard.GetName() + "   \t");
        }

        public void Take(int amount = 1)
        {
            winningDeck += amount*2;
        }

        public void Remove(int amount = 1)
        {
            pile.RemoveRange(0, amount);
        }

        public void Shuffle()
        {
            for (int i = 0; i < pile.Count; i++)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());
                int j = rand.Next(0, pile.Count);
                Card A = pile[j];
                pile[j] = pile[i];
                pile[i] = A;
            }
        }

        public void PilePrint() 
        {
            Console.WriteLine("\n");
            for (int i = 0; i < pile.Count; i++)
            {
                Console.Write(i + pile[i].GetName() + "    \t");
                if (i != 0 && (i + 1) % 2 == 0) { Console.Write("\n"); }
            }
            Console.WriteLine("\n");
        }
    }
}
