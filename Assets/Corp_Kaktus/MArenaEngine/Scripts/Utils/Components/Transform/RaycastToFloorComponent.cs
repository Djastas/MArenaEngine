using UnityEngine;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Components.Transform
{
    public class RaycastToFloorComponent : MonoBehaviour
    {
        [SerializeField] private float maxDistance;
        [SerializeField] private UnityEngine.Transform target;
        
        private  Ray ray => new (transform.position, Vector3.down);
        private void Update()
        {
            Physics.Raycast(ray, out var hit, maxDistance);

            target.position = hit.point;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(ray.origin, ray.direction * maxDistance);
        }
    }
}
// todo
// refactor