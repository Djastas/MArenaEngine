using Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Components.HpManagement;
using TMPro;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Components
{
    [RequireComponent(typeof(HpComponent))]
    public class DamageTestComponent : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        private void Start()
        {
            var hpComponent = GetComponent<HpComponent>();
            hpComponent.hp.OnValueChanged += UpdateText;
        }

        private void UpdateText(int _, int hp)
        {
            text.text = $"HP: {hp.ToString()}";
        }
    }
}