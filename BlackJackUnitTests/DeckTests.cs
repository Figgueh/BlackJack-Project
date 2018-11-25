using BlackJackProject.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackUnitTests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void TestBuldDeck()
        {
            Deck deck = new Deck();


            deck.Builddeck();

            // Test total number of cards in new created deck
            Assert.AreEqual(52, deck.DeckList.Count);

            CardPlayer cardPlayer = new CardPlayer();

            cardPlayer.Hand = deck.DeckList;
            cardPlayer.getHandValue();

            // Test maximum number of points that can appear in any blackjack game
            Assert.AreEqual(340, cardPlayer.HandValue);

        }
    }
}
