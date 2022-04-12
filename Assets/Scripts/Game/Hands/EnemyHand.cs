using CardGame.Game.Cards;
using UnityEngine.Events;

namespace CardGame.Game
{
    public class EnemyHand : MonoSingletone<EnemyHand>, IHand
    {
        int _cardCount = 0;
        UnityEvent<int> _onChangeCount = new UnityEvent<int>();
        public UnityEvent<int> OnChangeCount => _onChangeCount;

        public void AddCard(CardPresenter cardPresenter)
        {
            _cardCount++;
            OnChangeCount.Invoke(_cardCount);
        }

        public void RemoveCard(CardPresenter cardPresenter)
        {
            _cardCount--;
            OnChangeCount.Invoke(_cardCount);
        }
    }
}
