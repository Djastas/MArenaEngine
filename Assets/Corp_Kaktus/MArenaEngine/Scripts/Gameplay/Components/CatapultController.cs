using System;
using System.Collections;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Components
{
    public class CatapultController : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Transform catapultTransform;
        [SerializeField] private WheelController wheelController;
        [Space] [SerializeField] private float endRot;

        private Coroutine _currentCoroutine;

        private void Update()
        {
            var tm = wheelController.transform;
            if (tm.rotation.eulerAngles.z > endRot)
            {
                wheelController.HardResetHandlers();

            }
        }

    }
}