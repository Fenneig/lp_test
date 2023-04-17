using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace LavaProject.World.Mine
{
    [RequireComponent(typeof(CollectComponent))]
    public class Ore : MonoBehaviour
    {
        [SerializeField] private GameObject _visualPrefab;
        
        [SerializeField] private float _prepareToCollectTime = 1f;
        
        [SerializeField] private float _moveDuration = 1f;
        [SerializeField] private float _jumpForce = 3f;
        [SerializeField] private int _numJumps = 1;

        private CollectComponent _collectComponent;
        
        private void Start()
        {
            _collectComponent = GetComponent<CollectComponent>();
            Instantiate(_visualPrefab, transform);
            PlayStartAnimation();
        }

        public void PlayStartAnimation()
        {
            var newPosition = new Vector3(Random.Range(-5, 5), -transform.position.y + 1f, Random.Range(-5, 5));
            transform.DOJump(transform.position + newPosition, _jumpForce, _numJumps, _moveDuration)
                .SetEase(Ease.OutQuart)
                .OnComplete(() => StartCoroutine(OnAnimationEnd()));
        }

        private IEnumerator OnAnimationEnd()
        {
            yield return new WaitForSeconds(_prepareToCollectTime);
            
            _collectComponent.PrepareToCollect();
        }
    }
}