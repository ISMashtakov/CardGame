using CardGame.Game.Cards;


namespace CardGame.Game
{
    public interface IHand: ICountable
    {
        public void AddCard(CardPresenter cardPresenter);
        public void RemoveCard(CardPresenter cardPresenter);
    }
}
