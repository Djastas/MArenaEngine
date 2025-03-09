using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Keyboard
{
    public class KeyboardController : MonoBehaviour
    {
        private TMP_InputField _inputField;
        
        [SerializeField] private TMP_InputField keyboardInputField;
        public void WriteChar(string character)
        {
            /*if (!_inputField || _inputField.gameObject !=  EventSystem.current.currentSelectedGameObject)
            {
                _inputField =  EventSystem.current.currentSelectedGameObject.GetComponent<InputField>();
            }*/
            keyboardInputField.text += character;
        }
    }
}