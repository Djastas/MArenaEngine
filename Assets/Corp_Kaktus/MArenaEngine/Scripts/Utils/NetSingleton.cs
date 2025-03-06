using Unity.Netcode;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Utils
{
    public class NetSingleton<T> : NetworkBehaviour where T : NetSingleton<T>
    {
        private static T _instance;
        private static readonly object Lock = new ();

        public static T instance
        {
            get
            {
                if (_instance) return _instance;

                lock (Lock)
                {
                    // Find any existing instances in scene
                    _instance = FindAnyObjectByType<T>();
                    if (_instance)
                    {
                        Debug.Log($"Found existing instance of {typeof(T).Name} in scene.");
                        return _instance;
                    }

                    // If no instance exists, create a new GameObject with this component
                    
                    Debug.Log($"Creating new instance of {typeof(T).Name}");
                    var singletonObject = new GameObject(typeof(T).Name);
                    _instance = singletonObject.AddComponent<T>();
                    DontDestroyOnLoad(singletonObject);
                    Debug.Log($"Instance of {typeof(T).Name} created and set to not destroy on load.");
                }
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            // Check if an instance already exists
            if (_instance != null && _instance != this)
            {
                // If so, destroy this instance as it's a duplicate
                Debug.LogWarning($"Duplicate instance of {typeof(T).Name} detected! Destroying this instance.");
                Destroy(gameObject);
                return;
            }
        
            _instance = (T)this;
            Debug.Log($"{typeof(T).Name} initialized.");
        }
    }
}