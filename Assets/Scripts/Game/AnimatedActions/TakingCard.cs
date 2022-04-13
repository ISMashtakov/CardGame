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
                CardPresenter cardPresenter = card.Create();
                cardPresenter.transform.position = _user.Deck.Position;
                cardPresenter.SetLayer(100);
                yield return new WaitForSeconds(1);
                _user.Hand.AddCard(cardPresenter);
            }
            else
            {
                Card card = _user.Deck.Pop();
                CardPresenter cardPresenter = card.Create();
                _user.Hand.AddCard(cardPresenter);
                cardPresenter.Delete();
            }

        }
    }
}
