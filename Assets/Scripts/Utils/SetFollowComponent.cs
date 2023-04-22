using Cinemachine;
using UnityEngine;

namespace LavaProject.Utils
{
    public class SetFollowComponent : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _camera;

        private void Start()
        {
            _camera.Follow = GameSession.Instance.Player.transform;
            _camera.LookAt = GameSession.Instance.Player.transform;
        }
    }
}