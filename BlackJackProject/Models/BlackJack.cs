using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackProject.Models
{
    public class BlackJack
    {
        private double _pot;
        Player _player;
        Dealer _dealer;
        private object _winner;


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
            Dealer.Hand = new List<Card>();
            Dealer.HandValue = 0;
            Winner = "";
        }


        public void checkBet(int bet)
        {
            if (Player.Balance >= bet)
            {
                //Remove the amount from the balance.
                Player.removeAmount(bet);

                //Place the bet on the table.
                Pot += bet;

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
                {
                    Winner = Dealer;

                    //pot gets cleared
                    Pot = 0;
                }
                else
                {
                    Winner = Player;

                    //The player wins 1.5x his bet
                    Pot *= 1.5;
                }
            }

            //If the player goes over 21
            if (Player.HandValue > 21)
            {
                Winner = Dealer;

                //pot gets cleared
                Pot = 0;
            }

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

            //Clear the pot for the next game
            Pot = 0;

        }
    }
}
