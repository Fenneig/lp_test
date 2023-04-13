using UnityEngine;
using UnityEngine.AI;

namespace LavaProject.Player
{
    [RequireComponent(typeof(Animator))]
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _nmAgent;
        private Animator _animator;
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");
        public Vector2 Direction { get; set; }

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Direction.x != 0 || Direction.y != 0)
            {
                var moveDirection = new Vector3(Direction.y, 0, -Direction.x);
                _nmAgent.SetDestination(transform.position + moveDirection);
                _animator.SetBool(IsRunning, true);
            }
            else
            {
                _nmAgent.SetDestination(transform.position);    
                _animator.SetBool(IsRunning, false);
            }
        }
    }
}