using System;
namespace deck_of_cards
{
    class Card 
    {
        string stringVal;
        string suit;
        int val;

        public string StringVal
        {
            get { return stringVal; }
        }

        public string Suit
        {
            get { return suit; }
        }

        public int Val 
        {
            get { return val; }
            set { val = value; }
        }

        public Card(string strVal, string whatSuit, int value)
        {
            stringVal = strVal;
            suit = whatSuit;
            val = value;
        }
        
        public string DisplayCard() {
            return $"{stringVal} of {suit}";
        }
    }
    
}
