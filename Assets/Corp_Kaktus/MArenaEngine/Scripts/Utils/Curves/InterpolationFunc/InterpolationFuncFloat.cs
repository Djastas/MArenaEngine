using Unity.Mathematics;

namespace Corp_Kaktus.MArenaEngine.Scripts.Utils.Curves.InterpolationFunc
{
    internal class InterpolationFuncFloat
    {
        private float _lastVector;
        private float _currentVector;
        private float _currentVectorAcceleration;
        private float _k1, _k2, _k3;
        
        /// <summary>
        /// calc k1, k2, k3 params for Interpolation Function work.
        /// </summary>
        /// <param name="f">frequency</param>
        /// <param name="d">duration</param>
        /// <param name="a">acceleration</param>
        /// <param name="startVector"></param>
        public void CalcParams(float f, float d, float a, float startVector)
        {
            _k1 = d / (math.PI * f);
            _k2 = 1 / (2 * math.PI * f * (2 * math.PI * f));
            _k3 = a * d / (2 * math.PI * f);

            _lastVector = startVector;
            _currentVector = startVector;
            _currentVectorAcceleration = 0;
        }

        public float UpdateInternal(float timeDelta, float currentVector, float acceleration)
        {
            _lastVector = currentVector;
            _currentVector += timeDelta * _currentVectorAcceleration;
            _currentVectorAcceleration += timeDelta * (currentVector + _k3 * acceleration - _currentVector - _k1 * _currentVectorAcceleration) / _k2;
            return _currentVector;
        }

        public float UpdateInternal(float timeDelta, float currentVector) 
            => UpdateInternal(timeDelta, currentVector, (currentVector - _lastVector) / timeDelta);
    }
}