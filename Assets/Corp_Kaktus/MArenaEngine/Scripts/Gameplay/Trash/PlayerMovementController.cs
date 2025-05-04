using UnityEngine;
using UnityEngine.InputSystem;

namespace Corp_Kaktus.MArenaEngine.Scripts.Gameplay.Trash
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private float speed;
        [SerializeField] private InputAction moveValue;
        private void Start()
        {
            moveValue.Enable();
        }

        private void Update()
        {
            var offset = moveValue.ReadValue<Vector2>() * (speed * Time.deltaTime);
            playerTransform.position += new Vector3(offset.x, 0, offset.y);
        }
    }
}