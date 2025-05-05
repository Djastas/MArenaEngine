using System;
using UnityEngine;

namespace Corp_Kaktus.Experiments.Calibration.Scripts
{
    public class CalibrateWorldController : MonoBehaviour
    {
       public bool activateWhenCalibrate;
       [SerializeField] private GameObject calibrateWorld;

       private void Start()
       {
           Calibrator.instance.onCalibrateStart.AddListener(() => { calibrateWorld.SetActive(activateWhenCalibrate); });
           Calibrator.instance.onCalibrateEnd.AddListener(() => { calibrateWorld.SetActive(!activateWhenCalibrate); });
       }

       private void OnDestroy()
       {
           Calibrator.instance.onCalibrateStart.RemoveListener(() => { calibrateWorld.SetActive(activateWhenCalibrate); });
           Calibrator.instance.onCalibrateEnd.RemoveListener(() => { calibrateWorld.SetActive(!activateWhenCalibrate); });
       }
    }
}