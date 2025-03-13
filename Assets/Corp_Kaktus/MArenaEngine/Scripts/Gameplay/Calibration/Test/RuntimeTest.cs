using System;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Calibration.Test
{
    public class RuntimeTest : MonoBehaviour
    {
        [SerializeField] private Transform pointRealA;
        [SerializeField] private Transform pointRealB;
        
        [SerializeField] private CalibrationController calibrationController;
        [SerializeField] private Calibrator calibrator;

        private void Start()
        {
            Calibrate();
            Calibrate();
        }

        [ContextMenu("Calibrate")]
        public void Calibrate()
        {
            switch (calibrationController.currentStep)
            {
                case CalibrationSteps.NotStart:
                    break;
                case CalibrationSteps.SetPointA:
                    transform.position = pointRealA.position;
                    break;
                case CalibrationSteps.SetPointB:
                    transform.position = pointRealB.position;
                    break;
                case CalibrationSteps.Finish:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            calibrator.GetPoint();
        }
    }
}