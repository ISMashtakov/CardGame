using Mirror;
using UnityEngine;

namespace CardGame.Web{
    public class ConnectionManager : NetworkManager
    {
        public Server Server = new Server();
        
        public override void OnServerConnect(NetworkConnectionToClient conn)
        {
            base.OnServerConnect(conn);
            Debug.Log("OnServerConnect");
            Server.AddClient(conn);
        }

        public override void OnServerDisconnect(NetworkConnectionToClient conn)
        {
            base.OnServerDisconnect(conn);
            Server.DeleteClient(conn);
            Debug.Log("OnServerDisconnect");

        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            Server.Start();
            Debug.Log("OnStartServer");
        }

        public override void OnStopServer()
        {
            base.OnStopServer();
            Server.Stop();
            Debug.Log("OnStopServer");
        }

        public override void OnClientConnect()
        {
            base.OnClientConnect();
            Network.GetInstanse().OnConnect();
            Debug.Log("OnClientConnect");
        }

        public override void OnClientDisconnect()
        {
            base.OnClientDisconnect();
            Network.GetInstanse().OnDisconnect();
            Debug.Log("OnClientDisconnect");
        }

    }
}
