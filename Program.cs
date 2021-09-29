using System;
using System.Collections.Generic;
using System.Linq;

namespace deck_of_cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Want to play blackjack, yes or no?");
            string wantToPlay = Console.ReadLine();
            bool play = false;
            if (wantToPlay.ToLower().StartsWith('y') || wantToPlay.ToLower() == "yes") {
                play = true;
            }
            while (play)
            {
                GameLoop();
                Console.WriteLine("Want to play again?");
                string response = Console.ReadLine();
                if (response.ToLower().StartsWith('n') || response.ToLower() == "no") {
                    play = false;
                }
            }
        }
        public static void GameLoop()
        {
            bool isGameRunning = true;
            Console.WriteLine("Welcome player! Ready to play Blackjack?");
            Console.WriteLine("First, let's know the name of this loser (aka you):");
            string userName = Console.ReadLine();
            Deck deck = new Deck();
            deck.Shuffle();
            User user = new User(userName, deck);
            Dealer dealer = new Dealer(deck);
            // INITIAL DEAL
            Card userFirst = user.Hit();
            Card userSecond = user.Hit();
            Console.WriteLine($"Your cards are {userFirst.DisplayCard()} and {userSecond.DisplayCard()}.");
            if (user.Points == 21) {
                isGameRunning = false;
                Console.WriteLine("21! Cody loses immediately, the crowd rejoices!");
            } else {
                Card dealerShown = dealer.Hit();
                Card dealerHidden = dealer.Hit();
                dealer.ShownCard = dealerShown;
                dealer.HiddenCard = dealerHidden;
                Console.WriteLine($"Dealers face up card is {dealerShown.DisplayCard()}.");
            }

            while(isGameRunning) 
            {
                Console.WriteLine("Now the game of bullying loser starts");
                user.Play = true;
                while (user.Play)
                {
                    System.Console.WriteLine("Would you like to hit or stand?");
                    string response = Console.ReadLine();
                    if (response.ToLower().StartsWith('h') || response.ToLower() == "hit")
                    {
                        Card userDealtCard = user.Hit();
                        string cardInfo = userDealtCard.DisplayCard();
                        System.Console.WriteLine($"You were dealt {cardInfo}.");
                        System.Console.WriteLine($"You have {user.Points} points.");
                    }
                    else if (response.ToLower().StartsWith('s') || response.ToLower() == "stand")
                    {
                        user.Stand();
                        System.Console.WriteLine($"You decided to stand, you have {user.Points}.");
                        dealer.Play = true;
                    }
                    else if (user.Lose == true){
                        user.Play = false;
                        Console.WriteLine("You are done, how can you lose to Cody?????");
                    }
                }
                bool showCards = true;
                while (dealer.Play)
                {
                    if (showCards) {
                        Console.WriteLine($"Dealers cards are {dealer.HiddenCard.DisplayCard()} and {dealer.ShownCard.DisplayCard()}");
                        Console.WriteLine($"Dealer has {dealer.Points}.");
                    }
                        Card dealtCard = dealer.Hit();
                        string cardInfoDealer = dealtCard?.DisplayCard();
                        if (dealtCard != null) {
                            System.Console.WriteLine($"The dealer drew {cardInfoDealer}.");
                            Console.WriteLine($"Dealer points now {dealer.Points}.");
                        }
                        if (dealer.Lose)
                        {
                            user.Win = true;
                        }         
                }
                if (dealer.Points > user.Points) 
                {
                    user.Play = false;
                    System.Console.WriteLine("Gasp, you were no match for the Cody! The amount of shame you must feel...");
                } else {
                    user.Play = false;
                    System.Console.WriteLine("You won aginst Cody, which is not worth celebrating!");
                }
            } 
        }
    } 
}
