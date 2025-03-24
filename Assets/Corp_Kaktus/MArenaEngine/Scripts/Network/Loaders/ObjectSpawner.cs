using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Loaders
{
    public class ObjectSpawner : MonoBehaviour
    {
        public UnityEvent<GameObject> onSpawn;
        
        [SerializeField] private GameObject serverPrefab;
        private void Start()
        {
            if (!NetworkManager.Singleton.IsServer) return;
            var instance = Instantiate(serverPrefab,transform.position,transform.rotation,transform);
            var instanceNetworkObject = instance.GetComponent<NetworkObject>();
            var instanceReceiver = instance.GetComponent<ObjectSpawnReceiver>();
            if (instanceReceiver)
            {
                instanceReceiver.onSpawn.AddListener(() => { onSpawn?.Invoke(instance);});
            }
            else
            {
                Debug.LogWarning("Spawn object not contain receiver. OnSpawn event will be not invoked.");
            }
            instanceNetworkObject.Spawn();
        }
    }
}