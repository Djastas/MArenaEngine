using Corp_Kaktus.MArenaEngine.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Logger.Console
{
    public class MessageUIController : MonoBehaviour
    {
        public string messageText;
        
        [SerializeField] private TMP_Text mainText;
        [SerializeField] private TMP_Text idText;
        [SerializeField] private int messagePreviewLenght;
        
        [SerializeField] private Image colorLine;
        
        [SerializeField] private NetConsoleController netConsoleController;

        public void OnValidate()
        {
            if (!netConsoleController) { netConsoleController = GetComponentInParent<NetConsoleController>(); }
        }

        public void Select()
        {
            netConsoleController.Select(this);
        }

        public void Init(Message message)
        {
            Random.InitState(TypeUtils.ConvertLongToInt(message.OwnerId));

            
            colorLine.color = Random.ColorHSV();
            mainText.text = mainText.text.Length > messagePreviewLenght ? message.Value[..messagePreviewLenght] : message.Value[..message.Value.Length];
           
            messageText = message.Value;
            
            idText.text = $"id: {message.OwnerId}";
        }
    }
}