using Mirror;
using UnityEngine;

namespace CardGame.Web{
    public class ConnectionManager : NetworkManager
    {
        Network _network;
        public override void Start()
        {
            _network = Network.GetInstanse();
        }

        public override void OnServerConnect(NetworkConnectionToClient conn)
        {
            base.OnServerConnect(conn);
            Debug.Log("OnServerConnect");
            _network.OnConnect();
        }

        public override void OnServerDisconnect(NetworkConnectionToClient conn)
        {
            base.OnServerDisconnect(conn);
            Debug.Log("OnServerDisconnect");
            _network.OnDisconnect();
        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            Debug.Log("OnStartServer");
            _network.OnStart(true);
        }

        public override void OnStopServer()
        {
            base.OnStopServer();
            Debug.Log("OnStopServer");
            _network.OnStop();
        }

        public override void OnClientConnect()
        {
            base.OnClientConnect();
            Debug.Log("OnClientConnect");
            _network.OnStart(false);
            _network.OnConnect();
        }

        public override void OnClientDisconnect()
        {
            base.OnClientDisconnect();
            Debug.Log("OnClientDisconnect");
            _network.OnStop();
            _network.OnDisconnect();
        }

    }
}
