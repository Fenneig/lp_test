using UnityEngine;

namespace LavaProject.Characters
{
    [RequireComponent(typeof(Animator))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private MovementComponent _movementComponent;
        [SerializeField] private MiningComponent _miningComponent;
        
        private Animator _animator;
        
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");
        private static readonly int IsMining = Animator.StringToHash("IsMining");


        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (_movementComponent != null) _animator.SetBool(IsRunning, _movementComponent.IsRunning);
            
            if (_miningComponent != null) _animator.SetBool(IsMining, _miningComponent.IsMining);
        }
    }
}