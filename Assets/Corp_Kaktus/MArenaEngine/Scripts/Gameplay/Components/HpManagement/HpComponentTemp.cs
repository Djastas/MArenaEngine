using Unity.Netcode;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Components.HpManagement
{
    public class HpComponentTemp : NetworkBehaviour
    {
        [SerializeField] private NetworkVariable<int> Hp = new();

        [ContextMenu("Damage")]
        public void Damage()
        {
            Hp.Value--;
        }
    }
}