using CardGame.Web.Exceptions;
using CardGame.Web.Messages;
using Mirror;
using System;
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
            return; // TODO 
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

        public void AddHandler<T>(Action<T> action) where T : struct, NetworkMessage
        {
            return; // TODO 
            if (!IsConnected || !IsHost.HasValue)
            {
                throw new NotConnectedYetException();
            }

            if (IsHost.Value)
            {
                NetworkServer.RegisterHandler<T>((_, m) => action(m));
            }
            else
            {
                NetworkClient.RegisterHandler(action);
            }
        }
    }
}

