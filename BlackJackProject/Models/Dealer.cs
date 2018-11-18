using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BlackJackProject.Models.Card;

namespace BlackJackProject.Models
{
    public class Dealer : CardPlayer
    {

        public void dealersTurn(List<Card> deckInPlay)
        {
            getHandValue();
            //If the dealer has a total of 17 points or more, he must stand
            while (HandValue < 17)
            {
                //Add a new card to the hand
                addCardToHand(deckInPlay);

                //Recalculate the hand value
                getHandValue();
            }
        }
    }
}
