using Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Calibration.Tags;
using Corp_Kaktus.MArenaEngine.Scripts.Network.Logger;
using Corp_Kaktus.MArenaEngine.Scripts.Utils;
using Corp_Kaktus.MArenaEngine.Scripts.Utils.Patterns;
using UnityEngine;
using UnityEngine.Events;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Calibration
{
    public class CalibrationController : Singleton<CalibrationController>
    {
        public Vector3 realPosPointA;
        public Vector3 realPosPointB;
        
        public CalibrationSteps currentStep;
        public UnityEvent onCalibrationStart;
        public UnityEvent onCalibrationEnd;
        
        
        [SerializeField] private Transform pointA;

        [SerializeField] private Transform pointB;
        
        private LineDrawer _lineDrawerA;
        private LineDrawer _lineDrawerB;
        private LineDrawer _lineDrawerRotAxis;
        private LineDrawer _lineDrawerOffset;

        private Transform _calibrateObject;

        public void Calibrate()
        {
            if (!_calibrateObject) _calibrateObject = FindAnyObjectByType<CalibrateObjectTag>().calibrateObject;

            // -------------- offset ------------
            var offset = realPosPointA - pointA.position;
            _calibrateObject.position += offset;
            // ----------------------------------
            
            // -------------- rotation ----------
            var normalizedA =
                (realPosPointB - offset).normalized; // relative rotate point on center level
            
            var normalizedRealA =
                (pointB.position).normalized; // relative rotate point on center level
            
            var angle = Vector3.Angle(normalizedA, normalizedRealA);
            var rotationAxis = Vector3.Cross(normalizedA, normalizedRealA).normalized * -1;
            
            
            if (  EngineSettings.EngineSettings.settings.debugLevel >= 1)
            {
                _lineDrawerA = new LineDrawer();
                _lineDrawerB = new LineDrawer();
                _lineDrawerRotAxis = new LineDrawer();
                
                _lineDrawerA.DrawLineInGameView(offset,offset+normalizedA,Color.red);
                _lineDrawerB.DrawLineInGameView(offset,offset+normalizedRealA,Color.blue);
                _lineDrawerRotAxis.DrawLineInGameView(offset,offset+rotationAxis,Color.green);
                _lineDrawerOffset.DrawLineInGameView(Vector3.zero,offset,Color.yellow);
            }

            _calibrateObject.rotation *= Quaternion.AngleAxis(angle, rotationAxis);
            // ----------------------------------
      

         
            NetDebugger.instance.Log($"succeed calibration offset with rot={angle}; and pos={offset};");
        }

        public void SetPointA(Vector3 point)
        {
            realPosPointA = point;
        }

        public void SetPointB(Vector3 point)
        {
            realPosPointB = point;
        }
    }
}