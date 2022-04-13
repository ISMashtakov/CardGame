using CardGame.Game.Cards;
using UnityEngine;

namespace CardGame.Game
{
    public interface IDeck : ICountable
    {
        public Card Pop();

        public void ToTop(Card card);


        public Vector3 Position { get; } 
    }
}
