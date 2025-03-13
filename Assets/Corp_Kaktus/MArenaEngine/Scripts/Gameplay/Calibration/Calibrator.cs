using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Calibration
{
    public class Calibrator : MonoBehaviour
    {

        
        [SerializeField] private bool isGetPointA; 
        [SerializeField] private bool startCalibrate;
        
        private InputAction _calibrateAction;

        private void Start()
        {
            _calibrateAction = InputSystem.actions.FindAction("CalibrateAction");
            _calibrateAction.performed += _ => CalibrateInput();
            
            _calibrateAction = InputSystem.actions.FindAction("StartCalibrateAction");
            _calibrateAction.performed += _ => StartCalibration();
        }
        
        [ContextMenu("StartCalibration")]
        private void StartCalibration()
        {
            if (CalibrationController.instance.currentStep != CalibrationSteps.NotStart) return;
            CalibrationController.instance.currentStep = CalibrationSteps.SetPointA;
            CalibrationController.instance.onCalibrationStart?.Invoke();
        }
        
        
        [ContextMenu("CalibrateInput")]
        private void CalibrateInput()
        {
            if (CalibrationController.instance.currentStep is CalibrationSteps.NotStart or CalibrationSteps.Finish) return;
            GetPoint();
        }

        public void GetPoint()
        {
            if (CalibrationController.instance.currentStep == CalibrationSteps.SetPointA)
            {
                CalibrationController.instance.SetPointA(transform.position);
                CalibrationController.instance.currentStep = CalibrationSteps.SetPointB;
            }
            else
            {
                CalibrationController.instance.SetPointB(transform.position);
                CalibrationController.instance.Calibrate();
                CalibrationController.instance.currentStep = CalibrationSteps.Finish;
                CalibrationController.instance.onCalibrationEnd?.Invoke();
            }
        }

    }
}