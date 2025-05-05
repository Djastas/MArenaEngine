using Corp_Kaktus.MArenaEngine.Scripts.Utils.Patterns;
using Unity.XR.CoreUtils;
using UnityEngine;

namespace Corp_Kaktus.Experiments.Calibration.Scripts
{
    
    public class PlayerCalibrationController : Singleton<PlayerCalibrationController> 
    {
        [SerializeField] private XROrigin xrOrigin;

        public void Calibrate(Vector3 offset, Vector3 position, float angle)
        {
            xrOrigin.Origin.transform.position += offset;
            xrOrigin.Origin.transform.RotateAround(position,Vector3.up, angle);
            Debug.Log("[PlayerCalibrationController] player success calibrate");
        }
        
        
        
        
    }
}