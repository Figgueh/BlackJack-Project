using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BlackJackProject.Models.Card;

namespace BlackJackProject.Models
{
    public class Player
    {
        private double _balance;
        private List<Card> _hand = new List<Card>();
        private int _handValue;


        public double Balance {
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

        public void getHandValue()
        {
            //Get the value of the dealers hand:
            foreach (var card in Hand)
            {
                //Catch the ace
                if (card.Value == (int)CardType.Ace)
                {
                    //If the player has a total value less than 10
                    if (HandValue <= 10)
                    {
                        //The ace is worth 11 points
                        HandValue += 11;
                    }
                    else
                    {
                        //If the player total value is more than 10, its worth 1
                        HandValue += 1;
                    }
                }
                else
                {
                    //Add up the rest of the card types.
                    HandValue += card.Value;
                }
            }
        }
    }
}
