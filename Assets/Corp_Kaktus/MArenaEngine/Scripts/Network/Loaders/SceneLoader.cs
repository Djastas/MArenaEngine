using Corp_Kaktus.MArenaEngine.Scripts.Utils;
using Corp_Kaktus.MArenaEngine.Scripts.Utils.Patterns;
using Unity.Multiplayer;
using static Corp_Kaktus.MArenaEngine.Scripts.EngineSettings.EngineSettings;

namespace Corp_Kaktus.MArenaEngine.Scripts.Loaders
{
    public class SceneLoader : Singleton<SceneLoader>
    {
        protected override void Awake()
        {
            base.Awake();
            if (settings.controlClientBuild)
            {
                Instantiate(settings.controllerLoader);
                return;
            }
            if (MultiplayerRolesManager.ActiveMultiplayerRoleMask == MultiplayerRoleFlags.Client ||
                MultiplayerRolesManager.ActiveMultiplayerRoleMask == MultiplayerRoleFlags.ClientAndServer)
            {
                Instantiate(settings.clientLoader);
                return;
            }
            if (MultiplayerRolesManager.ActiveMultiplayerRoleMask == MultiplayerRoleFlags.Server)
            {
                Instantiate(settings.serverLoader);
                return;
            }
        }
    }
}