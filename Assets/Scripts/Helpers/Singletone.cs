using System;

public class Singletone <T> where T : new()
{
    protected static T _instance;

    protected static void CheckExists()
    {
        if (_instance == null)
        {
            throw new Exception($"Instanse of {typeof(T)} not initialized");
        }
    }
    public static T GetInstanse()
    {
        if (_instance == null)
        {
            _instance = new T();
        }

        return _instance;
    }
}
