using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Logger.Console
{
    public class NetConsoleController : MonoBehaviour
    {
        [SerializeField] private GameObject messagePrefab;
        [SerializeField] private Transform messagesParent;

        [SerializeField] private TMP_Text messageText;
        
        [SerializeField] private int maxMessages = 20;
        
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
            DeleteOverflowMessages();
        }

        public void Select(MessageUIController messageUIController)
        {
            messageText.text = messageUIController.messageText;
        }

        private void DeleteOverflowMessages()
        {
            if (maxMessages < 0) { return; }
            if (messageControllers.Count <= maxMessages) { return; }

            var destroyCount = messageControllers.Count - maxMessages;
            foreach (var destroyMessage in messageControllers.GetRange(0, destroyCount))
            {
                Destroy(destroyMessage.gameObject);
            }
            
            messageControllers = messageControllers.GetRange(destroyCount, maxMessages);
        }
    }
}