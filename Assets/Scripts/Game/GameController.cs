using CardGame.Game.Actions;

namespace CardGame.Game
{
    public class GameController : MonoSingletone<GameController>
    {
        AnimatedActionsController _animatedActionsController;
        PlayingCardController _playingCardController;
        protected override void Awake()
        {
            base.Awake();
            _animatedActionsController = AnimatedActionsController.GetInstanse();
           
        }

        void Start()
        {
            _playingCardController = new PlayingCardController();
            for (int i = 0; i < 2; i++)
            {
                _animatedActionsController.AddAction(new TakingCard(UserPresentation.GetLocal()));
                _animatedActionsController.AddAction(new TakingCard(UserPresentation.GetEnemy()));
            }
        }
    }
}
