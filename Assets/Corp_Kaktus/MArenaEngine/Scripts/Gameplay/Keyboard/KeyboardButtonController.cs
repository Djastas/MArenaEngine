using UnityEngine;
using UnityEngine.Events;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Keyboard
{
    public class KeyboardButtonController : MonoBehaviour
    {
        public string character;
        public UnityEvent<string> onPressed;
        
        public void Press() => onPressed?.Invoke(character);
        
        private void Awake()
        {
            onPressed.AddListener(GetComponentInParent<KeyboardController>().WriteChar);
        }
    }
}