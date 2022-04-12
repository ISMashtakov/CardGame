using CardGame.Web;
using UnityEngine;
using UnityEngine.SceneManagement;
using Network = CardGame.Web.Network;

namespace CardGame.MainMenu
{
    public class MenuController : MonoSingletone<MenuController>
    {
        [SerializeField] ConnectionManager _connectionManager;

        [SerializeField] GameObject _mainMenu;
        [SerializeField] GameObject _waitingCall;
        [SerializeField] GameObject _calling;

        MenuController()
        {
            Network.GetInstanse().OnConnectListener.AddListener(StartGame);
        }

        public void OnClickWaitCall()
        {
            _connectionManager.StartServer();
            _mainMenu.SetActive(false);
            _waitingCall.SetActive(true);
        }

        public void OnClickCall()
        {
            _connectionManager.StartClient();
            _mainMenu.SetActive(false);
            _calling.SetActive(true);
        }

        public void OnClickCancelWaitingCall()
        {
            _connectionManager.StopServer();
            _waitingCall.SetActive(false);
            _mainMenu.SetActive(true);
        }

        public void OnClickCancelCalling()
        {
            _connectionManager.StopClient();
            _calling.SetActive(false);
            _mainMenu.SetActive(true);
        }

        public void OnClickExit()
        {
            Application.Quit();
        }

        void StartGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}
