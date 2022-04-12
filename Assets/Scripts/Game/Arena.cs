using CardGame.Game.Actions;
using CardGame.Game.Cards;
using UnityEngine;
using UnityEngine.Events;

namespace CardGame.Game
{
    public class Arena : MonoSingletone<Arena>, IDropCard
    {
        public UnityEvent<CardPresenter> OnPlayRightCard = new UnityEvent<CardPresenter>();

        [SerializeField] Transform _leftPoint;
        [SerializeField] Transform _rightPoint;

        CardPresenter _leftCard;
        CardPresenter _rightCard;

        PlayerHand _hand;
        AnimatedActionsController _animatedActionsController;

        private void Start()
        {
            _hand = PlayerHand.GetInstanse();
            _animatedActionsController = AnimatedActionsController.GetInstanse();
        }

        public void OnDropCard(CardPresenter cardPresenter)
        {
            if(_rightCard == null)
            {
                _hand.RemoveCard(cardPresenter);
                cardPresenter.DisableInteractions();
                cardPresenter.transform.parent = transform;
                cardPresenter.MoveTo(_rightPoint.position);
                cardPresenter.SetLayer(1);
                _rightCard = cardPresenter;
                OnPlayRightCard.Invoke(_rightCard);
                CheckEndOfTurn();
            }
        }

        public void SetLeftCard(CardPresenter cardPresenter)
        {
            if (_leftCard == null)
            {
                cardPresenter.DisableInteractions();
                cardPresenter.transform.parent = transform;
                cardPresenter.MoveTo(_leftPoint.position);
                cardPresenter.SetLayer(1);
                _leftCard = cardPresenter;
                CheckEndOfTurn();
            }
        }

        void CardsInteraction()
        {
            _animatedActionsController.AddAction(new InteractingCards(_leftCard, _rightCard));
        }

        void CheckEndOfTurn()
        {
            if (_leftCard != null && _rightCard != null)
            {
                CardsInteraction();
            }
        }
    }
}
