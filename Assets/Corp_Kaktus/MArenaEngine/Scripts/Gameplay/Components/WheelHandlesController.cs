using Corp_Kaktus.MArenaEngine.Scripts.Network.Trash;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Components
{
    public class WheelHandlesController : MonoBehaviour
    {
        [SerializeField] private ObjectSpawner spawner;

        [SerializeField] private Components.WheelController projector;

        private void Start()
        {
             spawner.onSpawn.AddListener(Init);
        }

        public void Init(GameObject spawnedObject)
        {
            projector.targetsA[0] = spawnedObject.transform;
        }
        
    }
}