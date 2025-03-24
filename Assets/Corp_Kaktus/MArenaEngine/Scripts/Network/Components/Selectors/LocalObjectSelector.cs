using System;
using Corp_Kaktus.MArenaEngine.Scripts.Network.RoleControl;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Components.Selectors
{
    [AddComponentMenu("Corp_Kaktus/MArenaEngine/Selectors/Local Object Selector")]
    public class LocalObjectSelector : MonoBehaviour
    {
        [Tooltip("true - instantiate need object. false - destroy not need object.")]
        [SerializeField] private bool instantiate = true;
        
        [SerializeField] private GameObject onlyClientGameObject;
        [SerializeField] private GameObject onlyConsoleGameObject;
        [SerializeField] private GameObject onlyServerGameObject;
        
        private void Awake()
        {
            if (instantiate)
            {
                var selectObject = RoleController.currentRole switch
                {
                    Role.Client => onlyClientGameObject,
                    Role.Console => onlyConsoleGameObject,
                    Role.Server => onlyServerGameObject,
                    _ => throw new ArgumentOutOfRangeException()
                };
                if (selectObject != null)
                {
                    Instantiate(selectObject);
                }
            }
            else
            {
                if (RoleController.currentRole != Role.Client && onlyClientGameObject ) { Destroy(onlyClientGameObject); }

                if (RoleController.currentRole != Role.Console && onlyConsoleGameObject)
                {
                    Destroy(onlyConsoleGameObject);
                }
                if (RoleController.currentRole != Role.Server && onlyServerGameObject) { Destroy(onlyServerGameObject); }
            }
        }
    }
}