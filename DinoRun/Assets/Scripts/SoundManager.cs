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
    [SerializeField]
    private AudioSource _diedAudioSource;

    private void Start()
    {
        _playerController.Jumped.Subscribe(PlayJumpedClip);
        _playerController.Landed.Subscribe(PlayLandedClip);
        _playerController.Died.Subscribe(PlayDiedClip);
    }

    private void PlayJumpedClip()
    {
        _jumpedAudioSource.Play();
    }

    private void PlayLandedClip()
    {
        _landedAudioSource.Play();
    }

    private void PlayDiedClip()
    {
        _diedAudioSource.Play();
    }
}
