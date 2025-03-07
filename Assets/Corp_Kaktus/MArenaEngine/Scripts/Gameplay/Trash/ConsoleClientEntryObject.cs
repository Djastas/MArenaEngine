using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Trash
{
    public class ConsoleClientEntryObject : MonoBehaviour
    {
        [SerializeField] private GameObject console;
        [SerializeField] private GameObject client;
        public void Awake() => Destroy(EngineSettings.EngineSettings.settings.controlClientBuild ? client : console);
    }
}