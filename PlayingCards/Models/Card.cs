using System;

namespace PlayingCards.Models
{
    public class Card : IComparable, IEquatable<Card>
    {
        private FaceValue _faceValue;
        private Suite _suit;
        private int _value;

        public FaceValue FaceValue
        {
            get
            {
                return _faceValue;
            }
            set
            {
                _faceValue = value;
            }
        }
        public Suite Suite
        {
            get
            {
                return _suit;
            }
            set
            {
                _suit = value;
            }
        }

        public Card(Suite suite, FaceValue faceValue)
        {
            Suite = suite;
            FaceValue = faceValue;
        }

        public override string ToString()
        {
            return string.Format("{0} of {1}",FaceValue, Suite);
        }

        public int CompareTo(object obj)
        {
            try
            {
                Card other = (Card)obj;
                if (this.FaceValue > other.FaceValue)
                {
                    return 1;
                }
                else if (this.FaceValue < other.FaceValue)
                {
                    return -1;
                }
                else
                {
                    if (this.Suite > other.Suite)
                    {
                        return 1;
                    }
                    else if (this.Suite < other.Suite)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }

            }
            catch
            {
                throw new ArgumentException();
            }
        }

        public bool Equals(Card other)
        {
            if (this.FaceValue == other.FaceValue && this.Suite == other.Suite)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}