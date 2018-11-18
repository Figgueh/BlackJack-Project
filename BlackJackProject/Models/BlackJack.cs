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

            //Set new player balance to be 1000.
            Player.addAmount(1000);
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
            //if the player hits blackjack
            if(Player.HandValue == 21 && Player.Hand.Count == 2)
            {
                //If the dealer doesnt get blackjack either
                if(Dealer.HandValue != 21 && Dealer.Cards.Count != 2)
                {
                    Winner = Player;

                    //The player wins 1.5x his bet
                    Pot *= 1.5;
                }
                //If the dealer also gets blackjack
                else if(Dealer.HandValue == 21 && Dealer.Cards.Count == 2)
                {
                    Winner = Dealer;

                    //pot gets cleared
                    Pot = 0;
                }
            }

            //If the dealer goes over 21
            if (Dealer.HandValue > 21)
            {
                Winner = Player;

                //Players money is doubled
                Pot *= 2;
            }

            //If the player goes over 21
            if (Player.HandValue > 21)
            {
                Winner = Dealer;

                //pot gets cleared
                Pot = 0;
            }


            //If player and dealer have the same value then its a push.
            if(Player.HandValue == Dealer.HandValue)
            {
                //set the winer to be equal to the player so that he gets his money back.
                Winner = Player;
            }

            //If the player wins, then deposit the money thats in the pot into his balance.
            if(Winner == Player)
            {
                Player.addAmount(Pot);
            }

        }
    }
}
