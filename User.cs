using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    
    class User : Player
    {
        public bool Win = false;

        public User(string name, Deck deck) : base(name, deck){}
        
        public override Card Hit()
        {
            Card cardDealt = this.Draw();
            if (points == 21)
            {
                play = false;
                Win = true;
            }
            if (points > 21) {
                for (var i=0; i<this.Hand.Count; i++) {
                    if (this.Hand[i].Val == 11) {
                        this.Hand[i].Val = 1;
                        break;
                    }
                }
                lose = true;
                play = false;
            }
            return cardDealt;

        } //add a card to hand
        
        public override void Stand()
        {
            this.play = false;
        }
    }
}
