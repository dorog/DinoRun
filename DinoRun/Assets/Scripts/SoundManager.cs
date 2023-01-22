using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;
    [Header("Audio Sources")]
    [SerializeField]
    private AudioSource _jumpedAudioSource;
    [SerializeField]
    private AudioSource _landedAudioSource;

    private void Start()
    {
        _playerController.Jumped.Subscribe(PlayJumpedClip);
        _playerController.Landed.Subscribe(PlayLandedClip);
    }

    private void PlayJumpedClip()
    {
        _jumpedAudioSource.Play();
    }

    private void PlayLandedClip()
    {
        _landedAudioSource.Play();
    }
}
