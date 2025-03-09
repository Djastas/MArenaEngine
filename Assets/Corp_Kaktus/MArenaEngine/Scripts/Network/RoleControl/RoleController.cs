using Unity.Multiplayer;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.RoleControl
{
    public static class RoleController
    {
        public static Role currentRole
        {
            get
            {
                if ((MultiplayerRolesManager.ActiveMultiplayerRoleMask & MultiplayerRoleFlags.Server) != 0)
                {
                    return Role.Server;
                }
                if ((MultiplayerRolesManager.ActiveMultiplayerRoleMask & MultiplayerRoleFlags.Client) != 0)
                {
                    if (EngineSettings.EngineSettings.settings.controlClientBuild)
                    {
                        return Role.Console;
                    }
                    if ((MultiplayerRolesManager.ActiveMultiplayerRoleMask & MultiplayerRoleFlags.Client) != 0)
                    {
                        return Role.Client;
                    }
                }
                Debug.LogError("No Multiplayer Role!");
                return Role.Client;
            }
        }
    }

    
}
