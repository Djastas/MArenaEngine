using Unity.Netcode;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Corp_Kaktus.MArenaEngine.Scripts.Network.Components
{
    [RequireComponent(typeof(XRGrabInteractable))]
    [AddComponentMenu("Corp_Kaktus/MArenaEngine/Network/Grab Object Ownership Controller")]
    public class GrabObjectOwnershipController : NetworkBehaviour
    {
        private void Start()
        {
            var xrGrabInteractable = GetComponent<XRGrabInteractable>();
            xrGrabInteractable.selectEntered.AddListener(ChangeOwnership);
            xrGrabInteractable.lastSelectExited.AddListener(_ => { ChangeOwnershipRpc(0); });
            
        }

        private void ChangeOwnership(BaseInteractionEventArgs activateEventArgs)
        {
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