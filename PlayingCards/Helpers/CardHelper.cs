using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlayingCards.Models;
using System.Text;

namespace PlayingCards.Helpers
{
    public static class CardHelper
    {
        public static string PrintCard(Card card)
        {
            StringBuilder builder = new StringBuilder();
            PrintCard(card, builder);
            return builder.ToString();
        }

        private static void PrintCard(Card card, StringBuilder builder)
        {
            builder.AppendFormat(
                @"<div class=""card  {2}"">
                    <label class=""suit"">{0}</label>
                    <label class=""facevalue"">{1}</label>
                </div>", card.Suite, card.FaceValue, card.Suite.ToString().ToLower());
        }

        public static HtmlString PrintDeck(Deck deck)
        {
            if (deck.Cards.Count == 0)
            {
                return new HtmlString("");
            }
            else
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("<div class=\"deck\">");
                foreach (Card card in deck.Cards)
                {
                    PrintCard(card, builder);
                }
                builder.Append("</div >");
                return new HtmlString(builder.ToString());
            }
        }
    }
}