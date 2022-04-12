using CardGame.Game.Cards;
using CardGame.Web;
using CardGame.Web.Messages;
using UnityEngine;
using Network = CardGame.Web.Network;

namespace CardGame.Game {
    public class PlayingCardController
    {
        Arena _arena;
        Network _network;
        public PlayingCardController()
        {
            _arena = Arena.GetInstanse();
            _arena.OnPlayRightCard.AddListener(OnPlayCard);

            _network = Network.GetInstanse();
            _network.AddHandler<PlayedCardMessage>(OnMessage);
        }

        void OnMessage(PlayedCardMessage mes)
        {
            Card card = CardDecoder.Decode(mes);
            CardPresenter cardPresenter = CardFactory.Create(card);
            cardPresenter.transform.position = _arena.transform.position + Vector3.up * 10;
            _arena.SetLeftCard(cardPresenter);
        }

        void OnPlayCard(CardPresenter cardPresenter)
        {
            Card card = cardPresenter.Card;
            _network.Send(new PlayedCardMessage(card.GetType().FullName, card.ToString()));
        }
    }
}
