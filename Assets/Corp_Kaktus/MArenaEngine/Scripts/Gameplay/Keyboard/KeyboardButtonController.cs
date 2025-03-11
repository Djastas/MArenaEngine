using UnityEngine;
using UnityEngine.Events;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Keyboard
{
    public class KeyboardButtonController : MonoBehaviour
    {
        public bool deleteChar;
        public int deleteCharCount;
        
        public string character;
        public UnityEvent<string> onPressed;
        public UnityEvent<int> onPressedInt;
        
        public void Press()
        {
            onPressed?.Invoke(character);
            onPressedInt?.Invoke(deleteCharCount);
        }

        private void Awake()
        {
            if (deleteChar)
            {
                onPressedInt.AddListener(GetComponentInParent<KeyboardController>().DeleteChar);
            }
            else
            {
                onPressed.AddListener(GetComponentInParent<KeyboardController>().WriteChar);
            }
          
        }
    }
}