using Corp_Kaktus.MArenaEngine.Scripts.Network.RoleControl;
using Unity.Netcode;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Trash
{
    public class RoleReceiver : NetSingleton<RoleReceiver>
    {
        /*[Rpc(SendTo.SpecifiedInParams)]
        public void CallbackRoleRpc(RpcParams rpcParams)
        {
            // We do not use rpcParams within this method's body, but that is okay!
            // The params passed in are used by the generated code to ensure that this sends only
            // to the one client it should go to
            Debug.Log($"callback role: {RoleController.currentRole}");
            PlayerSpawner.instance.SendRoleRpc(RoleController.currentRole);
        }*/
        
    }
}