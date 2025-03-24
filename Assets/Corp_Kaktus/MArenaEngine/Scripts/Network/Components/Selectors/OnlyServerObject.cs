using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Components.Selectors
{
    [AddComponentMenu("Corp_Kaktus/MArenaEngine/Selectors/Only Server Object")]
    public class OnlyServerObject : NetworkBehaviour
    {
        [Tooltip("destroyed if object not on server")]
        [SerializeField] private List<GameObject> destroyableObject;
        
        [Tooltip("disable if object not on server")]
        [SerializeField] private List<Behaviour> disableComponents;
        
        
        public override void OnNetworkSpawn()
        {
            if (!IsServer) return;
            
            foreach (var o in destroyableObject) { Destroy(o); }
            foreach (var component in disableComponents) { component.enabled = false; }
            
        }
    }
}