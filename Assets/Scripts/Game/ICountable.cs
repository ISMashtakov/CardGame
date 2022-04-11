using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CardGame.Game
{
    public interface ICountable
    {
        public UnityEvent<int> OnChangeCount { get; }
    }
}
