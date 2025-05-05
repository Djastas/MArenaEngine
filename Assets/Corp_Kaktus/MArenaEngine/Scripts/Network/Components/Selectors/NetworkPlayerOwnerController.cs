using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Components.Selectors
{
    [AddComponentMenu("Corp_Kaktus/MArenaEngine/Selectors/Player Selector Component-")]
    public class NetworkPlayerOwnerController : NetworkBehaviour
    {
        [Tooltip("destroyed if player not owner")]
        [SerializeField] private List<GameObject> destroyableObject;
        
        [Tooltip("disable if player not owner")]
        [SerializeField] private List<Behaviour> disableComponents;

        public override void OnNetworkSpawn() { DisableClientInput(); }

        private void DisableClientInput()
        {
            if (IsOwner) return;
            
            foreach (var o in destroyableObject) { Destroy(o); }
            foreach (var component in disableComponents) { component.enabled = false; }
            
        }
    }
}
