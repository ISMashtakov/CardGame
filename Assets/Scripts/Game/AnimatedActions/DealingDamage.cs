using CardGame.Game.Cards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CardGame.Game.Actions
{
    public class DealingDamage : AnimatedAction
    {
        UserPresentation _user;
        int _number;

        public DealingDamage(UserPresentation user, int number)
        {
            _user = user;
            _number = number;
        }

        public override IEnumerator Execute()
        {
            for (int i = 0; i < _number; i++)
            {
                if (_user.IsLocal())
                {
                    Card card = _user.Deck.Pop();
                    CardPresenter cardPresenter = card.Create();
                    cardPresenter.transform.position = _user.Deck.Position;
                    cardPresenter.SetLayer(100);
                    yield return new WaitForSeconds(0.5f);
                    yield return new BurningCard(cardPresenter).Execute();
                    cardPresenter.Delete();
                    yield return new WaitForSeconds(1f);
                }
                else
                {
                    _user.Deck.Pop();
                }
            }
        }
    }
}