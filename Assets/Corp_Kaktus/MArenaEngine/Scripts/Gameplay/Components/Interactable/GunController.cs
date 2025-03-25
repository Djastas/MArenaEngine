using Unity.Netcode;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Components.Interactable
{
    [RequireComponent(typeof(XRGrabInteractable))]
    public class GunController : NetworkBehaviour
    {
        [SerializeField] private UnityEngine.Transform bulletPos;
        [SerializeField] private GameObject bulletPrefab;
        
        public void Start()
        {
            GetComponent<XRGrabInteractable>().activated.AddListener(Shoot);
        }

        private void Shoot(ActivateEventArgs args)
        {
            SpawnBulletRpc();
        }

        [Rpc(SendTo.Server)]
        private void SpawnBulletRpc()
        {
            var spawnObject = Instantiate(bulletPrefab,bulletPos.position,bulletPos.rotation);
            var instanceNetworkObject = spawnObject.GetComponent<NetworkObject>();
            instanceNetworkObject.Spawn();
        }
    }
}