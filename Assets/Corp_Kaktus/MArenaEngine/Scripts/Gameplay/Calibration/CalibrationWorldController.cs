using System;
using System.Linq;
using Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Calibration.Tags;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Calibration
{
    public class CalibrationWorldController : MonoBehaviour
    {
        [SerializeField] private GameObject calibrationWorld;
        private void Start()
        {
            CalibrationController.instance.onCalibrationStart.AddListener(() => SetActiveCalibrationWorld(true));
            CalibrationController.instance.onCalibrationEnd.AddListener(() =>  SetActiveCalibrationWorld(false));
        }
       
        private void SetActiveCalibrationWorld(bool active)
        {
            var objectForDisable = FindObjectsByType<DisableWhenCalibrateTag>(FindObjectsInactive.Include,FindObjectsSortMode.None);
            
            foreach (var o in objectForDisable.Select(i => i.gameObject))
            {
                o.SetActive(!active);
            }
            
            calibrationWorld.SetActive(active);
        }


    }
}