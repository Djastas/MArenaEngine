using System;
using System.Collections.Generic;
using Corp_Kaktus.MArenaEngine.Scripts.Utils;
using UnityEngine;


namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Trash
{
    public class RopeTest : MonoBehaviour
    {
        public Transform P0;
        public Transform P1;
        public Transform P2;
        public Transform P3;

        [SerializeField] private int quality;

        [Range(0,1)] [SerializeField] private float timePreview;
        [SerializeField] private Vector3 normalCalcVector;

        private List<LineDrawer> _lineDrawers = new();

        private void Start()
        {
            for (var i = 0; i < quality; i++)
            {
                var lineDrawer = new LineDrawer();
                lineDrawer.Init();
                _lineDrawers.Add(lineDrawer);
            }
            
            var normalDrawer = new LineDrawer();
            normalDrawer.Init();
            _lineDrawers.Add(normalDrawer);
            
            var normalDrawer2 = new LineDrawer();
            normalDrawer2.Init();
            _lineDrawers.Add(normalDrawer2);
            
            var tangentDrawer = new LineDrawer();
            tangentDrawer.Init();
            _lineDrawers.Add(tangentDrawer);
        }

        private void Update()
        {
            var lastPoint = P0.position;
            /*for (var i = 0; i < _lineDrawers.Count; i++)
            {
                var calcCubicBezierPoint = ((CalcCubicBezierPointInterpolate(P0.position, P1.position, P2.position,
                    P3.position, ((float)i / (_lineDrawers.Count - 1))) / quality) + lastPoint);
                
                
                _lineDrawers[i].DrawLineInGameView(lastPoint, calcCubicBezierPoint,new Color(1f, 0.38f, 0.47f));
                
                lastPoint = calcCubicBezierPoint;
            }*/
            
            for (var i = 0; i < _lineDrawers.Count; i++)
            {
                var calcCubicBezierPoint = CalcQuadBezierPoint(
                    P0.position,
                    P1.position,
                    P2.position,
                    (float)i / (_lineDrawers.Count - 1));
                
                
                _lineDrawers[i].DrawLineInGameView(lastPoint, calcCubicBezierPoint,new Color(1f, 0.38f, 0.47f));
                
                lastPoint = calcCubicBezierPoint;
            }

            /*
            var pos = CalcCubicBezierPoint(P0.position, P1.position, P2.position, P3.position, timePreview);
            var tangent = CalcCubicBezierPointInterpolate(P0.position, P1.position, P2.position, P3.position, timePreview).normalized;
            var normal = Vector3.Cross(tangent,normalCalcVector).normalized;
            var normal2 =normalCalcVector.normalized;
            
            
            _lineDrawers[quality].DrawLineInGameView(
                pos,
                pos + tangent
                ,new Color(1f, 0.26f, 0.09f));
            _lineDrawers[quality + 1].DrawLineInGameView(
                pos,
                pos + normal
                ,new Color(0.34f, 0.39f, 1f));
            
            _lineDrawers[quality + 2].DrawLineInGameView(
                pos,
                pos + normal2
                ,new Color(0.44f, 1f, 0.53f));
                */
            
            
            
            
            var pos = CalcQuadBezierPoint(P0.position, P1.position, P2.position, timePreview);
            var tangent = (pos - CalcQuadBezierPoint(P0.position, P1.position, P2.position, timePreview - 0.01f)).normalized;
            var normal = Vector3.Cross(tangent,normalCalcVector).normalized;
            var normal2 =normalCalcVector.normalized;
            
            
            _lineDrawers[quality].DrawLineInGameView(
                pos,
                pos + tangent
                ,new Color(1f, 0.26f, 0.09f));
            _lineDrawers[quality + 1].DrawLineInGameView(
                pos,
                pos + normal
                ,new Color(0.34f, 0.39f, 1f));
            
            _lineDrawers[quality + 2].DrawLineInGameView(
                pos,
                pos + normal2
                ,new Color(0.44f, 1f, 0.53f));

        }
        private Vector3 CalcCubicBezierPoint( Vector3 p0, Vector3 p1, Vector3 p2,Vector3 p3,float t)
        {
            var a = (1-t)*p0 + t*p1;
            var b = (1-t)*p1 + t*p2;
            var c = (1-t)*p2 + t*p3;
            var d = (1-t)*a + t*b;
            var e = (1-t)*b + t*c;
            var p = (1-t)*d + t*e;


            return p;
        }

        private Vector3 CalcQuadBezierPoint(Vector3 p0, Vector3 p1, Vector3 p2,float t)
        {
            var ret = 
                (float)Math.Pow(1-t,2)*p0 
                + 2*t*(1-t)*p1
                + (float)Math.Pow(t,2)*p2; 
            
            return ret;
        }
        
        private Vector3 CalcCubicBezierPointInterpolate(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            return p0 * ((-3 * (float)Math.Pow(t, 2)) + (6 * t) - (3)) +
                   p1 * ((9 * (float)Math.Pow(t, 2)) - (12 * t) + 3) +
                   p2 * (-9 * (float)Math.Pow(t, 2) + 6 * t) +
                   p3 * (3 * (float)Math.Pow(t, 2));
        }
    }
}