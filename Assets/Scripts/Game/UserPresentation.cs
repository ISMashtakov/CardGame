namespace CardGame.Game
{
    public class UserPresentation
    {
        public IHand Hand { get; private set; }
        public IDeck Deck { get; private set; }

        private UserPresentation(IHand hand, IDeck deck)
        {
            Hand = hand;
            Deck = deck;
        }

        public static UserPresentation GetLocal()
        {
            return new UserPresentation(PlayerHand.GetInstanse(), PlayerDeck.GetInstanse());
        }

        public static UserPresentation GetEnemy()
        {
            return new UserPresentation(EnemyHand.GetInstanse(), EnemyDeck.GetInstanse());
        }

        public bool IsLocal()
        {
            return Hand is PlayerHand;
        }

        public bool IsEnemy()
        {
            return !IsLocal();
        }

        public UserPresentation GetOpposite()
        {
            if(IsLocal())
            {
                return GetEnemy();
            }

            return GetLocal();
        }
    }
}
