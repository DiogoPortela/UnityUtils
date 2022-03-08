using UnityEngine;

namespace Utils
{
    public class SingletonBehaviour<T> : MonoBehaviour where T : class
    {
        private static T instance;
        public static T Instance {
            get {
                if (instance != null) { 
                    return instance;
                } else {
                    Debug.LogError($"Instance of {typeof(T).Name} not set.");
                }
                return null;
            }
        }

        protected void Awake() {
            if (instance == null) {
                instance = this as T;
                Debug.LogWarning($"Instance of {typeof(T).Name} set.");
            } else {
                Debug.LogError($"Instance of {typeof(T).Name} already set.");
                Destroy(gameObject);
                return;
            }
        }

        protected void OnDestroy() {
            if (instance == this as T) {
                instance = null;
                Debug.LogWarning($"Instance of {typeof(T).Name} destroyed.");
            }
        }
    }
}
