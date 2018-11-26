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
        private static Deck _playingCards = new Deck();
        private int _handValue;
        

        public List<Card> Hand
        {
            get => _hand;
            set
            {
                _hand = value;
            }
        }
        public Deck PlayingCards
        {
            get => _playingCards;
            set
            {
                _playingCards = value;
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
        public bool HasAce = false;

        public void addCardToHand(bool visible = true)
        {
            //If the deck runs out of cards
            if (PlayingCards.DeckList.Count == 0)
                //Rebuild the deck
                PlayingCards.Builddeck();

            if(HandValue <= 21)
            {
                Card newcard;

                //Get the amount of cards in the deck
                int totalCardsInPlay = PlayingCards.DeckList.Count();

                //Get a new random number based on the number of cards we have in play.
                Random random = new Random();
                int randomNumber = random.Next(totalCardsInPlay);

                //Find the card at that number
                newcard = PlayingCards.DeckList[randomNumber];

                //Remove it from the deck
                PlayingCards.DeckList.Remove(newcard);

                //Attach the visibility to the card.
                if (visible == false && Hand.Count == 0)
                    newcard.IsVisible = false;

                //Add it to the list of cards in the hand
                Hand.Add(newcard);

                //Get the new handValue
                getHandValue();

                
            }
        }

        public void getHandValue()
        {
            //reset hand value
            HandValue = 0;

            //Get the value of the dealers hand:
            foreach (var card in Hand)
            {
                if (card.Value == (int)CardType.Ace)
                    HasAce = true;

                //Add up the card types.
                HandValue += card.Value;
            }

            //Check if we have a value of 11 or less
            if (HandValue <= 11 && HasAce == true)
                //If theres an ace in the hand, then the ace is worth 11
                HandValue += 10;

            //We only add 10 because we already counted the ace as 1.

        }
    }
}
