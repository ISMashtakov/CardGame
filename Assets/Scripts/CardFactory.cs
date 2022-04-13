using UnityEngine;

namespace CardGame.Game.Cards {
    public class CardFactory
    {
        static GameObject Template => GeneralStorage.GetInstanse().CardTemplate;
       
        public static CardPresenter Create(Card card, Transform parent)
        {
            CardPresenter cardPresenter = GameObject.Instantiate(Template, parent).GetComponent<CardPresenter>();
            cardPresenter.Card = card;
            return cardPresenter;
        }

        public static CardPresenter Create(Card card)
        {
            return Create(card, null);
        }


    }
    public static class CardExstension
    {
        public static CardPresenter Create(this Card card)
        {
            return CardFactory.Create(card);
        }

        public static CardPresenter Create(this Card card, Transform transform)
        {
            return CardFactory.Create(card, transform);
        }
    }
}
