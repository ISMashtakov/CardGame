using CardGame.Game.Cards;
using CardGame.Game.Cards.Mace;
using System.Collections.Generic;

namespace CardGame.Game
{
    public static class DeckStorages
    {
        public static List<Card> GetMaceDeck()
        {
            List<Card> deck = new List<Card>();

            for (int i = 0; i < 5; i++)
            {
                deck.Add(new MaceHit());
                deck.Add(new MaceBlock());
                deck.Add(new MaceReadMovement());
            }

            return deck;
        }
    }
}
