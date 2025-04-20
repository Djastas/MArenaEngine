using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Components.HpManagement
{
    public class HpComponent : NetworkBehaviour
    {
        public NetworkVariable<int> hp  = new();
        
        [Space]
        public bool isProjectileStuck;
        
        [Header("Events")]
        public UnityEvent<int> onHpChanged;
        public UnityEvent onDie;

        public void Damage(int damage)
        {
            hp.Value -= damage;
            // onHpChanged?.Invoke(hp.Value);
            
            /*if (hp.Value <= 0 )
            {
                onDie?.Invoke();
            }*/
          
        }


        private void OnValidate()
        {
            var temp = GetComponentsInChildren<HpComponent>();
            foreach (var hpComponent in temp)
            {
                if (hpComponent && hpComponent != this)
                {
                    Debug.LogWarning("Found hpComponent in children. HpComponent will not be target for damage.",this);
                }
            }
        }
    }
}