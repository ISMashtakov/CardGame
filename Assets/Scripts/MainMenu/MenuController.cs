using CardGame.Web;
using CardGame.Web.Messages;
using UnityEngine.SceneManagement;

namespace CardGame.MainMenu
{
    public class MenuController : MonoSingletone<MenuController>
    {
        private void Start()
        {
            Network.GetInstanse().OnConnectListener.AddListener(AllConnected);
        }

        void AllConnected()
        {
            UnityEngine.Debug.Log("ALl COnnected");
            SceneManager.LoadScene(1);
        }
    }
}
