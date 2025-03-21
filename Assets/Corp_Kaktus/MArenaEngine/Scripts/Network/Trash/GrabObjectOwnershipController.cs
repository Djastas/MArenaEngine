using Unity.Netcode;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Trash
{
    [RequireComponent(typeof(XRGrabInteractable))]
    public class GrabObjectOwnershipController : NetworkBehaviour
    {
        private void Start()
        {
            GetComponent<XRGrabInteractable>().selectEntered.AddListener(ChangeOwnership);
        }

        private void ChangeOwnership(BaseInteractionEventArgs activateEventArgs)
        {
            Debug.Log(activateEventArgs.interactorObject.transform.name);
            ChangeOwnershipRpc(activateEventArgs.interactorObject.transform.GetComponentInParent<NetworkObject>().OwnerClientId);
        }
        
        [Rpc(SendTo.Server)]
        private void ChangeOwnershipRpc(ulong ownerClientId)
        {
            if (OwnerClientId != ownerClientId)
            {
                NetworkObject.ChangeOwnership(ownerClientId);
            }
        }
    }
}