using System;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Trash
{
    public class VRSimulatorController : MonoBehaviour
    {
        [SerializeField] private GameObject vrSimulatorGameObject;

        private void Awake()
        {
            if (EngineSettings.EngineSettings.settings.useVRSimulator)
            {
                vrSimulatorGameObject.SetActive(true);
            }
        }
    }
}