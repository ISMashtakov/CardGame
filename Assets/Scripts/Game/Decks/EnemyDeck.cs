using System.Collections.Generic;
using CardGame.Game.Cards;
using UnityEngine;
using UnityEngine.Events;

namespace CardGame.Game
{
    public class EnemyDeck : MonoSingletone<EnemyDeck>, IDeck
    {
        int _cardCount = 0;

        UnityEvent<int> _onChangeCount = new UnityEvent<int>();
        public UnityEvent<int> OnChangeCount => _onChangeCount;

        public Vector3 Position => transform.position;

        private void Start()
        {
            OnChangeCount.Invoke(_cardCount);
        }

        public Card Pop()
        {
            if(_cardCount > 0)
            {
                _cardCount--;
            }
            return null;
        }

        public void ToTop(Card card)
        {
            _cardCount++;
        }

        public void SetDeck(List<Card> cards)
        {
            _cardCount = cards.Count;
        }
    }
}
