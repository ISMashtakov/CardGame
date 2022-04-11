using CardGame.Game.Cards;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CardGame.Game
{
    public class PlayerHand : MonoSingletone<PlayerHand>, IHand
    {

        Vector3 _startPosition;
        List<CardPresenter> _cards = new List<CardPresenter>();

        UnityEvent<int> _onChangeCount = new UnityEvent<int>();
        public UnityEvent<int> OnChangeCount => _onChangeCount;

        void Start()
        {
            _startPosition = transform.position;

            CardInput.GetInstanse().OnDropCard.AddListener(UpdateCardsPosition);
        }

        public void AddCard(CardPresenter cardPresenter)
        {
            cardPresenter.transform.parent = transform;
            _cards.Add(cardPresenter);
            OnChangeCount.Invoke(_cards.Count);
            UpdateCardsPosition();
        }

        public void RemoveCard(CardPresenter cardPresenter)
        {
            _cards.Remove(cardPresenter);
            OnChangeCount.Invoke(_cards.Count);
            UpdateCardsPosition();
        }


        float CardsLength()
        {
            float length = 0;
            foreach (CardPresenter card in _cards)
            {
                length += card.GetWidth();
            }
            return length;
        }

        void UpdateCardsPosition()
        {
            Vector3 leftPosition = _startPosition + Vector3.left * CardsLength() * 0.2f;
            for (int i = 0; i < _cards.Count; i++)
            {
                CardPresenter card = _cards[i];
                card.SetLayer(i * 10);
                card.MoveTo(
                    leftPosition +
                    Vector3.right * i * 0.4f * card.GetWidth() +
                    Vector3.up * 0.03f * i +
                    Vector3.forward * -0.1f * i
                    );
            }
        }
    }
}
