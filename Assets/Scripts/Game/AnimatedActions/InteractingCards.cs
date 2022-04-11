using CardGame.Game.Cards;
using System.Collections;
using UnityEngine;

namespace CardGame.Game.Actions
{
    public class InteractingCards : AnimatedAction
    {
        CardPresenter _leftCard;
        CardPresenter _rightCard;

        public InteractingCards(CardPresenter leftCard, CardPresenter rightCard)
        {
            _leftCard = leftCard;
            _rightCard = rightCard;
        }

        public override IEnumerator Execute()
        {
            yield return _leftCard.PlayCardTypeEffect(_rightCard.Card);
            yield return new WaitForSeconds(0.5f);
            foreach(AnimatedAction action in _leftCard.Card.GetEffect(UserPresentation.GetEnemy()))
            {
                yield return action.Execute();
                yield return new WaitForSeconds(0.5f);
            }

            yield return new WaitForSeconds(0.5f);

            yield return _rightCard.PlayCardTypeEffect(_leftCard.Card);
            foreach (AnimatedAction action in _rightCard.Card.GetEffect(UserPresentation.GetLocal()))
            {
                yield return action.Execute();
                yield return new WaitForSeconds(0.5f);
            }

            yield return new WaitForSeconds(0.5f);

            _leftCard.MoveTo(_leftCard.transform.position + Vector3.up * 100f);
            _rightCard.MoveTo(_rightCard.transform.position + Vector3.up * 100f);
            yield return new WaitForSeconds(1);

            _leftCard.Delete();
            _rightCard.Delete();
        }
    }
}
