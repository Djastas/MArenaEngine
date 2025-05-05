using UnityEngine;
using UnityEngine.Events;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Components
{
    public class Trigger : MonoBehaviour
    {
        [Tooltip("empty for non check")]
        [SerializeField] private string checkTag;

        public UnityEvent<GameObject> onEnter;
        public UnityEvent<GameObject> onStay;
        public UnityEvent<GameObject> onExit;
        
        
        private void OnTriggerEnter(Collider other)
        {
            if (Check(other.gameObject))
            {
                onEnter?.Invoke(other.gameObject);
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (Check(other.gameObject))
            {
                onStay?.Invoke(other.gameObject);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (Check(other.gameObject))
            {
                onExit?.Invoke(other.gameObject);
            }
        }

        private bool Check(GameObject go) => checkTag == "" || go.CompareTag(checkTag);
    }
}