using Unity.Netcode;
using UnityEngine.Events;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Loaders
{
    public class ObjectSpawnReceiver : NetworkBehaviour
    {
        public UnityEvent onSpawn;
        
        protected override void OnNetworkPostSpawn()
        {
            onSpawn?.Invoke();
            base.OnNetworkPostSpawn();
        }
    }
}