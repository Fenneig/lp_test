using UnityEngine;
using UnityEngine.AI;

public class MovementComponent : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _nmAgent;
    [SerializeField] private DynamicJoystick _joystick;
    
    [SerializeField] private float _speed;

    private void Update()
    {
        _nmAgent.SetDestination(_joystick.Direction.magnitude != 0
            ? new Vector3(_joystick.Direction.x * _speed, 0, _joystick.Direction.y * _speed)
            : transform.position);
    }
}
