using CardGame.Web.Messages;
using System;

namespace CardGame.Game.Cards {
    public static class CardDecoder
    {
        public static Card Decode(PlayedCardMessage playedCardMessage)
        {
            if (playedCardMessage.cardTypeName == typeof(MaceHit).FullName)
            {
                return MaceHit.FromString(playedCardMessage.data);
            }

            throw new NotImplementedException($"Decoding for {playedCardMessage.cardTypeName} not implemented");
        }
    }
}
