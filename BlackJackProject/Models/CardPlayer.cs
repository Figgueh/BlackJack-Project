using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BlackJackProject.Models.Card;

namespace BlackJackProject.Models
{
    public class CardPlayer
    {
        private List<Card> _hand = new List<Card>();
        private int _handValue;

        public List<Card> Hand
        {
            get => _hand;
            set
            {
                _hand = value;
            }
        }
        public int HandValue
        {
            get => _handValue;
            set
            {
                _handValue = value;
            }
        }

        public void addCardToHand(List<Card> deckInPlay)
        {
            if(HandValue <= 21)
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

                //Get the new handValue
                getHandValue();
            }
        }

        public void getHandValue()
        {
            //reset hand value
            HandValue = 0;
            bool hasAce = false;

            //Get the value of the dealers hand:
            foreach (var card in Hand)
            {
                if (card.Value == (int)CardType.Ace)
                    hasAce = true;
                //Add up the rest of the card types.
                HandValue += card.Value;
            }

            if (HandValue <= 10 && hasAce == true)
                HandValue += 10;

        }
    }
}
