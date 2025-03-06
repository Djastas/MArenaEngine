using Corp_Kaktus.MArenaEngine.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Logger.Console
{
    public class MessageUIController : MonoBehaviour
    {
        [SerializeField] protected TMP_Text mainText;
        [SerializeField] protected TMP_Text idText;
        
        [SerializeField] protected Image colorLine;
        public virtual void Init(Message message)
        {
            Random.InitState(TypeUtils.ConvertLongToInt(message.OwnerId));

            
            colorLine.color = Random.ColorHSV();
            
            mainText.text = message.Value;
            
            idText.text = $"id: {message.OwnerId}";
        }
    }
}