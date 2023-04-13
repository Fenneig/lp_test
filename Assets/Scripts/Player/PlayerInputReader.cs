using UnityEngine;
using UnityEngine.InputSystem;

namespace LavaProject.Player
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
