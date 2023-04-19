using System.Collections;
using DG.Tweening;
using LavaProject.Assets;
using ObjectPool;
using UnityEngine;

namespace LavaProject.World.Collectable
{
    public class CollectComponent : MonoBehaviour
    {
        [SerializeField] private ItemInfo _itemInfo;
        private bool _isReadyToCollect;
        private Item _item;

        public ItemInfo ItemInfo => _itemInfo;

        private void Awake()
        {
            _item = new Item(_itemInfo) {State = {Amount = 1}};
        }

        public void Collect(GameObject target)
        {
            if (!_isReadyToCollect) return;
            _isReadyToCollect = false;

            var directionToTarget = target.transform.position - transform.position;
            var firstPosition = transform.position - directionToTarget + Vector3.up;

            Sequence collectItemSequence = DOTween.Sequence();
            collectItemSequence
                .Append(transform.DOMove(firstPosition, 1))
                .OnComplete(() => { collectItemSequence.Kill(); })
                .OnKill(() => StartCoroutine(MoveToTarget(transform.position, target.transform, 1)));
        }

        private IEnumerator MoveToTarget(Vector3 startPosition, Transform targetTransform, float animationTime)
        {
            var time = 0f;
            while (time <= animationTime)
            {
                time += Time.deltaTime;
                var progress = time / animationTime;
                var value = Vector3.Lerp(startPosition, targetTransform.position + Vector3.up, progress);
                transform.position = value;
                yield return null;
            }

            OnCollectComplete();
        }

        public void PrepareToCollect()
        {
            _isReadyToCollect = true;
        }

        private void OnCollectComplete()
        {
            GameSession.Instance.Inventory.Add(this, _item);
            Pool.Instance.Destroy(gameObject);
        }
    }
}