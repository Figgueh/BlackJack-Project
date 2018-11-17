using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackProject.Models
{
    public class BlackJack
    {
        private int _pot;
        Player _player;
        Dealer _dealer;


        public int Pot
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
    }
}
