using Corp_Kaktus.MArenaEngine.Scripts.Network.Loaders;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Trash
{
    public class WheelController : MonoBehaviour
    {
        [SerializeField] private ObjectSpawner spawner;

        private void Start()
        {
            spawner.onSpawn.AddListener(Init);
        }

        private void Init(GameObject spawnedObject)
        {
            
        }
        
    }
}