using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Components.HpManagement
{
    public class DamageComponent : MonoBehaviour
    {
        public int damage;

        public void Damage(GameObject target)
        {
            target.GetComponentInParent<HpComponent>();
        }
    }
}