using Mirror;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame.Web
{
    public class Network : Singletone<Network>
    {
        ConnectionManager _connectionManager;
        Dictionary<Type, Action> _handlers = new Dictionary<Type, Action>();

        public Network()
        {
            _connectionManager = GameObject.FindObjectOfType<ConnectionManager>();
        }

        public void OnConnect()
        {
            RegisterAllHandlers();
        }

        public void OnDisconnect()
        {
        }

        public void AddMessageListener<T>(Action<T> handler) where T: struct, NetworkMessage
        {
            if (_handlers.ContainsKey(typeof(T)))
            {
                return;
            }

            _handlers.Add(typeof(T), () => NetworkClient.RegisterHandler<T>(handler));
            _handlers[typeof(T)]();

            _connectionManager.Server.AddHandler<T>();
        }

        public void DeleteMessageListener<T>() where T : struct, NetworkMessage
        {
            NetworkClient.UnregisterHandler<T>();
        }

        void RegisterAllHandlers()
        {
            foreach (Action action in _handlers.Values)
            {
                action();
            }
        }
    }
}

