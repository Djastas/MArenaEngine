using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network
{
    public class NetworkPlayerOwnerController : NetworkBehaviour
    {
        [SerializeField] private Vector2 placementArea = new Vector2(-10f, 10f);
        
        [Tooltip("destroyed if player not owner")]
        [SerializeField] private List<GameObject> destroyableObject;
        
        [Tooltip("disable if player not owner")]
        [SerializeField] private List<Behaviour> disableComponents;

        public override void OnNetworkSpawn()
        {
            DisableClientInput();
            
        }

        private void DisableClientInput()
        {
            if (!IsClient || IsOwner) return;
            
            foreach (var o in destroyableObject) { Destroy(o); }
            foreach (var component in disableComponents) { component.enabled = false; }
            
        }

        public void Start()
        {
            if (IsClient && IsOwner)
            {
                transform.position = new Vector3(Random.Range(placementArea.x,placementArea.y),0f, Random.Range(placementArea.x,placementArea.y));
            }
        }
    }
}
