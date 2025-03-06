using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Trash
{
    public class CubeShooter : MonoBehaviour
    {
        [SerializeField] private XRGrabInteractable interactable;

        [SerializeField] private GameObject netBullet;
        
        [SerializeField] private Transform bulletSpawnPoint;
        private void OnValidate()
        {
            if (interactable == null)
            {
                interactable = GetComponent<XRGrabInteractable>();
            }
        }

        private void Start()
        {
            interactable.hoverEntered.AddListener(i => {Debug.Log($"start hover",i.interactorObject.transform);});
            interactable.activated.AddListener(i =>
            {
                Debug.Log($"click",i.interactorObject.transform);
                Shoot();
            });
        }

        public void Shoot()
        {
            var instance = Instantiate(netBullet, bulletSpawnPoint.position,bulletSpawnPoint.rotation);
            instance.GetComponent<NetworkObject>().Spawn();
            
            
        }
    }
}