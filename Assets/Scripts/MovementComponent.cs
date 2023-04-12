using UnityEngine;
using UnityEngine.AI;

public class MovementComponent : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _nmAgent;
    [SerializeField] private DynamicJoystick _joystick;
    

    private void Update()
    {
        if (_joystick.Direction.x != 0 || _joystick.Direction.y != 0)
        {
            var moveDirection = new Vector3(_joystick.Direction.y, 0, -_joystick.Direction.x);
            _nmAgent.SetDestination(transform.position + moveDirection);
        }
        else
        {
            _nmAgent.SetDestination(transform.position);
        }
    }
}
