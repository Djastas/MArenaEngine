using System.Collections.Generic;
using Corp_Kaktus.MArenaEngine.Scripts.Utils;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Logger
{
    public class NetDebugger : NetSingleton<NetDebugger>
    {
        public readonly UnityEvent<Message> OnGetMessageFromServer = new();

        public readonly List<Message> Messages = new();
        

        public void Log(string message)
        {
            if (!NetworkManager.Singleton || !NetworkManager.Singleton.IsConnectedClient)
            {
                Debug.LogWarning($"Use netDebugger, but not connected. message: {message}");
                Messages.Add(new Message(message, 404));
                return;
            }
            
            SendMessageToServerRpc(message, NetworkManager.Singleton.LocalClientId);
        }

        [Rpc(SendTo.Server)]
        private void SendMessageToServerRpc(string messageValue, ulong clientId)
        {
            var message = new Message(messageValue, clientId);
            Messages.Add(message);
            
            // todo
            // add net debug setting
            // Debug.Log("server get message");

            SendMessageToClientsRpc(message);
        }

        [Rpc(SendTo.ClientsAndHost)]
        private void SendMessageToClientsRpc(Message message)
        {
            // todo
            // add net debug setting
            // Debug.Log("client get message");
            
            OnGetMessageFromServer?.Invoke(message);
            Messages.Add(message);
        }
    }
}