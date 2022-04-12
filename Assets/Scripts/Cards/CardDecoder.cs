using CardGame.Web.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CardGame.Game.Cards {
    public static class CardDecoder
    {
        static IEnumerable<Type> types = Assembly.GetAssembly(typeof(Card)).GetTypes().Where(type => type.IsSubclassOf(typeof(Card)));
        public static Card Decode(PlayedCardMessage playedCardMessage)
        {
            foreach (Type type in types)
            {
                if (playedCardMessage.cardTypeName == type.FullName)
                {
                    return (Card)type.GetMethod("FromString").Invoke(null, new string[] { playedCardMessage.data });
                }
            }

            throw new NotImplementedException($"Decoding for {playedCardMessage.cardTypeName} not implemented");
        }
    }
}
