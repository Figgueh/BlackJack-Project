using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackProject.Models
{
    public enum Operations
    {
        addition,
        subtraction
    }

    public class BlackJack
    {
        private Operations _operation = Operations.addition;
        private double _pot;
        Player _player;
        Dealer _dealer;
        private object _winner = "";

        public Operations Operation
        {
            get => _operation;
            set
            {
                _operation = value;
            }
        }
        public double Pot
        {
            get => _pot;
            set
            {
                _pot = value;
            }
        }
        public Player Player
        {
            get => _player;
            set
            {
                _player = value;
            }
        }
        public Dealer Dealer
        {
            get => _dealer;
            set
            {
                _dealer = value;
            }
        }
        public object Winner
        {
            get => _winner;
            set
            {
                _winner = value;
            }
        }

        /// <summary>
        /// Constructor for new game
        /// </summary>
        public BlackJack()
        {
            //Setup new player and dealer:
            Player = new Player();
            Dealer = new Dealer();
        }

        public void reset()
        {
            Player.Hand = new List<Card>();
            Player.HandValue = 0;
            Player.HasAce = false;
            Dealer.Hand = new List<Card>();
            Dealer.HandValue = 0;
            Dealer.HiddenHandValue = 0;
            Dealer.HasAce = false;
            Winner = "";
            Pot = 0;
        }


        public void checkBet(int bet)
        {
            if(Operation == Operations.addition)
            {
                if (Player.Balance >= bet)
                {
                    //Remove the amount from the balance.
                    Player.removeAmount(bet);

                    //Place the bet on the table.
                    Pot += bet;

                }
            }
            else
            {
                //Add the amount back to the players hand
                Player.addAmount(bet);

                //Remove the amount from the table
                Pot -= bet;
            }
            
        }



        public void checkState()
        {
            //Check who has the bigger number
            if (Player.HandValue > Dealer.HandValue)
            {
                Winner = Player;

                //Players money is doubled
                Pot *= 2;
            }
            //set the winer to be equal to the player so that he gets his money back.
            else if (Player.HandValue == Dealer.HandValue)
                Winner = Player;
            else
                Winner = Dealer;

            //if the player hits blackjack
            if (Player.HandValue == 21 && Player.Hand.Count == 2)
            {
                //If the dealer also gets blackjack
                if (Dealer.HandValue == 21 && Dealer.Hand.Count == 2)
                    Winner = Dealer;
                else
                {
                    Winner = Player;

                    //The player wins 1.5x his bet
                    Pot *= 1.5;
                }
            }

            //If the player goes over 21
            if (Player.HandValue > 21)
                Winner = Dealer;


            //If the dealer goes over 21
            if (Dealer.HandValue > 21)
            {
                Winner = Player;

                //Players money is doubled
                Pot *= 2;
            }

            //If the player wins, then deposit the money thats in the pot into his balance.
            if(Winner == Player)
            {
                Player.addAmount(Pot);
               
            }

            //Show the card
            Dealer.Hand[0].IsVisible = true;
            //Set the pot to 0 once its been handled.
            Pot = 0; 

        }
    }
}
