using System;
using UnityEngine;

namespace CardGame.Game.Cards.Types
{
    public class CardTypeStorage : MonoSingletone<CardTypeStorage>
    {
        public Sprite AttackCardBack;

        public AnimatedEffect AttackGoodEffect;
        public AnimatedEffect AttackBadEffect;

        public AnimatedEffect GetAnimationEffect(CardType cardType, bool willUse)
        {
            switch (cardType)
            {
                case CardType.ATTACK:
                    if (willUse)
                    {
                        return AttackGoodEffect;
                    }
                    else
                    {
                        return AttackBadEffect;
                    }
                case CardType.DEFEND:
                    break;
                case CardType.MOVE:
                    break;
            }

            throw new NotImplementedException();
        }
    }
}