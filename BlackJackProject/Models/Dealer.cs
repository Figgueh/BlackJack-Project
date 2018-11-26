using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BlackJackProject.Models.Card;

namespace BlackJackProject.Models
{
    public class Dealer : CardPlayer
    {
        private int _hiddenHandValue;

        public int HiddenHandValue
        {
            get
            {
                if (Hand[0].IsVisible == true)
                    return HandValue;
               //If the hidden card is an ace
               else if (Hand[0].GetCardType == CardType.Ace)
                    return _hiddenHandValue = HandValue - Hand[0].Value - 10;
                else
                    return _hiddenHandValue = HandValue - Hand[0].Value;
            }
            set
            {
                value = _hiddenHandValue;
            }
        }

        public void startDealer()
        {
            //Give two cards to the dealer.
            addCardToHand(visible: false);
            addCardToHand();
        }

        public void dealersTurn()
        {
            //If the dealer has a total of 17 points or more, he must stand
            while (HandValue < 17)
            {
                //Add a new card to the hand
                addCardToHand();
            }
        }
    }
}
