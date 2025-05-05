using System.Collections.Generic;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Components
{
    public class CatapultController : MonoBehaviour
    {
        public bool canShoot;
        
        [SerializeField] private Trigger trigger;
        
        [SerializeField] private UnityEngine.Transform catapultTransform;
        
        
        [SerializeField] private WheelController wheelController;
        [SerializeField] private float endRot;
        
        [SerializeField] private WheelController releaseLever;
        [SerializeField] private float releaseLeverEndRot;
        
        [Header("Shoot")]
        [SerializeField] private Vector3 shootDirection;
        [SerializeField] private float shootPower = 10f;

        [Header("DEBUG")]
        [SerializeField] private List<Rigidbody> catapultObject;

        private void Start()
        {
            trigger.onEnter.AddListener((go) => {catapultObject.Add(go.GetComponent<Rigidbody>()); });
            trigger.onExit.AddListener((go) => {catapultObject.Remove(go.GetComponent<Rigidbody>()); });
        }

        private void Update()
        {
            if (canShoot && releaseLever.value > releaseLeverEndRot && releaseLever.value < releaseLeverEndRot + 10f)
            {
                Shoot();
            }

            if (!canShoot && wheelController.value > endRot && wheelController.value < endRot + 10f)
            {
                canShoot = true;
                wheelController.isLock = true;
                releaseLever.isLock = false;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawLine(trigger.transform.position, trigger.transform.position + shootDirection * (shootPower/ 100f));
            if (!wheelController) { return; }

            var startAngle = Quaternion.AngleAxis(0, wheelController.transform.forward) * Vector3.up;
            var endAngle = Quaternion.AngleAxis(endRot, wheelController.transform.forward) * Vector3.up;
            
            Gizmos.DrawLine(wheelController.transform.position,wheelController.transform.position + startAngle);
            Gizmos.DrawLine(wheelController.transform.position,wheelController.transform.position + endAngle);
            
            var startAngleLever = Quaternion.AngleAxis(0, releaseLever.transform.forward) * Vector3.up;
            var endAngleLever = Quaternion.AngleAxis(releaseLeverEndRot, releaseLever.transform.forward) * Vector3.up;
            
            Gizmos.DrawLine(releaseLever.transform.position,releaseLever.transform.position + startAngleLever);
            Gizmos.DrawLine(releaseLever.transform.position,releaseLever.transform.position + endAngleLever);
        }

        [ContextMenu("shoot")]
        public void Shoot()
        {
            if (!canShoot) { return; }
            foreach (var rb in catapultObject)
            {
                rb.linearVelocity = (shootDirection * shootPower);
            }
            
            wheelController.HardResetHandlers();
            wheelController.isLock = false;
            
            releaseLever.HardResetHandlers();
            releaseLever.isLock = true;
            canShoot = false;
        }

    }
}