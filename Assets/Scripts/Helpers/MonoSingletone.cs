using System;
using UnityEngine;

public class MonoSingletone<T> : MonoBehaviour where T : MonoSingletone<T>
{
    protected static T _instance;
    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = (T)this;
        }
        else
        {
            throw new Exception($"More that instances of {typeof(T)}");
        }
    }

    protected static void CheckExists()
    {
        if (_instance == null)
        {
            throw new Exception($"Instanse of {typeof(T)} not initialized");
        }
    }
    public static T GetInstanse()
    {
        CheckExists();
        return _instance;
    }
}