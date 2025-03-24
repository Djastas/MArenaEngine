using Corp_Kaktus.MArenaEngine.Scripts.Network.Loaders;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Trash
{
    public class WheelController : MonoBehaviour
    {
        [SerializeField] private ObjectSpawner spawner;

        [SerializeField] private ProjTest projector;

        private void Start()
        {
            // spawner.onSpawn.AddListener(Init);
        }

        public void Init(GameObject spawnedObject)
        {
            projector.targetsA[0] = spawnedObject.transform;
        }
        
    }
}