using UnityEngine;
using UnityEngine.AI;

namespace LavaProject.Characters
{
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _nmAgent;
        public Vector2 Direction { get; set; }
        public bool IsRunning { get; private set; }

        private void Update()
        {
            if (Direction.x != 0 || Direction.y != 0)
            {
                var moveDirection = new Vector3(Direction.y, 0, -Direction.x);
                _nmAgent.SetDestination(transform.position + moveDirection);
                IsRunning = true;
            }
            else
            {
                _nmAgent.SetDestination(transform.position);
                IsRunning = false;
            }
        }
    }
}