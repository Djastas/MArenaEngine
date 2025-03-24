using System;
using Corp_Kaktus.MArenaEngine.Scripts.Network;
using Corp_Kaktus.MArenaEngine.Scripts.Network.Utils;
using TMPro;
using Unity.Netcode;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Trash
{
    public class PingPong : NetSingleton<PingPong>
    {
        [SerializeField] private TMP_Text text;
        [Rpc(SendTo.Server)]
        public void PingRpc(int pingCount)
        {
            // Server -> Clients because PongRpc sends to NotServer
            // Note: This will send to all clients.
            // Sending to the specific client that requested the pong will be discussed in the next section.
            Debug.Log($"Received pong from client for ping {pingCount}");
            text.text = $"Received pong from client for ping {pingCount}";
            PongRpc(pingCount, "PONG!");
        }

        [Rpc(SendTo.NotServer)]
        void PongRpc(int pingCount, string message)
        {
            Debug.Log($"Received pong from server for ping {pingCount} and message {message}");
            text.text = $"Received pong from server for ping {pingCount} and message {message}";
        }
        
        
        [Rpc(SendTo.SpecifiedInParams)]
        void OnConnectRpc( RpcParams rpcParams)
        {
            text.text = $"get connect recive from server, send role";
            GetRoleRpc("pop", RpcTarget.Single(rpcParams.Receive.SenderClientId, RpcTargetUse.Temp));
        }

        void Update()
        {
            if (IsClient && Input.GetKeyDown(KeyCode.P))
            {
                // Client -> Server because PingRpc sends to Server
                PingRpc(20);
            }
            
            if (IsServer && Input.GetKeyDown(KeyCode.P))
            {
                // Client -> Server because PingRpc sends to Server
               
            }
        
        }

        private void Start()
        {

            NetworkManager.Singleton.OnServerStarted += Subscribe;

        }

        public void Subscribe()
        {
            NetworkManager.Singleton.OnClientConnectedCallback += id =>
            {
                OnConnectRpc(RpcTarget.Single(id, RpcTargetUse.Temp));
                text.text = $"{id} Connected to server";
            };
        }
        [Rpc(SendTo.SpecifiedInParams)]
        public void GetRoleRpc(string role ,RpcParams rpcParams)
        {
            Debug.Log($"client send role to server {role}");
        }
    }
}