﻿using System;
using System.Collections.Generic;
using Corp_Kaktus.MArenaEngine.Scripts.Network.Logger;
using Corp_Kaktus.MArenaEngine.Scripts.Network.RoleControl;
using Corp_Kaktus.MArenaEngine.Scripts.Network.Utils;
using Unity.Netcode;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Components
{
    [AddComponentMenu("Corp_Kaktus/MArenaEngine/Network/Spawn Controller")]
    public class SpawnController : NetSingleton<SpawnController>
    {
        [SerializeField] private List<GameObject> spawnObjects;
        [SerializeField] private Transform spawnTransform;

        private void Start()
        {
            NetworkManager.Singleton.OnConnectionEvent += (_, connectionData) =>
            {
                if (connectionData.EventType != ConnectionEvent.ClientConnected || !IsServer) return;
                Debug.Log("[Server] Client Connected");
                NetDebugger.instance.Log("[Server] Client Connected");
                OnClientConnectServerSide(connectionData.ClientId);
            };
        }

        private void OnClientConnectServerSide(ulong id)
        {
            Debug.Log("[Server] Send spawn id request");
            NetDebugger.instance.Log("[Server] Send spawn id request");
            OnClientConnectClientSideRpc(RpcTarget.Single(id, RpcTargetUse.Temp));
        }

        [Rpc(SendTo.SpecifiedInParams)]
        private void OnClientConnectClientSideRpc(RpcParams rpcParams)
        {
            Debug.Log("[Client] send spawn id");
            var spawnID = RoleController.currentRole switch
            {
                Role.Client => 1,
                Role.Server => -1,
                Role.Console => 0,
                _ => throw new ArgumentOutOfRangeException()
            };
            OnClientReceiveSpawnIDServerSideRpc(spawnID,NetworkManager.LocalClientId);
        }

        [Rpc(SendTo.Server)]
        private void OnClientReceiveSpawnIDServerSideRpc(int spawnId, ulong ownerId)
        {
            if (!spawnObjects[spawnId]) { return; }
            var spawnObject = Instantiate(spawnObjects[spawnId],spawnTransform.position, spawnTransform.rotation);
            var instanceNetworkObject = spawnObject.GetComponent<NetworkObject>();
            instanceNetworkObject.SpawnWithOwnership(ownerId);
        }
    }
}