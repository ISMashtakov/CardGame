using CardGame.Game.Cards;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame.Game
{
    public interface IDeck : ICountable
    {
        public Card Pop();

        public void ToTop(Card card);

        public Vector3 Position { get; }

        public void SetDeck(List<Card> cards);
    }
}
