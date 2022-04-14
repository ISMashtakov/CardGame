using UnityEngine;
using Network = CardGame.Web.Network;

namespace CardGame.Game
{
    public class InitiativeController: MonoBehaviour
    {
        [SerializeField] Transform _enemyPos;
        [SerializeField] Transform _playerPos;
        MoveAnimator _moveAnimator;
        bool _isMy;
        public bool IsMy
        {
            get => _isMy; set
            {
                _isMy = value;
                UpdatePos();
            }
        }

        void Awake()
        {
            _moveAnimator = GetComponent<MoveAnimator>();
        }

        void Start()
        {
            IsMy = Network.GetInstanse().IsHost.Value;
            if (IsMy)
            {
                transform.position = _playerPos.position;
            }
            else
            {
                transform.position = _enemyPos.position;
            }
        }

        public void UpdatePos()
        {
            if (IsMy)
            {
                _moveAnimator.MoveTo(_playerPos.position, 15);
            }
            else
            {
                _moveAnimator.MoveTo(_enemyPos.position, 15);
            }
        }
    }
}
