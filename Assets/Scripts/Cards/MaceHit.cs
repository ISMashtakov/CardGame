using CardGame.Game.Cards.Weapons;
using CardGame.Game.Cards.Types;
using System.Collections.Generic;
using CardGame.Game.Actions;

namespace CardGame.Game.Cards
{
    public class MaceHit : Card
    {
        public MaceHit(): base(
            "Нанести 3 урона",
            Weapon.Mace,
            CardType.ATTACK
            ) {}

        public override List<AnimatedAction> GetEffect(UserPresentation user)
        {
            return new List<AnimatedAction>
            {
                new DealingDamage(user.GetOpposite(), 3)
            };
        }
    }
}
