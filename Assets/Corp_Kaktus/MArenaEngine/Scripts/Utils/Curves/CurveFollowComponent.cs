using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Utils.Curves
{
    public class CurveFollowComponent : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private InterpolationCurveVector3 positionInterpolationFunc;
        
        [SerializeField] private float resetDistance = 50f;

        private void Update()
        {
            var posVector = positionInterpolationFunc.CustomEvaluateVector3(Time.deltaTime,target.position);

            if ( posVector.x > resetDistance || posVector.x < resetDistance * -1 ||
                 posVector.y > resetDistance || posVector.y < resetDistance * -1 ||
                 posVector.z > resetDistance || posVector.z < resetDistance * -1)
            {
                positionInterpolationFunc.Reset(target.position);
                return;
            }
            transform.position = posVector;
        }

        private void OnValidate() => positionInterpolationFunc.UpdatePreview();
    }
}