using CardGame.Web.Exceptions;
using CardGame.Web.Messages;
using Mirror;
using UnityEngine;
using UnityEngine.Events;

namespace CardGame.Web
{
    public class Network : Singletone<Network>
    {
        public UnityEvent OnConnectListener = new UnityEvent();

        public bool? IsHost { get; private set; } = null;
        public bool IsConnected { get; private set; } = false;

        public void OnStart(bool isHost)
        {
            IsHost = isHost;
        }

        public void OnStop()
        {
            IsHost = null;
        }

        public void OnConnect()
        {
            IsConnected = true;
            OnConnectListener.Invoke();
        }

        public void OnDisconnect()
        {
            IsConnected = false;
        }

        public void Send<T>(T message) where T : struct, NetworkMessage
        {
            if (!IsConnected || !IsHost.HasValue)
            {
                throw new NotConnectedYetException();
            }

            if (IsHost.Value)
            {
                NetworkServer.SendToAll(message);
            }
            else
            {
                NetworkClient.Send(message);
            }

        }
    }
}

