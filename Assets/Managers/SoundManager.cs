using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _embientSound;
    [SerializeField] private AudioClip _collectSound;
    [SerializeField] private AudioClip _crashSound;
    [SerializeField] private AudioClip _swipeSound;

    private AudioSource _audioSource;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _embientSound;
        _audioSource.Play();
    }
    public void PlayCollectSoundFx() => _audioSource.PlayOneShot(_collectSound);
    public void PlayCrashSoundFx() => _audioSource.PlayOneShot(_crashSound); 
    public void PlaySwipeSoundFx() => _audioSource.PlayOneShot(_swipeSound);
    
}
