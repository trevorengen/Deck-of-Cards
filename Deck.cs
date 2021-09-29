using System;
using System.Collections.Generic;
using System.Linq;
namespace deck_of_cards
{
    class Deck 
    {
        List<Card> cards;

        public Deck()
        {
            string[] strVals = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
            string[] suits = {"Clubs", "Spades", "Diamonds", "Hearts"};
            cards = new List<Card>();
            foreach (string suit in suits) {
                for (int i=1; i<=strVals.Length; i++) {
                    int val = i;
                    if (i == 1) {
                        val = 11;
                    }
                    if (i > 10) {
                        val = 10;
                    }
                    Card newCard = new Card(strVals[i-1], suit, val);
                    cards.Add(newCard);
                }
            }
        }

        public Card Deal() 
        {
            Card drawnCard = cards[0];
            cards.RemoveAt(0);
            return drawnCard;
        }

        public void Reset()
        {
            cards = new Deck().cards;
        }

        public void Shuffle()
        {
            this.cards = cards.OrderBy(x => new Random().Next()).ToList();
        }
    }
    
}
