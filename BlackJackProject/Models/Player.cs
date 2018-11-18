using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BlackJackProject.Models.Card;

namespace BlackJackProject.Models
{
    public class Player : CardPlayer
    {
        private double _balance = 500;

        public double Balance {
            get => _balance;
            set
            {
                _balance = value;
            }
        }

        public void addAmount(double amount)
        {
            //Add the amount to the balance.
            Balance += amount;
        }

        public void removeAmount(double amount)
        {
            //Remove the amount from the balance.
            Balance -= amount;
        }
    }
}
