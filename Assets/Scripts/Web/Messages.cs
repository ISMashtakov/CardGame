using Mirror;
using System.Collections.Generic;

namespace CardGame.Web.Messages
{
    public struct PlayedCardMessage : NetworkMessage
    {
        public string cardTypeName;
        public string data;

        public PlayedCardMessage(string cardTypeName, string data)
        {
            this.cardTypeName = cardTypeName;
            this.data = data;
        }
    }
}
