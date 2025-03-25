using System.Collections;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay
{
    public class LegController : MonoBehaviour
    {
        [SerializeField] private Transform idealTarget;
        [SerializeField] private Transform currentTarget;
        
        [SerializeField] private float stepThreshold;
        [Tooltip("move leg further that need")] [SerializeField] private float predictLenght;

        [SerializeField] private float stepTime;
        [SerializeField] private float stepHeight;
        [SerializeField] private AnimationCurve heightCurve;
        
        private Coroutine _stepRoutine;

        private void Update()
        {
            var distance = (idealTarget.position - currentTarget.position).magnitude;
            if (!(distance > stepThreshold) || _stepRoutine != null) return;
            
            var direction = (currentTarget.position - idealTarget.position).normalized;
            _stepRoutine = StartCoroutine(Step(currentTarget.position,idealTarget.position + direction * predictLenght));
        }

        private IEnumerator Step(Vector3 startPos,Vector3 endPos)
        {
            var time = 0f;
            while (true)
            {
                yield return null;
                time += Time.deltaTime / stepTime;
                currentTarget.position = Vector3.Lerp(startPos, endPos, time) + Vector3.up * (stepHeight * heightCurve.Evaluate(time));
                if (time >= 1f)
                {
                    break;
                }
            }

            _stepRoutine = null;

        }
    }
}