using Unity.Netcode;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Loaders
{
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject serverPrefab;
        private void Start()
        {
            if (!NetworkManager.Singleton.IsServer) return;
            var instance = Instantiate(serverPrefab);
            var instanceNetworkObject = instance.GetComponent<NetworkObject>();
            instanceNetworkObject.Spawn();
        }
    }
}