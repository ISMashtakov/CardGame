using CardGame.Game.Actions;
using CardGame.Game.Cards.Mace;

namespace CardGame.Game
{
    public class GameController : MonoSingletone<GameController>
    {
        AnimatedActionsController _animatedActionsController;
        PlayingCardController _playingCardController;
        public InitiativeController InitiativeController;
        
        protected override void Awake()
        {
            base.Awake();
            _animatedActionsController = AnimatedActionsController.GetInstanse();
        }

        void Start()
        {
            _playingCardController = new PlayingCardController();

            PlayerDeck.GetInstanse().SetDeck(DeckStorages.GetMaceDeck());
            EnemyDeck.GetInstanse().SetDeck(DeckStorages.GetMaceDeck());

            for (int i = 0; i < 5; i++)
            {
                _animatedActionsController.AddAction(new TakingCard(UserPresentation.GetLocal()));
                _animatedActionsController.AddAction(new TakingCard(UserPresentation.GetEnemy()));
            }
        }

        public void EndInteraction()
        {
            _animatedActionsController.AddAction(new TakingCard(UserPresentation.GetLocal()));
            _animatedActionsController.AddAction(new TakingCard(UserPresentation.GetEnemy()));
        }
    }
}
