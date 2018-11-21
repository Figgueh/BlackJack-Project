using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackJackProject.Models
{
    public class Card
    {
        private CardType _cardType;
        private Suits _cardSuit;
        private int _value;
        private bool _isVisible = true;

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
            }
        }
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
            }
        }

        public string ImageUrl
        {
            get => getCardUrl(this._cardType, this._cardSuit);
        }
        public CardType GetCardType
        {
            get => this._cardType;
        }

        //List each of the possible card types:
        public enum CardType
        {
            Ace = 1,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
        }

        //List each of the possible suits:
        public enum Suits
        {
            Clubs = 1,
            Diamonds,
            Hearts,
            Spades
        }


        public Card(CardType cardType, Suits suit)
        {
            //assign the values to the card
            _cardType = cardType;
            _cardSuit = suit;

            //Get the trueCard value
            if ((int)cardType > 10)
                _value = 10;            
            else
                _value = (int)cardType;
        }

        /// <summary>
        /// Takes each new card and assigns them the URL for their specific type.
        /// </summary>
        /// <param name="card">New card value</param>
        /// <param name="suit">New card face type</param>
        /// <returns>URL of the new card</returns>
        private string getCardUrl(CardType card, Suits suit)
        {
            int cardValue = (int)card;
            string cardUrl = "";

            //Get the first part of the url:
            if (card == CardType.Ace)
                cardUrl += "A";
            else if (card == CardType.Jack)
                cardUrl += "J";
            else if (card == CardType.Queen)
                cardUrl += "Q";
            else if (card == CardType.King)
                cardUrl += "K";
            else
                cardUrl += cardValue.ToString();

            //Get the second part of the url:
            if (suit == Suits.Clubs)
                cardUrl += "C";
            else if (suit == Suits.Diamonds)
                cardUrl += "D";
            else if (suit == Suits.Hearts)
                cardUrl += "H";
            else if (suit == Suits.Spades)
                cardUrl += "S";

            //Add the extension
            if (!String.IsNullOrEmpty(cardUrl))
                cardUrl += ".png";

            if (IsVisible == false)
                cardUrl = "blue_back.png";

            return cardUrl;
        }
    }
}