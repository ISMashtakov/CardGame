using CardGame.Game.Actions;
using CardGame.Game.Cards;
using UnityEngine;
using UnityEngine.Events;

namespace CardGame.Game
{
    public class CardInput : MonoSingletone<CardInput>
    {
        CardPresenter _dragedCard = null;
        CardPresenter _lastTapedCard = null;
        float _lastTapTime = 0;
        bool _inputEnable = true;

        public UnityEvent OnDropCard;
        public UnityEvent OnTap;
        public UnityEvent<CardPresenter> OnDoubleTap;

        private void Start()
        {
            AnimatedActionsController.GetInstanse().OnStartAnimationEvent.AddListener(() => _inputEnable = false);
            AnimatedActionsController.GetInstanse().OnEndAnimationEvent.AddListener(() => _inputEnable = true);
        }

        void Update()
        {
            if (!_inputEnable)
            {
                return;
            }
            /*
            if (Input.touchCount > 0)
            {
                Touch touch = Input.touches[0];
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        onTouchDown(touch.position);
                        break;
                    case TouchPhase.Moved:
                    case TouchPhase.Stationary:
                        onTouch(touch.position);
                        break;
                    case TouchPhase.Canceled:
                    case TouchPhase.Ended:
                        onTouchUp(touch.position);
                        break;
                }
            }
            */
            if (Input.GetMouseButtonDown(0))
            {
                onTouchDown(Input.mousePosition);
            }
            if (Input.GetMouseButton(0))
            {
                onTouch(Input.mousePosition);
            }
            if (Input.GetMouseButtonUp(0))
            {
                onTouchUp(Input.mousePosition);
            }
        }

        IDropCard RaycastIDropCard(Vector3 position)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(position), out hit, float.MaxValue, Layers.OnDropCard))
            {
                return hit.collider.gameObject.GetComponent<IDropCard>();
            }
            return null;
        }

        CardPresenter RaycastCard(Vector3 position)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(position), out hit, float.MaxValue, Layers.Card))
            {
                return hit.collider.gameObject.GetComponent<CardPresenter>();
            }
            return null;
        }

        void onTouchDown(Vector3 position)
        {
            OnTap.Invoke();
            if (_dragedCard)
            {
                return;
            }

            CardPresenter hitCard = RaycastCard(position);
            if (!hitCard)
            {
                return;
            }
            _dragedCard = hitCard;

            if (_lastTapedCard == hitCard && Time.time - _lastTapTime < 0.5f) //Double Tap
            {
                OnDoubleTap.Invoke(hitCard);
            }
            else
            {
                _lastTapedCard = hitCard;
                _lastTapTime = Time.time;
            }
        }

        void onTouch(Vector3 position)
        {
            if (_dragedCard)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(position);
                pos.z = _dragedCard.transform.position.z;
                _dragedCard.MoveTo(pos, float.MaxValue);
            }
        }

        void onTouchUp(Vector3 position)
        {
            if (_dragedCard)
            {
                IDropCard hit = RaycastIDropCard(position);
                hit?.OnDropCard(_dragedCard);
                _dragedCard = null;
                OnDropCard.Invoke();
            }
        }
    }
}