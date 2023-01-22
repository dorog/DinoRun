using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private string _jumpAnimationTriggerName;
    [SerializeField]
    private string _landAnimationTriggerName;

    private void Start()
    {
        _playerController.Jumped.Subscribe(PlayJumpedAnimation);
        _playerController.Landed.Subscribe(PlayLandedAnimation);
    }

    private void PlayJumpedAnimation()
    {
        _animator.SetTrigger(_jumpAnimationTriggerName);
    }

    private void PlayLandedAnimation()
    {
        _animator.SetTrigger(_landAnimationTriggerName);
    }
}
