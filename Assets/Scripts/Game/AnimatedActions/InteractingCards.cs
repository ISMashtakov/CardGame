using CardGame.Game.Cards;
using System.Collections;
using UnityEngine;

namespace CardGame.Game.Actions
{
    public class InteractingCards : AnimatedAction
    {
        CardPresenter _enemyCard;
        CardPresenter _playerCard;

        public InteractingCards(CardPresenter leftCard, CardPresenter rightCard)
        {
            _enemyCard = leftCard;
            _playerCard = rightCard;
        }

        IEnumerator PlayCardEffect(CardPresenter card, CardPresenter other, UserPresentation user)
        {
            yield return card.PlayCardTypeEffect(other.Card);
            yield return new WaitForSeconds(0.5f);
            if (card.Card.WillBePlayed(other.Card))
            {
                foreach (AnimatedAction action in card.Card.GetEffect(user))
                {
                    yield return action.Execute();
                    yield return new WaitForSeconds(0.5f);
                }
            }
            yield return new WaitForSeconds(0.5f);
        }

        public override IEnumerator Execute()
        {
            yield return new WaitForSeconds(1f);

            if (GameController.GetInstanse().InitiativeController.IsMy)
            {
                yield return PlayCardEffect(_playerCard, _enemyCard, UserPresentation.GetLocal());
                yield return new WaitForSeconds(0.5f);
                yield return PlayCardEffect(_enemyCard, _playerCard, UserPresentation.GetEnemy());
            }
            else
            {
                yield return PlayCardEffect(_enemyCard, _playerCard, UserPresentation.GetEnemy());
                yield return new WaitForSeconds(0.5f);
                yield return PlayCardEffect(_playerCard, _enemyCard, UserPresentation.GetLocal());
            }

            if (_enemyCard.Card.WillBePlayed(_playerCard.Card) && !_playerCard.Card.WillBePlayed(_enemyCard.Card))
            {
                GameController.GetInstanse().InitiativeController.IsMy = false;
            }
            else if (!_enemyCard.Card.WillBePlayed(_playerCard.Card) && _playerCard.Card.WillBePlayed(_enemyCard.Card))
            {
                GameController.GetInstanse().InitiativeController.IsMy = true;
            }

            _enemyCard.MoveTo(_enemyCard.transform.position + Vector3.up * 100f);
            _playerCard.MoveTo(_playerCard.transform.position + Vector3.up * 100f);
            yield return new WaitForSeconds(1);

            _enemyCard.Delete();
            _playerCard.Delete();

            GameController.GetInstanse().EndInteraction();
        }
    }
}
