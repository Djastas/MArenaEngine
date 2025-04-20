using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Trash
{
    public class Rope2 : MonoBehaviour
    {
        [SerializeField] private Transform start;
        [SerializeField] private Transform end;
        
        [Header("Tension")]
        [SerializeField] private Transform tensionOffsetObject;
        [SerializeField] private Transform tension;
        [SerializeField] private Transform tensionSmooth;
        [SerializeField] private float ropeLenght;

        [Header("rope")] 
        [SerializeField] private List<Transform> ropeBones;
        [SerializeField] private Vector3 boneForwardVector;

        private void Update()
        {
            var middlePoint = start.position + ((end.position -  start.position) / 2f);
            
            var tenPos = middlePoint + ((tensionOffsetObject.position - start.position)  * CalcTension(start.position, end.position,ropeLenght));
            tension.position = tenPos;

            for (var index = 0; index < ropeBones.Count; index++)
            {
                var ropeBone = ropeBones[index];

                var time = index/(ropeBones.Count-1f);
                var pos =  CalcQuadBezierPoint(start.position,tensionSmooth.position,end.position,time);
                var tangent = (pos - CalcQuadBezierPoint(start.position,tensionSmooth.position,end.position,time-0.01f)).normalized;

                
                
                ropeBone.position = pos;
                var angle = Vector3.Angle(boneForwardVector, tangent);
                var axis = Vector3.Cross(boneForwardVector, tangent).normalized;

                ropeBone.rotation = Quaternion.AngleAxis(angle, axis);
            }
        }



        private Vector3 CalcQuadBezierPoint(Vector3 p0, Vector3 p1, Vector3 p2,float t) 
            => (float)Math.Pow(1-t,2)*p0 + 2*t*(1-t)*p1 + (float)Math.Pow(t,2)*p2;
        
        private static float CalcTension(Vector3 a, Vector3 b,float ropeLenght)
        {
            var distance = Vector3.Distance(a, b);
            
            if (distance > ropeLenght) { return 0; }
            return ropeLenght - distance;
        }
        
    }
}