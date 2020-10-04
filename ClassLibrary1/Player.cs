using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Player : User
    {

        public void Init(Card c1, Card c2)
        {
            AddCard(c1);
            AddCard(c2); 
        }
    }
}
