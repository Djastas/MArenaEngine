using System.Collections.Generic;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Components
{
    /// <summary>
    /// projects A into the space of object B and calculates the angle ACB
    /// </summary>
    public class WheelController : MonoBehaviour
    {
        
        public List<UnityEngine.Transform> targetsA;
        public List<UnityEngine.Transform> targetsB;
        public List<UnityEngine.Transform> targetsStartPos;
        [Range(0,1f)] [SerializeField] private float factor;
        public bool isLock;
        
        
        private void Update()
        {
            if (isLock) { return; }
            
            var middleAngle = 0f;
            
            CalcAngle(targetsA[0], targetsB[0], transform.position, out var startRotAxis);
            
            
            for (var i = 0; i < targetsA.Count; i++)
            {
                var temp =  CalcAngle(targetsA[i], targetsB[i], transform.position, out var axis);

                middleAngle += (axis == startRotAxis ? temp : temp *-1) * (1f/targetsA.Count);
            }


            var angle = Mathf.Lerp(0,middleAngle,factor);
            transform.Rotate(startRotAxis,angle, Space.World);
        }

        private float CalcAngle(UnityEngine.Transform a, UnityEngine.Transform b, Vector3 c, out Vector3 rotationAxis)
        {
            var aP = a.position;
            var bP = b.position;

            
            var bx = b.right;
            var by = b.up;

            var aOffset = aP - bP;

            var res = Proj(aOffset, bx) + Proj(aOffset, by) + bP;
            
            var bPNor = (bP - c);
            var resNor = (res -c);
            
            
            var angle = Vector3.Angle(bPNor,resNor);
            rotationAxis = Vector3.Cross(bPNor, resNor).normalized ;
            
           return angle;
        }

        private Vector3 Proj(Vector3 a, Vector3 b)
        {
           return ((a.x*b.x + a.y*b.y + a.z*b.z) / b.magnitude) * b.normalized;
        }

        public void HardResetHandlers()
        {
            for (var index = 0; index < targetsA.Count; index++)
            {
                targetsA[index].position = targetsStartPos[index].position;
                
            }
        }
    }
}