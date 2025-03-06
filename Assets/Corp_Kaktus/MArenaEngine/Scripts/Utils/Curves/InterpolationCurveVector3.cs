using System;
using Corp_Kaktus.MArenaEngine.Scripts.Utils.Curves.InterpolationFunc;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Utils.Curves
{
    [Serializable]
    public class InterpolationCurveVector3 : CustomCurve
    {
        [Range(0, 10f)] [SerializeField] private float frequency;
        [Range(0, 10f)] [SerializeField] private float duration;
        [Range(-10f, 10f)] [SerializeField] private float acceleration;
        
        [SerializeField] private AnimationCurve previewCurve;
        
        private InterpolationFuncVector3 _interpolationFunc = new();
        
/// <summary>
/// Warning!! don't work!! Need only for preview
/// </summary>
/// <param name="time"></param>
/// <returns></returns>
        public override float CustomEvaluate(float time)
            => _interpolationFunc.UpdateInternal(1f / bakeQuality, new Vector3(_baseCurve.Evaluate(time),0,0)).x;
        
        
        public Vector3 CustomEvaluateVector3(float timeDelta, Vector3 currentVector)
            => _interpolationFunc.UpdateInternal(timeDelta, currentVector);


        public override AnimationCurve Bake()
        {
            CreateTestCurve();
            _interpolationFunc.CalcParams(frequency, duration, acceleration,  new Vector3(_baseCurve.Evaluate(0),0,0));
            return base.Bake();
        }

        public void Reset(Vector3 startVector)
        {
            _interpolationFunc.CalcParams(frequency, duration, acceleration,  startVector);
        }

        public void UpdatePreview() => previewCurve= Bake();

        private AnimationCurve _baseCurve = new();

        private void CreateTestCurve()
        {
            _baseCurve.AddKey(new Keyframe(0f, 0f));
            _baseCurve.AddKey(new Keyframe(0.49f, 0f));
            _baseCurve.AddKey(new Keyframe(0.51f, 1f));
            _baseCurve.AddKey(new Keyframe(1f, 1f));
        }
        

    }
}