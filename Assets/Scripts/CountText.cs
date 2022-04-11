using UnityEngine;

namespace CardGame.Game
{
    public class CountText : MonoBehaviour
    {
        [SerializeField] GameObject _countableObject;
        ICountable _obj;
        [SerializeField] TextMesh _text;

        private void Start()
        {
            _obj = _countableObject.GetComponent<ICountable>();
            _obj.OnChangeCount.AddListener(UpdateCount);
        }

        private void UpdateCount(int count)
        {
            _text.text = count.ToString();
        }
    }
}
