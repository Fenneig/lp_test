using System;
using UnityEngine;
using UnityEngine.Events;

namespace LavaProject.Utils
{
    public class TriggerComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask _layer = ~0;
        [SerializeField] private TriggerEvent _enterAction;
        [SerializeField] private TriggerEvent _exitAction;

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.IsInLayer(_layer)) InvokeAction(other, _enterAction);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.IsInLayer(_layer)) InvokeAction(other, _exitAction);
        }

        private void InvokeAction(Collider other, TriggerEvent action)
        {
            action?.Invoke(other.gameObject);
        }
    }

    [Serializable]
    public class TriggerEvent : UnityEvent<GameObject> { }
}