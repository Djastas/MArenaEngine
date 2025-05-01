using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Corp_Kaktus.Experiments.Calibration.Scripts
{
    public class CalibrateObjectController : MonoBehaviour
    {
        [SerializeField] private InputAction action;
        // todo change to project input action
        
        private CalibrationState _currentCalibrationStep;

        public void Start()
        {
            action.Enable();
            action.performed += _ => { GetPos();};
        }

        public void GetPos()
        {
            switch (_currentCalibrationStep)
            {
                case CalibrationState.NotStarted:
                    Calibrator.instance.onCalibrateStart?.Invoke();
                    Debug.Log("[CalibrateObjectController] Calibration not started");
                    break;
                case CalibrationState.GetPosA:
                    Debug.Log("[CalibrateObjectController] Calibration GetPosA");
                    Calibrator.instance.realPosA = transform.position;
                    break;
                case CalibrationState.GetPosB:
                    Debug.Log("[CalibrateObjectController] Calibration GetPosB");
                    Calibrator.instance.realPosB = transform.position;
                    Calibrator.instance.Calibrate();
                    break;
                case CalibrationState.End:
                    Calibrator.instance.onCalibrateEnd?.Invoke();
                    Debug.Log("[CalibrateObjectController] Calibration End"); 
                    _currentCalibrationStep = 0;
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _currentCalibrationStep++;
            
        }

        private enum CalibrationState
        {
            NotStarted,
            GetPosA,
            GetPosB,
            End
        }
    }
}