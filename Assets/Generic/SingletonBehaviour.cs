using UnityEngine;

namespace Utils
{
    public class SingletonBehaviour<T> : MonoBehaviour where T : class
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
        }

        protected void Awake()
        {
            if (instance == null)
                instance = this as T;
            else
            {
                Debug.LogError($"Instance of {typeof(T).Name} already set.");
                Destroy(gameObject);
                return;
            }
        }
    }
}
