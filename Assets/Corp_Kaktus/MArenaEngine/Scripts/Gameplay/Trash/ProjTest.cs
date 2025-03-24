
using System.Collections.Generic;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Trash
{
    public class ProjTest : MonoBehaviour
    {
        
        [SerializeField] private List<Transform> targetsA;
        [SerializeField] private List<Transform> targetsB;
        [Range(0,1f)] [SerializeField] private float factor;
        
        
        private void Update()
        {
            var middleAngle = 0f;
            
            CalcAngle(targetsA[0], targetsB[0], transform.position, out var startRotAxis);
            
            
            for (var i = 0; i < targetsA.Count; i++)
            {
                var temp =  CalcAngle(targetsA[i], targetsB[i], transform.position, out var axis);

                middleAngle += (axis == startRotAxis ? temp : temp *-1) * (1f/targetsA.Count);
            }

          
            
            transform.Rotate(startRotAxis,Mathf.Lerp(0,middleAngle,factor), Space.World);
        }

        private float CalcAngle(Transform a, Transform b, Vector3 c, out Vector3 rotationAxis)
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
    }
}