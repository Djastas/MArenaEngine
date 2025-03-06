using System;
using Corp_Kaktus.MArenaEngine.Scripts.Utils.Curves.InterpolationFunc;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Utils.Curves
{
    [Serializable]
    public class InterpolationCurveFloat : CustomCurve
    {
        [Range(0, 10f)] [SerializeField] private float frequency;
        [Range(0, 10f)] [SerializeField] private float duration;
        [Range(-10f, 10f)] [SerializeField] private float acceleration;


        private InterpolationFuncFloat _interpolationFunc = new();

        public override float CustomEvaluate(float time)
            => _interpolationFunc.UpdateInternal(1f / bakeQuality, _testCurve.Evaluate(time)); 
        // todo
        // Bug method work only for bake
                                                                                         


        public override AnimationCurve Bake()
        {
            CreateTestCurve();
            _interpolationFunc.CalcParams(frequency, duration, acceleration, _testCurve.Evaluate(0));
            return base.Bake();
        }

        private AnimationCurve _testCurve = new();

        private void CreateTestCurve()
        {
            _testCurve.AddKey(new Keyframe(0f, 0f));
            _testCurve.AddKey(new Keyframe(0.49f, 0f));
            _testCurve.AddKey(new Keyframe(0.51f, 1f));
            _testCurve.AddKey(new Keyframe(1f, 1f));
        }

    }
}