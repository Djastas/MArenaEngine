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
           Calibrator.instance.onCalibrateStart.AddListener(
               () => { SetActive(false); });
           Calibrator.instance.onCalibrateEnd.AddListener(
               () => { SetActive(true); });
       }

       public void SetActive(bool invert)
       {
           if (calibrateWorld)
           {
               calibrateWorld.SetActive(invert ? !activateWhenCalibrate : activateWhenCalibrate); 
           }
       }

       private void OnDestroy()
       {
           Calibrator.instance.onCalibrateStart.RemoveListener(
               () => { SetActive(false); });
           Calibrator.instance.onCalibrateEnd.RemoveListener(
               () => { SetActive(true); });
       }
    }
}