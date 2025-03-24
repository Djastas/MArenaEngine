using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Components
{
    [AddComponentMenu("Corp_Kaktus/MArenaEngine/Network/Start Server Component")]
    public class StartServerComponent : MonoBehaviour
    {
        [SerializeField] private UnityEvent onServerStartSuccess;
        [SerializeField] private bool startServerOnStart = true;

        private void Start()
        {
            NetworkManager.Singleton.OnServerStarted += () => onServerStartSuccess.Invoke();
            if (startServerOnStart)
                StartServer();
        }
        public void StartServer() => NetworkManager.Singleton.StartServer();
    }
}