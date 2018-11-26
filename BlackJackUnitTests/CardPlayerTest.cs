using BlackJackProject.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackJackUnitTests
{
    [TestClass]
    public class CardPlayerTest
    {
        [TestMethod]
        public void TestCardToHand()
        {
            System.Collections.Generic.List<Card> deck = new System.Collections.Generic.List<Card>();
            Card.Suits suit = Card.Suits.Diamonds;
            Card.CardType typ = Card.CardType.Five;
            Card card = new Card(typ, suit);
            deck.Add(card);
            deck.Add(card);
            deck.Add(card);

            // Test the number of cards in the deck
            Assert.AreEqual(3, deck.Count);

            CardPlayer cardPlayer = new CardPlayer();

            //Test the number of cards on hand
            Assert.AreEqual(0, cardPlayer.HandValue);

            cardPlayer.addCardToHand();

            // Test the number of cards after play
            Assert.AreEqual(2, deck.Count);
            Assert.AreEqual(5, cardPlayer.HandValue);
        }

        [TestMethod]
        public void TestHandValue()
        {

            CardPlayer cardPlayer = new CardPlayer();

            System.Collections.Generic.List<Card> cards = new System.Collections.Generic.List<Card>();
            Card.Suits suit = Card.Suits.Diamonds;
            Card.CardType typ = Card.CardType.Five;
            Card card = new Card(typ, suit);
            cards.Add(card);
            cards.Add(card);
            cards.Add(card);



            cardPlayer.Hand = cards;

            cardPlayer.getHandValue();

            // Test correctness of card counting
            Assert.AreEqual(15, cardPlayer.HandValue);


        }
    }
}
