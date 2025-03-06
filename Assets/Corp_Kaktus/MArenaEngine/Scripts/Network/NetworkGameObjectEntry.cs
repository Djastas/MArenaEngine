using Unity.Netcode;
using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network
{
    public class NetworkGameObjectEntry : NetworkBehaviour
    {
        [SerializeField] private GameObject ownerObject;
        [SerializeField] private GameObject visualObject;

        private void Start()
        {
           
           var inst = Instantiate(IsOwner ? ownerObject : visualObject);
           
           var networkObject = inst.GetComponent<NetworkObject>();
           if (networkObject == null)
           {
               Debug.Log("prefab not contain network object", this);
               return;
           }
           networkObject.Spawn();
        }
    }
}
