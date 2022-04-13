using System;
using UnityEngine;

namespace CardGame.Game.Cards.Types
{
    public class CardTypeStorage : MonoSingletone<CardTypeStorage>
    {
        public Sprite AttackCardBack;
        public AnimatedEffect AttackGoodEffect;
        public AnimatedEffect AttackBadEffect;

        public Sprite DefentCardBack;
        public AnimatedEffect DefendGoodEffect;
        public AnimatedEffect DefendBadEffect;

        public Sprite TrickCardBack;
        public AnimatedEffect TrickGoodEffect;
        public AnimatedEffect TrickBadEffect;

        public AnimatedEffect GetAnimationEffect(CardType cardType, bool willUse)
        {
            switch (cardType)
            {
                case CardType.ATTACK:
                    return (willUse) ? AttackGoodEffect : AttackBadEffect;
                case CardType.DEFEND:
                        return (willUse) ? DefendGoodEffect : DefendBadEffect;
                case CardType.TRICK:
                    return (willUse) ? TrickGoodEffect : TrickBadEffect;
            }

            throw new NotImplementedException();
        }
    }
}