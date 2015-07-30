using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayingCards.Models;
using System.Linq;
using System.Collections.Generic;

namespace PlayingCards_Test
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void TestCreateDeck()
        {
            Deck testDeck = new Deck();

            // The Reqirment was to have 52 cards.
            // (four suits of thirteen cards each).
            List<FaceValue>  faceValues= Enum.GetValues(typeof(FaceValue)).Cast<FaceValue>().ToList();
            List<Suite> suites = Enum.GetValues(typeof(Suite)).Cast<Suite>().ToList();

            bool isProperDeck = true;
            if (suites.Count != 4)
            {
                isProperDeck = false;
            }
            else
            {
                foreach (Suite suite in suites)
                {
                    IEnumerable<Card> cards = testDeck.Cards.Distinct().Where(c => c.Suite == suite);
                    if (cards.Count() != 13)
                    {
                        isProperDeck = false;
                        break;
                    }
                }
            }
            Assert.IsTrue(isProperDeck);
        }

        [TestMethod]
        public void TestSortDeck()
        {
            Deck testDeck1 = new Deck();
            testDeck1.Shuffle();
            testDeck1.Sort();
            Deck testDeck2 = new Deck();
            testDeck2.Sort();

            //Since I get to make up what sort order is, as long as it is consistaant the test should pass.
            Assert.IsTrue(testDeck1.Cards.SequenceEqual(testDeck2.Cards));
        }
       
        [TestMethod]
        public void TestShuffleDeck()
        {
            Deck testDeck1 = new Deck();
            testDeck1.Shuffle();
            Deck testDeck2 = new Deck();

            //TODO: There is a Chance that the shuffle for  both will be the same and false fail this test. 
            //      Find a way to make sure that does not happen.
            Assert.IsFalse(testDeck1.Cards.SequenceEqual(testDeck2.Cards));
        }
    }
}
