using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _jumpedAudioSource;
    [SerializeField]
    private AudioSource _landedAudioSource;

    public void PlayJumpedClip()
    {
        _jumpedAudioSource.Play();
    }

    public void PlayLandedClip()
    {
        _landedAudioSource.Play();
    }
}
