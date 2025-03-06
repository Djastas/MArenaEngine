using Unity.Mathematics;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Utils.Curves.InterpolationFunc
{

    internal class InterpolationFuncVector3
    {
        private Vector3 _lastVector;
        private Vector3 _currentVector;
        private Vector3 _currentVectorAcceleration;
        private float _k1, _k2, _k3;
        
        /// <summary>
        /// calc k1, k2, k3 params for Interpolation Function work.
        /// </summary>
        /// <param name="f">frequency</param>
        /// <param name="d">duration</param>
        /// <param name="a">acceleration</param>
        /// <param name="startVector"></param>
        public void CalcParams(float f, float d, float a, Vector3 startVector)
        {
            _k1 = d / (math.PI * f);
            _k2 = 1 / (2 * math.PI * f * (2 * math.PI * f));
            _k3 = a * d / (2 * math.PI * f);

            _lastVector = startVector;
            _currentVector = startVector;
            _currentVectorAcceleration = Vector3.zero;
        }

        public Vector3 UpdateInternal(float timeDelta, Vector3 currentVector, Vector3 acceleration)
        {
            _lastVector = currentVector;
            _currentVector += timeDelta * _currentVectorAcceleration;
            _currentVectorAcceleration += timeDelta * (currentVector + _k3 * acceleration - _currentVector - _k1 * _currentVectorAcceleration) / _k2;
            return _currentVector;
        }

        public Vector3 UpdateInternal(float timeDelta, Vector3 currentVector) 
            => UpdateInternal(timeDelta, currentVector, (currentVector - _lastVector) / timeDelta);
    }
}