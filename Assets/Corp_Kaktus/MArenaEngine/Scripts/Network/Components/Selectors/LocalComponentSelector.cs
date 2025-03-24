using System.Collections.Generic;
using Corp_Kaktus.MArenaEngine.Scripts.Network.RoleControl;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Components.Selectors
{
    [AddComponentMenu("Corp_Kaktus/MArenaEngine/Selectors/Local Object Component Selector")]
    public class LocalComponentSelector : MonoBehaviour
    {
        [SerializeField] private List<Behaviour> onlyClientComponents;
        [SerializeField] private List<Behaviour> onlyConsoleComponents;
        [SerializeField] private List<Behaviour> onlyServerComponents;

        private void Awake()
        {
            if (RoleController.currentRole != Role.Client) { DestroyAll(onlyClientComponents); }
            if (RoleController.currentRole != Role.Console) { DestroyAll(onlyConsoleComponents); }
            if (RoleController.currentRole != Role.Server) { DestroyAll(onlyServerComponents); }
        }

        private static void DestroyAll(List<Behaviour> behaviours)
        { foreach (var behaviour in behaviours) { Destroy(behaviour); } }
    }
}