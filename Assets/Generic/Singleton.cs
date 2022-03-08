using UnityEngine;

namespace Utils
{
    public class Singleton<T>
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
            set {
                if (instance == null) {
                    instance = value;
                     Debug.LogWarning($"Instance of {typeof(T).Name} set.");
                } else {
                    Debug.LogError($"Instance of {typeof(T).Name} is already set.");
                }
            }
        }
    }
}
