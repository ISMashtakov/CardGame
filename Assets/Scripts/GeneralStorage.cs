using UnityEngine;

namespace CardGame.Game.Cards
{
    public class GeneralStorage : MonoSingletone<GeneralStorage>
    {
        public GameObject CardTemplate;
        public GameObject FirePrefab;
    }
}