using System;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Utils.Curves
{
    [Serializable]
    public abstract class CustomCurve
    { 
        public abstract float CustomEvaluate(float time);
        
        
        [SerializeField] protected int bakeQuality = 100;

        public virtual AnimationCurve Bake()
        {
            var curve = new AnimationCurve();

            for (var frameIndex = 0; frameIndex < bakeQuality; frameIndex++)
            {
                var time = ((float)frameIndex)/bakeQuality;
                curve.AddKey(new Keyframe(time, CustomEvaluate(time)));
            }
            
            return curve;
        }

    }
}