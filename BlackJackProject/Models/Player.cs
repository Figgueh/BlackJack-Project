using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackProject.Models
{
    public class Player
    {
        private int _balance;
        private List<Card> _hand;
        private int _handValue;


        public int Balance {
            get => _balance;
            set
            {
                _balance = value;
            }
        }
        public List<Card> Hand {
            get => _hand;
            set
            {
                _hand = value;
            }
        }
        public int HandValue {
            get => _handValue;
            set
            {
                _handValue = value;
            }
        }

        public void addAmount(int amount)
        {
            //Add the amount to the balance.
            Balance += amount;
        }

        public void removeAmount(int amount)
        {
            //Remove the amount from the balance.
            Balance -= amount;
        }

        public void getHandValue()
        {
            //Loop threw each card the player holder
            foreach(var card in Hand)
            {
                //Add all the values together.
                HandValue += card.Value;
            }
        }
    }
}
