using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    class Dealer : Player
    {
        public Card ShownCard;
        public Card HiddenCard;
        public Dealer(Deck deck) : base(deck)
        {
            this.name = "Cody";
        }
        public override Card Hit() 
        {
            Card card = null;
            if (this.points >= 17) {
                this.Stand();
                return card;
            } else {
                card = this.Draw();
            }
            if (this.points > 21) {
                for (var i=0; i<this.Hand.Count; i++) {
                    if (this.Hand[i].Val == 11) {
                        this.Hand[i].Val = 1;
                        break;
                    }
                }
                this.lose = true;
                this.play = false;
                Console.WriteLine("Cody busted and is now destitute! Congratulations, you win!");
            }
            return card;
        } 
        public override void Stand()
        {
            this.play = false;
        }
    }
}
