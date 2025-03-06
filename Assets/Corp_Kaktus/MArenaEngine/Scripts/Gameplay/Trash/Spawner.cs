using System;
using Unity.Netcode;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Trash
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform position;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            var instance = Instantiate(prefab,position.position,Quaternion.identity);
            var instanceNetworkObject = instance.GetComponent<NetworkObject>();
            instanceNetworkObject.Spawn();
        }

        private void Start()
        {
            Spawn();
        }
    }
}