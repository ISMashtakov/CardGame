using CardGame.Game.Cards;
using UnityEngine.Events;

namespace CardGame.Game
{
    public class EnemyHand : MonoSingletone<EnemyHand>, IHand
    {
        UnityEvent<int> _onChangeCount = new UnityEvent<int>();
        public UnityEvent<int> OnChangeCount => _onChangeCount;

        public void AddCard(CardPresenter cardPresenter)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveCard(CardPresenter cardPresenter)
        {
            throw new System.NotImplementedException();
        }
    }
}
