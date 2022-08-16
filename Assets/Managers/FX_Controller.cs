using UnityEngine;

public class FX_Controller : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fxPickup;
    [SerializeField] private ParticleSystem _fxDeath;
    public void PlayPickupFx() => _fxPickup.Play();
    public void PlayDeathFx() => _fxDeath.Play();

    public bool DeathCancel() => _fxDeath.isPlaying;
    
}
