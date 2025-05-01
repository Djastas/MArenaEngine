using Corp_Kaktus.MArenaEngine.Scripts.Utils.Patterns;
using Unity.XR.CoreUtils;
using UnityEngine;

namespace Corp_Kaktus.Experiments.Calibration.Scripts
{
    [RequireComponent(typeof(XROrigin))]
    public class PlayerCalibrationController : Singleton<PlayerCalibrationController> 
    {
        private XROrigin _xrOrigin;
        
        private void Start()
        {
            _xrOrigin = GetComponent<XROrigin>();
        }

        public void Calibrate(Vector3 offset, Vector3 position, float angle)
        {
            _xrOrigin.Origin.transform.position += offset;
            _xrOrigin.Origin.transform.RotateAround(position,Vector3.up, angle);
            Debug.Log("[PlayerCalibrationController] player success calibrate");
        }
        
        
        
        
    }
}