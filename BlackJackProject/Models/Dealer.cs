using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BlackJackProject.Models.Card;

namespace BlackJackProject.Models
{
    public class Dealer : CardPlayer
    {

        public int HiddenHandValue
        {
            get => HandValue + Hand[0].Value;
        }

        public void dealersTurn(List<Card> deckInPlay)
        {
            //If the dealer has a total of 17 points or more, he must stand
            while (HandValue + Hand[0].Value < 17)
            {
                //Add a new card to the hand
                addCardToHand(deckInPlay);

                //Recalculate the hand value
                getHandValue();
            }

            Hand[0].IsVisible = true;
        }
    }
}
