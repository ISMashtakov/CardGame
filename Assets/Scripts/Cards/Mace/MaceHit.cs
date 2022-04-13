using CardGame.Game.Cards.Weapons;
using CardGame.Game.Cards.Types;
using System.Collections.Generic;
using CardGame.Game.Actions;

namespace CardGame.Game.Cards.Mace
{
    public class MaceHit : Card
    {
        int _damage = 3;
        public MaceHit() : base(
            "Удар",
            $"Нанести {3} урона",
            Weapon.Mace,
            CardType.ATTACK
            ) {}

        public override List<AnimatedAction> GetEffect(UserPresentation user)
        {
            return new List<AnimatedAction>
            {
                new DealingDamage(user.GetOpposite(), _damage)
            };
        }

        public static MaceHit FromString(string data)
        {
            return new MaceHit();
        }
    }
}
