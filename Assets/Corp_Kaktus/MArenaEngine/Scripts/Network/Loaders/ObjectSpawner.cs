using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Loaders
{
    public class ObjectSpawner : MonoBehaviour
    {
        public string id;
        public UnityEvent<GameObject> onSpawn;
        
        [SerializeField] private GameObject serverPrefab;

       
        
        private GameObject _spawnedObject;
        private void Start()
        {
            if (!NetworkManager.Singleton.IsServer) return;
            _spawnedObject = Instantiate(serverPrefab,transform.position,transform.rotation,transform);
            var instanceNetworkObject = _spawnedObject.GetComponent<NetworkObject>();
            var instanceReceiver = _spawnedObject.GetComponent<ObjectSpawnReceiver>();
            if (instanceReceiver)
            {
                instanceReceiver.findLinkId = id;
            }
            else
            {
                Debug.LogWarning("Spawn object not contain receiver. OnSpawn event will be not invoked.");
            }
            instanceNetworkObject.Spawn();
        }
    }
}