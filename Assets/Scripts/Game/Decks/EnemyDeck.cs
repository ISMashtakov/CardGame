using System.Collections.Generic;
using CardGame.Game.Cards;
using UnityEngine;
using UnityEngine.Events;

namespace CardGame.Game
{
    public class EnemyDeck : MonoSingletone<EnemyDeck>, IDeck
    {

        List<Card> cards = new List<Card> { new MaceHit(), new MaceHit(), new MaceHit(), new MaceHit(), new MaceHit(), new MaceHit(), new MaceHit(), new MaceHit(), new MaceHit(), new MaceHit() };

        UnityEvent<int> _onChangeCount = new UnityEvent<int>();
        public UnityEvent<int> OnChangeCount => _onChangeCount;

        public Vector3 Position => transform.position;

        private void Start()
        {
            OnChangeCount.Invoke(cards.Count);
        }

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
    }
}
