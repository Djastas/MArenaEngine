using Corp_Kaktus.MArenaEngine.Scripts.Network.Logger;
using Unity.Netcode;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Components.Interactable
{
    public class BulletController : NetworkBehaviour
    {
        [SerializeField] private float speed;
        private void FixedUpdate()
        {
            transform.position += transform.forward * (Time.fixedDeltaTime * speed);
        }

        private void OnTriggerEnter(Collider other)
        {
            NetDebugger.instance.Log($"Damage for {other.gameObject.name}");
            DespawnRpc();
        }
        
        [Rpc(SendTo.Server)]
        private void DespawnRpc()
        {
            NetworkObject.Despawn();
        }
    }
}