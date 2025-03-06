using Unity.Multiplayer;
using Unity.Netcode;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network
{
    public class ServerClientRoleAutoConnector : MonoBehaviour
    {
        
        void Start()
        {
#if UNITY_EDITOR
            if (EngineSettings.EngineSettings.settings.autoLoadEditorHost)
            {
                NetworkManager.Singleton.StartHost();
                return;
            }
#endif
            
            
            var role = MultiplayerRolesManager.ActiveMultiplayerRoleMask;
            
            if (role == MultiplayerRoleFlags.Server)
            {
                NetworkManager.Singleton.StartHost();
                
            }
            else
            {
                NetworkManager.Singleton.StartClient();
            }
        }
    }
}
