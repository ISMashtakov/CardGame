using CardGame.Game.Cards.Weapons;
using CardGame.Game.Cards.Types;
using System.Collections.Generic;
using CardGame.Game.Actions;


namespace CardGame.Game.Cards.Mace
{
    public class MaceBlock : Card
    {
        public MaceBlock() : base(
            "Защита",
            $"Возьмите в руку {1} карту",
            Weapon.Mace,
            CardType.DEFEND
            )
        { }

        public override List<AnimatedAction> GetEffect(UserPresentation user)
        {
            return new List<AnimatedAction>
            {
                new TakingCard(user)
            };
        }

        public static MaceBlock FromString(string data)
        {
            return new MaceBlock();
        }
    }
}
