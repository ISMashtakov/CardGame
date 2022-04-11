using CardGame.Web.Messages;
using UnityEngine.SceneManagement;

namespace CardGame.MainMenu
{
    public class MenuController : MonoSingletone<MenuController>
    {
        private void Start()
        {
            CardGame.Web.Network.GetInstanse().AddMessageListener<AllConectedMessage>(AllConnected);
        }

        void AllConnected(AllConectedMessage mes)
        {
            SceneManager.LoadScene(1);
        }
    }
}
