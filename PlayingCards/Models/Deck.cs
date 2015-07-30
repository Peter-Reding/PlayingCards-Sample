using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayingCards.Models
{
    public class Deck
    {
        private List<Card> _cards;

        public List<Card> Cards
        {
            get
            {
                return _cards;
            }
        }

        public Deck()
        {
            IEnumerable<Suite> suites = Enum.GetValues(typeof(Suite)).Cast<Suite>();
            IEnumerable<FaceValue> faceValues = Enum.GetValues(typeof(FaceValue)).Cast<FaceValue>();
            _cards = new List<Card>(suites.Count() * faceValues.Count());

            foreach (Suite suite in suites)
            {
                foreach (FaceValue faceValue in faceValues)
                {
                    Card newCard = new Card(suite, faceValue);
                    _cards.Add(newCard);
                }
            }
        }

        public void Shuffle()
        {
            Shuffle(_cards.Capacity * 5);
        }

        public void Shuffle(int shuffleCount)
        {
            Random randomizer = new Random();
            for (int i = 0; i < shuffleCount; i++)
            {
                int cardFrom = randomizer.Next(0, _cards.Capacity);
                int cardTo = randomizer.Next(0, _cards.Capacity);
                Card card = _cards[cardFrom];
                _cards.RemoveAt(cardFrom);
                _cards.Insert(cardTo, card);
            }
        }

        public void Sort()
        {
            _cards.Sort();
        }
    }
}