using Corp_Kaktus.MArenaEngine.Scripts.Utils;
using Corp_Kaktus.MArenaEngine.Scripts.Utils.Patterns;
using UnityEngine;
using UnityEngine.Events;

namespace Corp_Kaktus.Experiments.Calibration.Scripts
{
    /// <summary>
    /// level space script. contain virtual position. calculate offset and angle for calibrate
    /// </summary>
    public class Calibrator : Singleton<Calibrator>
    {
        [SerializeField] private Transform objForCalibrate ,virtualPosA ,virtualPosB;
        [SerializeField] private float maxCalibrateOffsetError = 0.1f;
        
        [Header("DEBUG")]
        
        public Vector3 realPosA;
        public Vector3 realPosB;
        
        [Header("Events")]
        public UnityEvent onCalibrateStart = new UnityEvent();
        public UnityEvent onCalibrateEnd = new UnityEvent();
        
        
        private LineDrawer _offsetA;
        private LineDrawer _offsetB;
        private LineDrawer _offsetObj;
        private LineDrawer _rotateAxis;
        

         void Start()
         {
             _offsetA = new LineDrawer();
             _offsetB = new LineDrawer();
             _offsetObj = new LineDrawer();
             _rotateAxis = new LineDrawer();
         }

         [ContextMenu("Calibrate")]
         public void Calibrate()
         {
             var offsetA = virtualPosA.position - realPosA;

             var abVectorVirtual = virtualPosA.position - virtualPosB.position;
             var abVectorReal = realPosA - realPosB;

             var angle = Vector3.SignedAngle(abVectorReal, abVectorVirtual, Vector3.up);

             Debug.Log($"angle: {angle}");
             
             _rotateAxis.DrawLineInGameView(virtualPosA.position,virtualPosA.position+ virtualPosA.up,Color.blue);
           
             /*
             var offsetError = (virtualPosB.position - realPosB).magnitude;

             if (offsetError > maxCalibrateOffsetError)
             {
                 Debug.LogError($"[calibration] offset error greater that maximum value Error:{offsetError}");
             }
             Bug: need rotate realPosB around _rotateAxis.
             */
             PlayerCalibrationController.instance.Calibrate(offsetA,virtualPosA.position, angle);
             
             _offsetA.DrawLineInGameView(realPosA,realPosA + offsetA,Color.yellow);
             // _offsetObj.DrawLineInGameView(objForCalibrate.position, objForCalibrate.position + offsetA,Color.green);
         }
    }
}
