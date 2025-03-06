using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Components.Transform
{
    public class CopyTransformComponent : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Transform target;

        [Header("flags")] 
        
        [SerializeField] private bool posX = true;
        [SerializeField] private bool posY = true;
        [SerializeField] private bool posZ = true;
        [Space] 
        
        [SerializeField] private bool rotX = true;
        [SerializeField] private bool rotY = true;
        [SerializeField] private bool rotZ = true;
        [Space] 
        
        [SerializeField] private bool scaX = true;
        [SerializeField] private bool scaY = true;
        [SerializeField] private bool scaZ = true;
        [Space] 
        
        [SerializeField] private bool autoCalcOffset = true;

        [SerializeField] private Vector3 posOffset;
        [SerializeField] private Vector3 rotOffset;
        [SerializeField] private Vector3 scaleOffset;

        private void OnValidate()
        {
            if (!autoCalcOffset) return;
            posOffset = target.position - transform.position;
            scaleOffset = target.localScale - transform.localScale;
            rotOffset = target.rotation.eulerAngles - transform.rotation.eulerAngles;
        }

        public void Update()
        {
            if (posX || posY || posZ)
            {
                var offsetPos = target.position - posOffset;
                var currPos = transform.position;
                var newPos = new Vector3(
                    posX ? offsetPos.x : currPos.x,
                    posY ? offsetPos.y : currPos.y,
                    posZ ? offsetPos.z : currPos.z);


                transform.position = newPos;
            }

            if (rotX || rotY || rotZ)
            {
                var offsetRot = target.rotation.eulerAngles - rotOffset;
                var currRot = transform.rotation.eulerAngles;
                var newRot = new Vector3(
                    rotX ? offsetRot.x : currRot.x,
                    rotY ? offsetRot.y : currRot.y,
                    rotZ ? offsetRot.z : currRot.z);


                transform.rotation = Quaternion.Euler(newRot);
            }

            if (scaX || scaY || scaZ)
            {
                var offsetSca = target.localScale - scaleOffset;
                var currSca = transform.localScale;
                var newSca = new Vector3(
                    scaX ? offsetSca.x : currSca.x,
                    scaY ? offsetSca.y : currSca.y,
                    scaZ ? offsetSca.z : currSca.z);

                transform.localScale = newSca;
            }
        }
    }
}