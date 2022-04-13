using CardGame.Game.Cards.Weapons;
using CardGame.Game.Cards.Types;
using System.Collections.Generic;
using CardGame.Game.Actions;

namespace CardGame.Game.Cards.Mace
{
    public class MaceReadMovement : Card
    {
        public MaceReadMovement() : base(
            "Прочитать движения",
            $"<b>Подглядеть 3</b>",
            Weapon.Mace,
            CardType.TRICK
            )
        { }

        public override List<AnimatedAction> GetEffect(UserPresentation user)
        {
            return new List<AnimatedAction>
            {
                
            };
        }

        public static MaceReadMovement FromString(string data)
        {
            return new MaceReadMovement();
        }
    }
}
