using Unity.Multiplayer;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network
{
    public class ServerClientRoleAutoConnector : MonoBehaviour
    {
        [SerializeField] private UnityEvent onSuccess;
        void Start()
        {
            NetworkManager.Singleton.OnServerStarted += () => { onSuccess?.Invoke();};
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
                NetworkManager.Singleton.StartServer();
                
            }
            else
            {
                NetworkManager.Singleton.StartClient();
            }
        }
    }
}
