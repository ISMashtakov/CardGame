using CardGame.Game.Cards;
using System.Collections;
using UnityEngine;

namespace CardGame.Game.Actions
{
    public class BurningCard : AnimatedAction
    {
        CardPresenter _card;

        public BurningCard(CardPresenter card)
        {
            _card = card;
        }

        public override IEnumerator Execute()
        {
            GameObject fire = GameObject.Instantiate(GeneralStorage.GetInstanse().FirePrefab, _card.transform);
            fire.GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = _card.GetComponent<SpriteRenderer>().sortingOrder + 1;
            yield return new WaitForSeconds(2f);
            GameObject.Destroy(fire);
        }
    }
}
