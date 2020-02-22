using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T>
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance != null)
                return instance;
            else
                Debug.LogError($"Instance of {typeof(T).Name} not set.");
            return default;
        }
        set
        {
            if (instance == null)
                instance = value;
            else
                Debug.LogError($"Instance of {typeof(T).Name} is already set.");
        }
    }

}
