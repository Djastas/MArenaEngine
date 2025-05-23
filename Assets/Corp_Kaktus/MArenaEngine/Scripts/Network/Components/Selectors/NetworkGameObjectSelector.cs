﻿using System.Collections.Generic;
using Corp_Kaktus.MArenaEngine.Scripts.Network.Logger;
using Unity.Netcode;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Components.Selectors
{
    [AddComponentMenu("Corp_Kaktus/MArenaEngine/Selectors/NetworkGameObjectSelector")]
    public class NetworkGameObjectSelector : NetworkBehaviour
    {
        [SerializeField] private bool instantiate;
        [SerializeField] private List<GameObject> onlyOwnerGameObjects;
        [SerializeField] private List<GameObject> onlyNotOwnerGameObjects;

        private void Start()
        {
            switch (IsOwner)
            {
                case false:
                    DestroyAll(onlyOwnerGameObjects);
                    break;
                case true:
                    DestroyAll(onlyNotOwnerGameObjects);
                    break;
            }
            NetDebugger.instance.Log($"{OwnerClientId}:::{NetworkManager.LocalClientId}:::{IsOwner}" );
        }

        private void DestroyAll(List<GameObject> gameObjects)
        {
            foreach (var go in gameObjects)
            {
                if (instantiate)
                {
                    Instantiate(go);
                }
                else
                {
                    Destroy(go);
                }
            }
        }
    }
}