using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CardGame.Game.Actions
{
    public class AnimatedActionsController : MonoSingletone<AnimatedActionsController>
    {
        Queue<AnimatedAction> _actions = new Queue<AnimatedAction>();
        bool _nowAnimating = false;
        public bool NowAnimating
        {
            get => _nowAnimating; 
            private set
            {
                if (value) {
                    OnStartAnimationEvent.Invoke();
                }
                else
                {
                    OnEndAnimationEvent.Invoke();
                }
                _nowAnimating = value;
            }
        }

        public UnityEvent OnStartAnimationEvent = new UnityEvent();
        public UnityEvent OnEndAnimationEvent = new UnityEvent();

        public void AddAction(AnimatedAction action)
        {
            _actions.Enqueue(action);
            ExecuteNext();
        }

        void ExecuteNext()
        {
            if (!NowAnimating && _actions.Count > 0)
            {
                NowAnimating = true;
                AnimatedAction action = _actions.Dequeue();
                StartCoroutine(action.Execute(AfterAction));
            }
        }

        void AfterAction()
        {
            NowAnimating = false;
            ExecuteNext();
        }
    }
}
