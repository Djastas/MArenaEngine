using System;
using Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Components.HpManagement;
using Corp_Kaktus.MArenaEngine.Scripts.Network.Logger;
using Unity.Netcode;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Components
{
    [RequireComponent(typeof(Rigidbody))]
    public class ProjectileController : NetworkBehaviour
    {
        [SerializeField] private bool isStuck;
        [SerializeField] private GameObject visualObject;

        [SerializeField] private int damage;
        
        [SerializeField] private float deepeningValue;
        [SerializeField] private float speed;
        
        
        private void Start()
        {
            GetComponent<Rigidbody>().linearVelocity =transform.forward * speed;
        }

        public void OnTriggerEnter(Collider other)
        {
            Debug.Log("Collision Enter");

            var targetHpComponent = other.gameObject.GetComponentInParent<HpComponent>();
            if (targetHpComponent)
            {
                if (targetHpComponent.isProjectileStuck)
                {
                    visualObject.transform.parent = null;
                    visualObject.transform.position += transform.forward * deepeningValue;
                    Debug.Log("stuck");
                }

                if (IsServer)
                {
                    targetHpComponent.Damage(damage);
                    NetDebugger.instance.Log($"damage {damage} for {other.gameObject.name} ");
                    Debug.Log($"damage {damage} for {other.gameObject.name} ");
                }
            }
            else
            {
                Debug.Log("Missed Collision");
            }
            
            Destroy(gameObject);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position,transform.position + ( transform.forward * speed));
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position,transform.position + ( transform.forward * deepeningValue));
        }
    }
}