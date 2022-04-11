using CardGame.Web.Exceptions;
using CardGame.Web.Messages;
using Mirror;
using System;
using System.Collections.Generic;

namespace CardGame.Web
{
    public class Server
    {
        Dictionary<Type, Action> _handlers = new Dictionary<Type, Action>();

        public bool IsStarted { get; private set; } = false;

        bool AllConencted => NetworkServer.connections.Count == 2;

        public void Start()
        {
            RegisterAllHandlers();
            if (IsStarted)
            {
                throw new ProblemWithServerException("Try start started server");
            }
            IsStarted = true;
        }

        public void Stop()
        {
            NetworkServer.ClearHandlers();
            if (!IsStarted)
            {
                throw new ProblemWithServerException("Try stop stoped server");
            }
            IsStarted = false;
        }

        public void AddClient(NetworkConnection con)
        {
            if (AllConencted)
            {
                OnAllConnect();
            }
        }

        public void DeleteClient(NetworkConnectionToClient connection)
        {
        }

        public void AddHandler<T>() where T : struct, NetworkMessage
        {
            if (_handlers.ContainsKey(typeof(T)))
            {
                return;
            }

            _handlers.Add(typeof(T), () => NetworkServer.RegisterHandler<T>(Recieve));
            _handlers[typeof(T)]();
        }

        void RegisterAllHandlers()
        {
            foreach(Action action in _handlers.Values)
            {
                action();
            }
        }

        void Recieve<T>(NetworkConnectionToClient con, T mes)where T : struct, NetworkMessage
        {
            foreach (int id in NetworkServer.connections.Keys)
            {
                if(con.connectionId != id)
                {
                    NetworkServer.connections[id].Send(mes);
                }
            }
        }

        void OnAllConnect()
        {
            NetworkServer.SendToAll(new AllConectedMessage());
        }
    }
}
