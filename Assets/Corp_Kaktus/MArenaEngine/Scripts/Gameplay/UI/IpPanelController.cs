using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.UI
{
    public class IpPanelController : MonoBehaviour
    {
        [SerializeField]  private TMP_InputField ipInputField;
        [SerializeField] private TMP_Text statusText;
        [SerializeField] private string gameScene = "GameEntryScene";
        
        
        
        public void SetIp()
        {
            Network.Utils.Utils.SetIp(ipInputField.text == "" ?  "127.0.0.1": ipInputField.text);
            
            NetworkManager.Singleton.OnConnectionEvent += (a,b) => {
                if (b.EventType == ConnectionEvent.ClientDisconnected) { Fail(); } else { Success(); }
            } ;
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
            SceneManager.LoadScene(gameScene);
        }
        
        
    }
}