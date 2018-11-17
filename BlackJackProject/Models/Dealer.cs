using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackProject.Models
{
    public class Dealer
    {
        private List<Card> _cards = new List<Card>();

        public List<Card> Cards
        {
            get => _cards;
            set
            {
                _cards = value;
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
            Cards.Add(newcard);
        }
    }
}
