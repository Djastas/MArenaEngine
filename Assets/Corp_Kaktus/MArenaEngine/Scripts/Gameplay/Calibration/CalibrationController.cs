using Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Calibration.Tags;
using Corp_Kaktus.MArenaEngine.Scripts.Network.Logger;
using Corp_Kaktus.MArenaEngine.Scripts.Utils;
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

        private Transform _calibrateObject;

        public void Calibrate()
        {
            if (!_calibrateObject) _calibrateObject = FindAnyObjectByType<CalibrateObjectTag>().calibrateObject;

            var normalizedA =
                (realPosPointB - _calibrateObject.position).normalized; // relative rotate point on center level
            var normalizedRealA =
                (pointB.position - _calibrateObject.position).normalized; // relative rotate point on center level

            var angle = Vector3.Angle(normalizedA, normalizedRealA);
            var rotationAxis = Vector3.Cross(normalizedA, normalizedRealA).normalized * -1;


            _calibrateObject.rotation *= Quaternion.AngleAxis(angle, rotationAxis);
            
            var offset = realPosPointA - pointA.position;

            _calibrateObject.position += offset;
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