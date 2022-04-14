using System.Collections.Generic;
using CardGame.Game.Cards;
using UnityEngine;
using UnityEngine.Events;

namespace CardGame.Game {
    public class PlayerDeck : MonoSingletone<PlayerDeck>, IDeck
    {

        List<Card> cards = new List<Card>();

        UnityEvent<int> _onChangeCount = new UnityEvent<int>();
        public UnityEvent<int> OnChangeCount => _onChangeCount;
        public Vector3 Position => transform.position;
        public Card Pop()
        {
            if (cards.Count > 0)
            {
                Card elem = cards[0];
                cards.Remove(elem);
                OnChangeCount.Invoke(cards.Count);
                return elem;
            }

            return null;
        }

        public void ToTop(Card card)
        {
            cards.Insert(0, card);
        }

        public void SetDeck(List<Card> cards)
        {
            this.cards = cards;
        }
    }
}
