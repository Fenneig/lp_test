using DG.Tweening;
using UnityEngine;

namespace LavaProject.World.Mine
{
    public class Ore : MonoBehaviour
    {
        [SerializeField] private float _moveDuration = 1f;
        [SerializeField] private float _jumpForce = 3f;
        [SerializeField] private int _numJumps = 1;
        private void Start()
        {
            var newPosition = new Vector3(Random.Range(-5, 5), -transform.position.y, Random.Range(-5, 5));
            transform.DOJump(transform.position + newPosition, _jumpForce, _numJumps, _moveDuration)
                .SetEase(Ease.OutQuart)
                .OnComplete(OnAnimationEnd);
        }

        private void OnAnimationEnd()
        {
            
        }
    }
}