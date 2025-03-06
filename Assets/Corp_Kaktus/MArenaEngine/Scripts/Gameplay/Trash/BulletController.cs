using Corp_Kaktus.MArenaEngine.Scripts.Network.Logger;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Trash
{
    public class BulletController : MonoBehaviour
    {

        [SerializeField] private float damage;
        [SerializeField] private float speed;
        
        private void FixedUpdate()
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }

        public void Damage()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            NetDebugger.instance.Log(other.CompareTag("Player") ? "Player Hit" : "hit");
            Destroy(this.gameObject);
        }
    }
    
}