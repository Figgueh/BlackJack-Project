using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace BlackJackProject.Models
{
    public class Deck
    {
        private const int NUMBER_OF_CARDS = 52;
        private List<Card> _DeckList;

        public List<Card> DeckList
        {
            get => _DeckList;
            set
            {

                _DeckList = value;

            }
        }

        public Deck()
        {
            Builddeck();
        }

        public void Builddeck()
        {
            DeckList = new List<Card>();

            var s = Enum.GetNames(typeof(Card.Suits)).Length;
            var v = Enum.GetNames(typeof(Card.CardType)).Length;

            //Loop threw each of the possible suite values
            for (int sc = 1; sc <= s; sc++)
            {
                //Loop threw each of the possible type values
                for (int vc = 1; vc <= v; vc++)
                {
                    //Create a card with each of the items in both enums
                    DeckList.Add(new Card((Card.CardType)vc, (Card.Suits)sc));
                }
            }


        }

    }
}