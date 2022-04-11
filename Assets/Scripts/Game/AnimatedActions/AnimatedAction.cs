using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame.Game.Actions
{
    public abstract class AnimatedAction
    {
        public abstract IEnumerator Execute();
        public IEnumerator Execute(Action after)
        {
            yield return Execute();
            after();
        }
        public IEnumerator Execute(Action after, Action before)
        {
            before();
            yield return Execute();
            after();
        }
    }
}
