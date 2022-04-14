using CardGame.Game.Cards;
using UnityEngine.Events;

namespace CardGame.Game
{
    public class EnemyHand : MonoSingletone<EnemyHand>, IHand
    {
        int _cardCount = 0;
        public int CardCount
        {
            get => _cardCount; private set
            {
                _cardCount = value;
                OnChangeCount.Invoke(_cardCount);
            }
        }
        UnityEvent<int> _onChangeCount = new UnityEvent<int>();
        public UnityEvent<int> OnChangeCount => _onChangeCount;

        public void AddCard(CardPresenter cardPresenter)
        {
            CardCount++;
        }

        public void RemoveCard(CardPresenter cardPresenter)
        {
            CardCount--;
        }

        public void Decrease()
        {
            CardCount--;
        }
    }
}
