using Unity.Netcode;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Trash
{
    public class ObjectSpawner : MonoBehaviour
    {
        [Header("Warning: id for receiver and spawner should have equals")]
        public string id;
        public UnityEvent<GameObject> onSpawn;
        
        [FormerlySerializedAs("Prefab")] [FormerlySerializedAs("serverPrefab")] [SerializeField] private GameObject prefab;
        
        private GameObject _spawnedObject;
        private void Start()
        {
            if (!NetworkManager.Singleton.IsServer) return;
            _spawnedObject = Instantiate(prefab,transform.position,transform.rotation);
            var instanceNetworkObject = _spawnedObject.GetComponent<NetworkObject>();
            var instanceReceiver = _spawnedObject.GetComponent<ObjectSpawnReceiver>();
            if (!instanceReceiver)
            {
                Debug.LogWarning("Spawn object not contain receiver. OnSpawn event will be not invoked.",this);
            }
            instanceNetworkObject.Spawn();
        }
    }
}