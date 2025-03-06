using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Utils
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        private static readonly object Lock = new();

        /// <summary>
        ///     Public accessor for the singleton instance.
        /// </summary>
        public static T instance
        {
            get
            {
                lock (Lock)
                {
                    if (_instance) return _instance;
                    
                    // Try to find an existing instance in the scene
                    _instance = FindAnyObjectByType<T>();

                    if (_instance == null)
                    {
                        // Create a new GameObject if no instance exists
                        Debug.Log(
                            $"[Singleton] No instance of {typeof(T)} found in the scene. Creating a new one.");
                        var singletonGo = new GameObject($"{typeof(T)} (Singleton)");
                        _instance = singletonGo.AddComponent<T>();
                    }
                    else
                    {
                        Debug.Log(
                            $"[Singleton] Found existing instance of {typeof(T)}: {_instance.gameObject.name}");
                    }

                    // Make the instance persistent
                    DontDestroyOnLoad(_instance.gameObject);

                    return _instance;
                }
            }
        }

        /// <summary>
        ///     Ensures no duplicate instances are created in the scene.
        /// </summary>
        protected virtual void Awake()
        {
            // Check if an instance already exists
            if (_instance != null && _instance != this)
            {
                Debug.LogError(
                    $"[Singleton] Duplicate instance of {typeof(T)} detected! Destroying the duplicate: {gameObject.name}");
                Destroy(gameObject);
                return;
            }

            _instance = this as T;
            DontDestroyOnLoad(gameObject);

            Debug.Log($"[Singleton] {typeof(T)} instance initialized: {gameObject.name}");
        }
    }
}