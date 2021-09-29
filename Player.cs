using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    abstract class Player 
    {
        protected string name;
        protected List<Card> hand = new List<Card>();
        protected bool play = false;
        protected bool lose = false;
        protected int points = 0;

        public int Points 
        {
            get { return points; }
        }
        protected Deck deck;
        public List<Card> Hand 
        {
            get { return hand; }
        }
        public bool Play 
        {
            get { return play; }
            set { play = value; }
        }
        public bool Lose
        {
            get { return lose; }
        }
        public Player(string name, Deck deck)
        {
            this.name = name;
            this.hand = new List<Card>();
            this.deck = deck;
        }
        public Player(Deck deck) // For dealer with default name.
        {
            this.hand = new List<Card>();
            this.deck = deck;
        }
        public Card Draw()
        {
            Card card = deck.Deal();
            hand.Add(card);
            int cardVal = card.Val;
            points += cardVal;
            return card;
        }

        public abstract Card Hit(); //add a card to hand
        
        public abstract void Stand();//don't do anything
    }
}
