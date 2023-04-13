using UnityEngine;
using UnityEngine.InputSystem;

namespace LavaProject.Characters
{
    public class PlayerInputReader : MonoBehaviour
    {
        [SerializeField] private MovementComponent _movementComponent;

        public void OnMovement(InputAction.CallbackContext context)
        {
            _movementComponent.Direction = context.ReadValue<Vector2>();
        }
    }
}
