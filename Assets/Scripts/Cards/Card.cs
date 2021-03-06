using CardGame.Game.Cards.Weapons;
using CardGame.Game.Cards.Types;
using System;
using System.Collections.Generic;
using CardGame.Game.Actions;

namespace CardGame.Game.Cards
{
    public abstract class Card
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public Weapon Weapon { get; set; }
        public CardType CardType { get; set; }

        protected Card(string name, string text, Weapon weapon, CardType cardType)
        {
            Name = name;
            Text = text;
            Weapon = weapon;
            CardType = cardType;
        }

        public virtual bool WillBePlayed(Card other)
        {
            switch (CardType)
            {
                case CardType.ATTACK:
                    return other.CardType != CardType.DEFEND;
                case CardType.DEFEND:
                    return other.CardType != CardType.TRICK;
                case CardType.TRICK:
                    return other.CardType != CardType.ATTACK;
            }
            throw new NotImplementedException("Not handled case for CardType");
        }

        public abstract List<AnimatedAction> GetEffect(UserPresentation user);

        public override string ToString() {
            return Name;
        }
    }
}
