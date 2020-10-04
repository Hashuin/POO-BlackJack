using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{

    public class Dealer : User
    {
        private List<Card> deck;
        public List<Card> Deck { get => deck; set => deck = value; }
        

        public void Generate()
        {
            deck = new List<Card>();
            Hand = new List<Card>();
            char[] suits = {'♦','♣','♥','♠' };
            string[] symbols = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

            foreach (char s in suits)
            {
                foreach (string sy in symbols)
                {
                    Card c = new Card(s, sy);
                    deck.Add(c);
                }
            }
        }

        public void Randomize()
        {
            Random rnd = new Random();
            this.deck = deck.OrderBy(x => rnd.Next()).ToList();

        }

        public Card Deal()
        {
            
            Card c = deck.First();
            deck.Remove(c);
            return c; 
        }


        public void Init()
        {
            AddCard(Deal());
            AddCard(Deal());
        }
    }   
}
