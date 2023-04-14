using DG.Tweening;
using ObjectPool;
using UnityEngine;

namespace LavaProject.World.Mine
{
    public class CollectComponent : MonoBehaviour
    {
        private bool _isReadyToCollect;
        public void Collect(GameObject target)
        {
            if (!_isReadyToCollect) return;
            _isReadyToCollect = false;
            
            //TODO : Сделать красивую анимацию движения в игрока через курутины!
            
            var directionToTarget = target.transform.position - transform.position;
            var firstPosition = transform.position - directionToTarget + Vector3.up;
            
            Sequence collectItemSequence = DOTween.Sequence();
            collectItemSequence
                .Append(transform.DOMove(firstPosition, 1))
                .Append(transform.DOMove(target.transform.position, 1))
                .OnComplete(() =>{collectItemSequence.Kill();})
                .OnKill(OnCollectComplete);
        }

        public void PrepareToCollect()
        {
            _isReadyToCollect = true;
        }

        private void OnCollectComplete()
        {
            Debug.Log($"Collected {name}");
            Pool.Instance.Destroy(gameObject);
        }
    }
}
