using UnityEngine;
using UnityEngine.Events;

namespace CardGame.Game
{
    public class AnimatedEffect : MonoBehaviour
    {
        public UnityEvent OnEndAnimation = new UnityEvent();

        public void EndAnimation()
        {
            OnEndAnimation.Invoke();
            Destroy(gameObject);
        }

        public void SetLayer(int layer)
        {
            foreach (SpriteRenderer children in transform.GetComponentsInChildren<SpriteRenderer>())
            {
                children.sortingOrder = layer;
            }
        }
    }
}
