using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LavaProject.Systems
{
    public class Tutorial : MonoBehaviour
    {
        [Header("Cameras")] [SerializeField] private CinemachineVirtualCamera _tutorialCamera;

        [Space] [Header("Objective transforms")] [SerializeField]
        private Transform _objectiveTransform1;

        [SerializeField] private Transform _objectiveTransform2;

        [Space] [Header("UI Elements")] [SerializeField]
        private Transform _objectiveArrow1;

        [SerializeField] private Transform _objectiveArrow2;

        [Space] [Header("Controls")] [SerializeField]
        private InputActionAsset _controls;

        private bool _isTutorialComplete;

        private void Start()
        {
            _isTutorialComplete = GameSession.Instance.IsTutorialComplete;
            if (!_isTutorialComplete) TutorialFirstStep();
        }

        [ContextMenu("FirstStep")]
        public void TutorialFirstStep()
        {
            if (_isTutorialComplete || !gameObject.activeSelf) return;
            SetupSequence(_objectiveTransform1, _objectiveArrow1, false);
        }

        [ContextMenu("SecondStep")]
        public void TutorialSecondStep()
        {
            if (_isTutorialComplete || !gameObject.activeSelf) return;
            SetupSequence(_objectiveTransform2, _objectiveArrow2, true);
        }

        private void SetupSequence(Transform objectiveTransform, Transform arrow, bool isCompleteStep)
        {
            _tutorialCamera.Follow = objectiveTransform;
            _tutorialCamera.LookAt = objectiveTransform;
            _tutorialCamera.gameObject.SetActive(true);
            arrow.gameObject.SetActive(true);
            _controls.Disable();
            var sequence = DOTween.Sequence();
            sequence
                .Append(arrow.DOLocalMove(arrow.localPosition + Vector3.down, .5f))
                .Append(arrow.DOLocalMove(arrow.localPosition, .5f))
                .SetLoops(4)
                .OnComplete(() => sequence.Kill())
                .OnKill(() =>
                {
                    _tutorialCamera.gameObject.SetActive(false);
                    arrow.gameObject.SetActive(false);
                    _controls.Enable();
                    if (!isCompleteStep) return;
                    GameSession.Instance.CompleteTutorial();
                    gameObject.SetActive(false);
                });
        }
    }
}