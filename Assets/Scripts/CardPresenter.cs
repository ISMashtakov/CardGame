using CardGame.Game.Cards.Types;
using System.Collections;
using UnityEngine;

using UnityEngine.Events;

namespace CardGame.Game.Cards
{
    [RequireComponent(typeof(MoveAnimator))]
    [RequireComponent(typeof(CardView))]
    public class CardPresenter : MonoBehaviour
    {
        MoveAnimator _moveAnimator;
        BoxCollider _boxCollider;
        public Card Card { get; set; }
        [HideInInspector] public UnityEvent<int> OnLayerChangedEvent = new UnityEvent<int>();

        protected virtual void Awake()
        {
            _moveAnimator = GetComponent<MoveAnimator>();
            _boxCollider = GetComponent<BoxCollider>();
        }

        public void MoveTo(Vector3 to, float speed = 15f)
        {
            _moveAnimator.MoveTo(to, speed);
        }

        public void SetLayer(int layer)
        {
            OnLayerChangedEvent.Invoke(layer);
        }

        public float GetWidth()
        {
            return _boxCollider.size.x;
        }

        public void DisableInteractions()
        {
            _boxCollider.enabled = false;
        }

        public void Delete()
        {
            Destroy(gameObject);
        }

        public IEnumerator PlayCardTypeEffect(Card other)
        {
            AnimatedEffect effectPrefab = CardTypeStorage.GetInstanse().GetAnimationEffect(Card.CardType, Card.WillBePlayed(other));
            AnimatedEffect effect = Instantiate(effectPrefab, transform);
            effect.transform.position = transform.position;
            effect.SetLayer(GetComponent<SpriteRenderer>().sortingOrder + 5);
            yield return new WaitUntilEvent(effect.OnEndAnimation);
        }
    }
}
