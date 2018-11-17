using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackProject.Models
{
    public class Player
    {
        private int _balance;
        private List<Card> _hand = new List<Card>();
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

        public void addCardToHand(List<Card> deckInPlay)
        {
            Card newcard;

            //Get the amount of cards in the deck
            int totalCardsInPlay = deckInPlay.Count();

            //Get a new random number based on the number of cards we have in play.
            Random random = new Random();
            int randomNumber = random.Next(totalCardsInPlay);

            //Find the card at that number
            newcard = deckInPlay[randomNumber];

            //Remove it from the deck
            deckInPlay.Remove(newcard);

            //Add it to the list of cards
            Hand.Add(newcard);
        }
    }
}
