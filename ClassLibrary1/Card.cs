﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Card
    {
        private char suit;
        private string symbol;
        private int score;
        private string color;

        public char Suit { get => suit; set => suit = value; }

        public string Symbol { get => symbol; set => symbol = value; }

        public int Score { get => score; set => score = value; }

        public string Color { get => color; set => color = value; }

        public Card(char suit, string symbol)
        {
            this.suit = suit;
            this.symbol = symbol;

            if (suit.Equals("♥") || suit.Equals("♦"))
            {
                this.color = ("red");
            }
            else
            {
                this.color = ("black");
            }
                int value;
            try
            {

                value = Convert.ToInt32(symbol);

            }catch(FormatException)
            {
                if(symbol == ("A"))
                {
                    value = 11;
                }
                else
                {
                    value = 10;
                }
            }
             this.score = value;








        }
    }
}
