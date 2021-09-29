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
            Console.WriteLine("Welcome player! Ready to play Blackjack?");
            Console.WriteLine("First, let's know the name of this loser (aka you):");
            string userName = Console.ReadLine();
            Deck deck = new Deck();
            User user = new User(userName, deck);
            Dealer dealer = new Dealer(deck);
            while (play)
            {
                deck = new Deck();
                deck.Shuffle();
                user.Hand = new List<Card>();
                dealer.Hand = new List<Card>();
                user.Points = 0;
                dealer.Points = 0;
                GameLoop(userName, dealer, user, deck);
                if (user.Money <= 0) {
                    Console.WriteLine("You are out of money!");
                    play = false;
                    break;
                }
                Console.WriteLine("Want to play again?");
                string response = Console.ReadLine();
                if (response.ToLower().StartsWith('n') || response.ToLower() == "no") {
                    play = false;
                }
            }
        }
        public static void GameLoop(string userName, Dealer dealer, User user, Deck deck)
        {
            bool isGameRunning = true;
            while(isGameRunning && user.Money > 0) 
            {
                deck.Shuffle();
                // INITIAL DEAL
                Card userFirst = user.Hit();
                Card userSecond = user.Hit();

                //bet money
                Console.WriteLine($"How much do you want to bet this game? You have ${user.Money}.");
                int userBet = int.Parse(Console.ReadLine());
                if (userBet > user.Money){
                    Console.WriteLine("You bet more than you have and cody punched you in the face.");
                    Console.WriteLine($"How much do you want to bet this game? You have ${user.Money}.");
                    userBet = int.Parse(Console.ReadLine());
                }
                Console.WriteLine($"You have bet {userBet} dollars.");

                //display user cards
                Console.WriteLine($"Your cards are {userFirst.DisplayCard()} and {userSecond.DisplayCard()}.");

                
                if (user.Points == 21) {
                    isGameRunning = false;
                    user.Money += userBet;
                    Console.WriteLine($"21! Cody loses immediately, the crowd rejoices! You made {userBet} dollars!");
                    break;
                } else {
                    Card dealerShown = dealer.Hit();
                    Card dealerHidden = dealer.Hit();
                    dealer.ShownCard = dealerShown;
                    dealer.HiddenCard = dealerHidden;
                    Console.WriteLine($"Dealers face up card is {dealerShown.DisplayCard()}.");
                }
                Console.WriteLine("Now the game of bullying loser starts");
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
                        if (user.Points > 21) {
                            user.Play = false;
                            user.Lose = true;
                        }
                    }
                    else if (response.ToLower().StartsWith('s') || response.ToLower() == "stand")
                    {
                        user.Stand();
                        System.Console.WriteLine($"You decided to stand, you have {user.Points}.");
                    }
                    if (user.Lose == true){
                        user.Play = false;
                        user.Money -= userBet;
                        Console.WriteLine("You are done, how can you lose to Cody?????");
                        Console.WriteLine($"You lost {userBet} dollars and Cody manically laughed at you!");
                    }
                }
                if (user.Lose) {
                    break;
                }
                bool showCards = true;
                while (dealer.Play)
                {
                    if (showCards) {
                        Console.WriteLine($"Dealers cards are {dealer.HiddenCard.DisplayCard()} and {dealer.ShownCard.DisplayCard()}");
                        Console.WriteLine($"Dealer has {dealer.Points}.");
                        showCards = false;
                    }
                    Card dealtCard = dealer.Hit();
                    string cardInfoDealer = dealtCard?.DisplayCard();
                    if (dealtCard != null) {
                        System.Console.WriteLine($"The dealer drew {cardInfoDealer}.");
                        Console.WriteLine($"Dealer points now {dealer.Points}.");
                        if (dealer.Points > 21) {
                            dealer.Play = false;
                            dealer.Lose = true;
                        }
                    }
                    if (dealer.Lose)
                    {
                        user.Win = true;
                    }         
                }
                if (dealer.Lose) {
                    user.Money += userBet;
                    Console.WriteLine($"Cody busted and is now destitute! Congratulations, you win! You made {userBet} dollars!");
                    break;
                }
                if (dealer.Points > user.Points) 
                {
                    isGameRunning = false;
                    user.Play = false;
                    dealer.Play = false;
                    user.Money -= userBet;
                    System.Console.WriteLine("Gasp, you were no match for the Cody! The amount of shame you must feel...");
                    Console.WriteLine($"You lost {userBet} dollars and Cody manically laughed at you!");
                } else {
                    isGameRunning = false;
                    user.Play = false;
                    dealer.Play = false;
                    System.Console.WriteLine("You won aginst Cody, which is not worth celebrating!");
                    user.Money += userBet;
                    Console.WriteLine($"21! Cody loses immediately, the crowd rejoices! You made {userBet} dollars!");
                }
            } 
        }
    } 
}
