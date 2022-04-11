using CardGame.Game.Cards;
using UnityEngine;

namespace CardGame.Game
{
    public class ZoomCardField : MonoSingletone<ZoomCardField>
    {
        CardPresenter _zoomedCard;
        [SerializeField] GameObject Shadow;

        void Start()
        {
            CardInput.GetInstanse().OnDoubleTap.AddListener(SetCard);
            CardInput.GetInstanse().OnTap.AddListener(DeselectCard);
        }

        void SetCard(CardPresenter card)
        {
            if (_zoomedCard)
            {
                DeselectCard();
            }
            _zoomedCard = CardFactory.Create(card.Card, transform);
            _zoomedCard.transform.position = Vector3.zero;
            _zoomedCard.enabled = false;
            _zoomedCard.SetLayer(1001);
            _zoomedCard.gameObject.AddComponent<ZoomAnimator>().ZoomTo(_zoomedCard.transform.localScale.normalized * 5f, 10f);
            Shadow.SetActive(true);
        }

        void DeselectCard()
        {
            if (_zoomedCard)
            {
                Destroy(_zoomedCard.gameObject);
                _zoomedCard = null;
                Shadow.SetActive(false);
            }
        }
    }
}
