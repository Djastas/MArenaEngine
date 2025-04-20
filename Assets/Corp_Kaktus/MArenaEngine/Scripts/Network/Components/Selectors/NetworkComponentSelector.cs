using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Components.Selectors
{
    [AddComponentMenu("Corp_Kaktus/MArenaEngine/Selectors/NetworkComponentSelector")]
    public class NetworkComponentSelector : NetworkBehaviour
    {
        [SerializeField] private List<Behaviour> onlyOwnerComponents;

        private void Awake()
        {
            if (!IsOwner) { DestroyAll(onlyOwnerComponents); }
        }

        private static void DestroyAll(List<Behaviour> behaviours)
        { foreach (var behaviour in behaviours) { Destroy(behaviour); } }
    }
}