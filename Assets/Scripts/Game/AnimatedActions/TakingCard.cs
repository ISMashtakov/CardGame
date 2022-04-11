using CardGame.Game.Cards;
using System.Collections;
using UnityEngine;

namespace CardGame.Game.Actions
{
    public class TakingCard : AnimatedAction
    {
        UserPresentation _user;
        public TakingCard(UserPresentation user)
        {
            _user = user;
        }

        public override IEnumerator Execute()
        {
            if (_user.IsLocal())
            {
                Card card = _user.Deck.Pop();
                CardPresenter cardPresenter = CardFactory.Create(card);
                cardPresenter.transform.position = _user.Deck.Position;
                cardPresenter.SetLayer(100);
                yield return new WaitForSeconds(1);
                _user.Hand.AddCard(cardPresenter);
            }
            else
            {
                Card card = _user.Deck.Pop();
                CardPresenter cardPresenter = CardFactory.Create(card);
                _user.Hand.AddCard(cardPresenter);
            }

        }
    }
}
