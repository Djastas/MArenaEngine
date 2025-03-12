using Corp_Kaktus.MArenaEngine.Scripts.Network.RoleControl;
using Unity.Netcode;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Trash
{
    public class PlayerSpawner : NetSingleton<PlayerSpawner>
    {
        /*private void Start()
        {
            NetworkManager.Singleton.OnClientConnectedCallback += id =>
            {
                Debug.Log("Client connected: " + id);
                GetRoleRpc(RpcTarget.Single(id, RpcTargetUse.Temp));
            };  
        }

        [Rpc(SendTo.SpecifiedInParams)]
        public void GetRoleRpc(RpcParams rpcParams)
        {
            Debug.Log($"callback role: {RoleController.currentRole}");
            SendRoleRpc(RoleController.currentRole);
        }

        [Rpc(SendTo.Server)]
        public void SendRoleRpc(Role currentRole)
        {
            Debug.Log("server get Role: " + currentRole);
        }*/
        
        
        /*
        private void Start()
        {
            if (RoleController.currentRole == Role.Server)
            {
                NetworkObject.Spawn();
                Subscribe();
                Debug.Log("Success subscribed");
            }
        }
         void Subscribe()
        {
            NetworkManager.Singleton.OnClientConnectedCallback += id =>
            {
                ClientSideRoleRpc(RpcTarget.Single(id, RpcTargetUse.Temp));
                Debug.Log("Client connected: " + id);
            };  
        }
        [Rpc(SendTo.SpecifiedInParams)]
         void ClientSideRoleRpc(RpcParams rpcParams)
        {
            Debug.Log($"callback role: {RoleController.currentRole}");
            ServerSideRpc(NetworkManager.LocalClientId,RpcTarget.Single(rpcParams.Receive.SenderClientId, RpcTargetUse.Temp));
        }
        
        [Rpc(SendTo.SpecifiedInParams)]
         void ServerSideRpc(ulong role ,RpcParams rpcParams)
        {
            Debug.Log($"client send role to server {role}");
        }
        */
        
        
        
        
        
        
    }
}