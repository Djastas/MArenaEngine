using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.UI
{
    public class IpPanelController : MonoBehaviour
    {
        [SerializeField]  private TMP_InputField ipInputField;
        [SerializeField] private TMP_Text statusText;
        
        public UnityEvent onSuccessConnect;


        private void Start()
        {
            NetworkManager.Singleton.OnConnectionEvent += (a,b) => {
                if (b.EventType == ConnectionEvent.ClientDisconnected) { Fail(); } else { Success(); }
            } ;

            // todo
            // LoadIPFromRuntimeSettings
            if (EngineSettings.EngineSettings.settings.autoConnect)
            {
                SetIp();
            }
        }

        public void SetIp()
        {
            Network.Utils.Utils.SetIp(ipInputField.text == "" ?  "127.0.0.1": ipInputField.text);
            
            statusText.text = "Connect now...";
            
            var result = NetworkManager.Singleton.StartClient();
        }

        private void Fail()
        {
            statusText.text = "Failed connect to server";
        }

        private void Success()
        {
            statusText.text = "Success connect to server";
            onSuccessConnect?.Invoke();
        }
    }
}