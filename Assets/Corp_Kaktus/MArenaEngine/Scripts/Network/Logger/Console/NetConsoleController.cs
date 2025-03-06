using System.Collections.Generic;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Logger.Console
{
    public class NetConsoleController : MonoBehaviour
    {
        [SerializeField] private GameObject messagePrefab;
        [SerializeField] private Transform messagesParent;
        
        [SerializeField] private List<MessageUIController> messageControllers = new ();
        
        private void Start()
        {
            NetDebugger.instance.OnGetMessageFromServer.AddListener(OnGetMessage);
        }

        private void OnGetMessage(Message message)
        {
            var msg = Instantiate(messagePrefab, messagesParent);
            
            var messageUIController = msg.GetComponent<MessageUIController>();
            messageUIController.Init(message);
            
            messageControllers.Add(messageUIController);
        }
    }
}