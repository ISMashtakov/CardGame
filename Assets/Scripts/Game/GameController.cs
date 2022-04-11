using CardGame.Game.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame.Game
{
    public class GameController : MonoSingletone<GameController>
    {
        AnimatedActionsController _animatedActionsController;
        protected override void Awake()
        {
            base.Awake();
            _animatedActionsController = AnimatedActionsController.GetInstanse();
        }
        void Start()
        {
            for(int i = 0; i < 2; i++)
            {
                _animatedActionsController.AddAction(new TakingCard(UserPresentation.GetLocal()));
            }
        }
    }
}
