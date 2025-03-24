using System.Linq;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Trash
{
    public class ObjectSpawnReceiver : NetworkBehaviour
    {
        public UnityEvent onSpawn;

        public string findLinkId;
        
        protected override void OnNetworkPostSpawn()
        {
            Debug.Log("OnNetworkPostSpawn");
         
            var spawner = FindObjectsByType<ObjectSpawner>(FindObjectsSortMode.None).FirstOrDefault(i => i.id == findLinkId);
            if (spawner != null)
            {
                spawner.onSpawn.Invoke(gameObject);
                Debug.Log("OnNetworkPostSpawn");
            }
            else
            {
                Debug.LogError($"Object spawner not found for id: {findLinkId}");
            }
            base.OnNetworkPostSpawn();
        }
    }
}