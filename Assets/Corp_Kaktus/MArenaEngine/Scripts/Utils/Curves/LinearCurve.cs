using System;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Utils.Curves
{
    [Serializable]
    public class LinearCurve : CustomCurve
    {
        [Range(0.0f,10)][SerializeField] private float multiplier;
        public override float CustomEvaluate(float time) => time;
    }
}