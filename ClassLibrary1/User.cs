using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class User
    {

        List<Card> hand = new List<Card>();
        public List<Card> Hand { get => hand; set => hand = value; }


        public void AddCard(Card c)
        {
            hand.Add(c);
        }

    }
}
